using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Model
{
    public class Transaction
    {
        public string RawData { get; set; }
        public int Kwota { get; set; }
        public DateTime DataObciazeniaRachunku { get; set; }
        public string RachunekKlientaAdresata { get; set; }
    }
}
