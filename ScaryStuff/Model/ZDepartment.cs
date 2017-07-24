using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryStuff.Model
{
    public class ZDepartment
    {
        public long Id { get; set; }
        public string ZeportUuid { get; set; }
        public int ZNumber { get; set; }
        public string CashRegisterSerialNumber { get; set; }
        public string BranchCode { get; set; }
        public DateTime ZDateTime { get; set; }
        public string DepartmentName { get; set; }
        public decimal DepartmentTotalAmount { get; set; }
        public int DepartmentTotalCount { get; set; }
        public bool Transferred { get; set; }
        public string AddedBy { get; set; }

    }
}
