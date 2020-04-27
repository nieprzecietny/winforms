using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Services;

namespace WinForms.Views
{
    public partial class LoadReportView : UserControl, ILoadReportView
    {
        public LoadReportView()
        {
            InitializeComponent();
        }

        public Control Control => this;

        public void ClearReport()
        {
            textBoxReportResults.Text = string.Empty;
        }

        public void WriteMessage(string message)
        {
            textBoxReportResults.AppendText($"{message}");
            textBoxReportResults.AppendText(Environment.NewLine);
        }
    }
}
