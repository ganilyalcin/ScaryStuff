using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryStuff.Model
{
    public class ZReportDataCheckModel
    {
        public long Id { get; set; }        
        public int ZNumber { get; set; }
        public string CashRegisterSerialNumber { get; set; }        
        public DateTime? ZDateTime { get; set; }
        public decimal DailyTotalAmount { get; set; }
        public decimal DailyTotalVat { get; set; }
        public decimal CumulativeAmount { get; set; }
        public decimal CumulativeTaxVat { get; set; }
        public decimal CashAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public bool MissingRecord { get; set; }
    }
}
