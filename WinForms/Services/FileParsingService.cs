using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms.Model;

namespace WinForms.Services
{
    public static class CsvHelper
    {
        public static string GetValueAt(this string[] array, int index)
        {
            return array.Count() >= index ? array[index] : string.Empty;
        }
    }

    public class FileParsingService : IFileParsingService
    {
        public List<Transaction> Parse(FileInfo fileInfo)
        {
            var result = new List<Transaction>();
            using (StringReader reader = new StringReader(File.ReadAllText(fileInfo.FullName, Encoding.Default)))
            {
                var lineNumber = 0;
                while (true)
                {
                    var line = reader.ReadLine();
                    lineNumber += 1;
                    if (line != null)
                    {
                        if (lineNumber > 1)
                        {
                            var splitted = line.Split(',');
                            var transactionRecord = new Transaction
                            {
                                RawData = line,
                                Kwota = int.Parse(splitted.GetValueAt(2)),
                                DataObciazeniaRachunku = DateTime.ParseExact(splitted.GetValueAt(1), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None),
                                RachunekKlientaAdresata = splitted.GetValueAt(6).Replace("\"",string.Empty)
                            };
                            result.Add(transactionRecord);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;

        }

        public List<string> Validate(FileInfo fileInfo)
        {
            return Parse(File.ReadAllText(fileInfo.FullName, Encoding.Default));
        }





        public List<string> Parse(string data)
        {
            var result = new List<string>();
            using (StringReader reader = new StringReader(data))
            {
                var lineNumber = 0;
                while (true)
                {
                    var line = reader.ReadLine();
                    lineNumber += 1;
                    if (line != null)
                    {
                        if (lineNumber > 1)
                        {
                            var splitted = line.Split(',');

                            int typKomunikatu = 0;
                            if (!(int.TryParse(splitted.GetValueAt(0), out typKomunikatu) && typKomunikatu == 110))
                            {
                                result.Add($"typ komunikatu bledny wiersz: {line}");
                            }
                            DateTime dataObciazenia = new DateTime();
                            if (!DateTime.TryParseExact(splitted.GetValueAt(1), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataObciazenia))
                            {
                                result.Add($"data obciazenia bledny wiersz: {line}");
                            }
                            int kwota = 0;
                            if (!int.TryParse(splitted.GetValueAt(2), out kwota))
                            {
                                result.Add($"kwota bledny wiersz: {line}");
                            }

                            int nrJednostkiPrezentujacej = 0;
                            if (!int.TryParse(splitted.GetValueAt(3), out nrJednostkiPrezentujacej))
                            {
                                result.Add($"nr jednostki prezentujacej bledny wiersz: {line}");
                            }
                            int nrJednostkiOdbierajacej = 0;
                            if (!int.TryParse(splitted.GetValueAt(4), out nrJednostkiOdbierajacej))
                            {
                                result.Add($"nr jednostki odbierajacej bledny wiersz: {line}");
                            }

                            //rachunekKlientaNadawcy
                            if (string.IsNullOrWhiteSpace(splitted.GetValueAt(5)))
                            {
                                result.Add($" rachunekKlientaNadawcy  bledny wiersz: {line}");
                            }

                            //rachunekKlientaAdresata
                            if (string.IsNullOrWhiteSpace(splitted.GetValueAt(6)))
                            {
                                result.Add($" rachunekKlientaAdresata  bledny wiersz: {line}");
                            }
                            //nazwaKlientaNadawcy
                            if (string.IsNullOrWhiteSpace(splitted.GetValueAt(7)))
                            {
                                result.Add($" nazwaKlientaNadawcy  bledny wiersz: {line}");
                            }

                            //nazwaKlientaAdresata
                            if (string.IsNullOrWhiteSpace(splitted.GetValueAt(8)))
                            {
                                result.Add($" nazwaKlientaAdresata bledny wiersz: {line}");
                            }

                            //nrNadawcyUczestnikaPosredniego
                            int nrNadawcyUczestnikaPosredniego = 0;
                            if (!int.TryParse(splitted.GetValueAt(9), out nrNadawcyUczestnikaPosredniego))
                            {
                                result.Add($"nrNadawcyUczestnikaPosredniegobledny wiersz: {line}");
                            }

                            //nrNadawcyFinalnyADresat
                            int nrNadawcyFinalnyADresat = 0;
                            if (!int.TryParse(splitted.GetValueAt(10), out nrNadawcyFinalnyADresat))
                            {
                                result.Add($"nrNadawcyFinalnyADresat bledny wiersz: {line}");
                            }

                            //informacje dodatkowe
                            if (string.IsNullOrWhiteSpace(splitted.GetValueAt(11)))
                            {
                                result.Add($" nazwaKlientaAdresata bledny wiersz: {line}");
                            }

                            //informacje dodatkowe
                            if (string.IsNullOrWhiteSpace(splitted.GetValueAt(12)))
                            {
                                result.Add($" nr czeku  bledny wiersz: {line}");
                            }

                            //informacje dodatkowe
                            if (string.IsNullOrWhiteSpace(splitted.GetValueAt(13)))
                            {
                                result.Add($" szczegoly reklamacji bledny wiersz: {line}");
                            }

                            if (!(!string.IsNullOrWhiteSpace(splitted.GetValueAt(14)) && string.Equals(splitted.GetValueAt(14), "\"51\"")))
                            {
                                result.Add($"identyfikacjaspraw bledny wiersz: {line}");
                            }

                            //informacje dodatkowe
                            if (string.IsNullOrWhiteSpace(splitted.GetValueAt(15)))
                            {
                                result.Add($" informacje miedzybankowe bledny wiersz: {line}");
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }


    }
}
