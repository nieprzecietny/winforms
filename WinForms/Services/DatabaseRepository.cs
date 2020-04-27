using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms.Model;

namespace WinForms.Services
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public string ConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public bool CheckIfFileImported(string fileName, DateTime date)
        {

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "[dbo].[CheckIfAlreadyImported]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@filename", SqlDbType.NVarChar).Value = fileName.Trim();
                    cmd.Parameters.Add("@importdate", SqlDbType.Date).Value = date;
                    cmd.Connection.Open();
                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }

        }

        public void SaveResults(string fileName, DateTime date, IList<Transaction> transactions)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection.Open();
                    using (var transaction = cmd.Connection.BeginTransaction())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandText = "[dbo].[ImportTransactions]";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@filename", SqlDbType.NVarChar).Value = fileName.Trim();
                            cmd.Parameters.Add("@importdate", SqlDbType.Date).Value = date;
                            cmd.Parameters.AddWithValue("@data", ConvertToDataTable(transactions));
                            cmd.Parameters["@data"].TypeName = "dbo.TransactionRow";
                            cmd.Parameters["@data"].SqlDbType = SqlDbType.Structured;
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;


        }
    }
}
