using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryStuff.Model
{
    class ZentegreDBContext
    {
        /// <summary>
        /// I have manuplated context to feed dummy data
        /// </summary>
        /// <returns></returns>
        public List<ZDepartment> ZDepartments()
        {
            string s1 = "Serial 1";
            string s2 = "Serial 2";
            string s3 = "Serial 3";

            string d1 = "Department 1";
            string d2 = "Department 2";
            string d3 = "Department 3";
            string d4 = "Department 4";
            string d5 = "Department 5";

            var l = new List<ZDepartment>();

            #region Serial 1 data
            l.Add(new ZDepartment()
            {
                CashRegisterSerialNumber = s1,
                DepartmentName = d1,
                DepartmentTotalAmount = 0,
                ZDateTime = DateTime.Now,
                ZNumber = 12,
                Transferred = false,
                Id = 1,
                AddedBy = "Sys",
                BranchCode = "",
                DepartmentTotalCount = 0,
                ZeportUuid = ""
            });

            l.Add(new ZDepartment()
            {
                CashRegisterSerialNumber = s1,
                DepartmentName = d2,
                DepartmentTotalAmount = 0,
                ZDateTime = DateTime.Now,
                ZNumber = 12,
                Transferred = false,
                Id = 2,
                AddedBy = "Sys",
                BranchCode = "",
                DepartmentTotalCount = 0,
                ZeportUuid = ""
            });

            l.Add(new ZDepartment()
            {
                CashRegisterSerialNumber = s1,
                DepartmentName = d3,
                DepartmentTotalAmount = 0,
                ZDateTime = DateTime.Now,
                ZNumber = 12,
                Transferred = false,
                Id = 3,
                AddedBy = "Sys",
                BranchCode = "",
                DepartmentTotalCount = 0,
                ZeportUuid = ""
            });
            #endregion

            #region Serial 2 data
            l.Add(new ZDepartment()
            {
                CashRegisterSerialNumber = s2,
                DepartmentName = d2,
                DepartmentTotalAmount = 0,
                ZDateTime = DateTime.Now,
                ZNumber = 12,
                Transferred = false,
                Id = 4,
                AddedBy = "Sys",
                BranchCode = "",
                DepartmentTotalCount = 0,
                ZeportUuid = ""
            });

            l.Add(new ZDepartment()
            {
                CashRegisterSerialNumber = s2,
                DepartmentName = d4,
                DepartmentTotalAmount = 0,
                ZDateTime = DateTime.Now,
                ZNumber = 12,
                Transferred = false,
                Id = 5,
                AddedBy = "Sys",
                BranchCode = "",
                DepartmentTotalCount = 0,
                ZeportUuid = ""
            });

            l.Add(new ZDepartment()
            {
                CashRegisterSerialNumber = s2,
                DepartmentName = d5,
                DepartmentTotalAmount = 0,
                ZDateTime = DateTime.Now,
                ZNumber = 12,
                Transferred = false,
                Id = 6,
                AddedBy = "Sys",
                BranchCode = "",
                DepartmentTotalCount = 0,
                ZeportUuid = ""
            });
            #endregion

            return l;
        }

        public List<ZReportDataCheckModel> GetMissingZList()
        {
            var l = new List<ZReportDataCheckModel>();

            #region Missing ZReports for serial 1
            l.Add(new ZReportDataCheckModel()
            {

                Id = 1,
                CashRegisterSerialNumber = "Serial 1",
                ZNumber = 234,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 2,
                CashRegisterSerialNumber = "Serial 1",
                ZNumber = 242,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 3,
                CashRegisterSerialNumber = "Serial 1",
                ZNumber = 250,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 4,
                CashRegisterSerialNumber = "Serial 1",
                ZNumber = 251,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 5,
                CashRegisterSerialNumber = "Serial 1",
                ZNumber = 252,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 6,
                CashRegisterSerialNumber = "Serial 1",
                ZNumber = 253,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 7,
                CashRegisterSerialNumber = "Serial 1",
                ZNumber = 254,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });
            #endregion

            #region Missing ZReports for serial 2
            l.Add(new ZReportDataCheckModel()
            {

                Id = 8,
                CashRegisterSerialNumber = "Serial 2",
                ZNumber = 104,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 9,
                CashRegisterSerialNumber = "Serial 2",
                ZNumber = 181,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 10,
                CashRegisterSerialNumber = "Serial 2",
                ZNumber = 182,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 11,
                CashRegisterSerialNumber = "Serial 2",
                ZNumber = 183,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 12,
                CashRegisterSerialNumber = "Serial 2",
                ZNumber = 183,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 13,
                CashRegisterSerialNumber = "Serial 2",
                ZNumber = 184,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });

            l.Add(new ZReportDataCheckModel()
            {

                Id = 14,
                CashRegisterSerialNumber = "Serial 2",
                ZNumber = 196,
                CashAmount = 0,
                CreditAmount = 0,
                CumulativeAmount = 0,
                CumulativeTaxVat = 0,
                DailyTotalAmount = 0,
                DailyTotalVat = 0,
                MissingRecord = true,
                ZDateTime = DateTime.Now,
            });
            #endregion



            return l;
        }
    }
}
