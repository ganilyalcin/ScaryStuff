using ScaryStuff.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScaryStuff.ViewModel
{
    public class MissingReportsCorrectionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IMessageBoxService _messageBoxService;

        public IMessageBoxService MessageBoxService
        {
            get { return _messageBoxService; }
            set { _messageBoxService = value; }
        }

        public MissingReportsCorrectionViewModel()
        {

        }

        public MissingReportsCorrectionViewModel(int taxpayerId, string oKCSerial, int processMonth, int processYear, ObservableCollection<ZReportDataCheckModel> missingZCollection)
        {
            this.taxpayerId = taxpayerId;
            this.OKCSerial = oKCSerial;
            this.ProcessMonth = processMonth;
            this.ProcessYear = processYear;
            this.MissingZCollection = missingZCollection;
            this.MissingZNoList = MissingZCollection.Select(x => x.ZNumber).ToList();
            
            this.MissingZNoListStr =
                MissingZNoList
                .Distinct()
                .OrderBy(x => x)
                .GroupAdjacentBy((x, y) => x + 1 == y)
                .Select(g => new int[] { g.First(), g.Last() }.Distinct())
                .Select(g => string.Join("-", g)).ToList();


            this.AddZNoToDepartmentEntry = new RelayCommand(x => this.ExecuteAddZNoToDepartmentEntry(x));

            var startDate = new DateTime(ProcessYear, ProcessMonth, 1);
            var endDate = new DateTime(ProcessYear, ProcessMonth, DateTime.DaysInMonth(ProcessYear, ProcessMonth));

            //Load data here
            var db = new ZentegreDBContext();

            var depts = db.ZDepartments().Where(x =>
                                            x.CashRegisterSerialNumber == OKCSerial &&
                                            x.ZDateTime >= startDate &&
                                            x.ZDateTime <= endDate).
                                            Select(x => x.DepartmentName).Distinct().ToList();

            this.DepartmentsByOKCSerial = new ObservableCollection<string>(depts);

            this.MonthtlyMissingReports = new MonthtlyMissingReports();

            /******************************************
             The following code in the ctor successfully binds the datagrid and makes department columns editable, 
             which will also make a re-calculation for total of departments on changes (works by hitting ENTER after cell changes for now)

              */

            var mrvm = new MissingRowViewModel();
            mrvm.CashTotal = 0;
            mrvm.CreditTotal = 0;
            mrvm.Zno = 251;
            mrvm.TotalOfDepartments = 0;
            mrvm.OKCNO = "Serial 1";
            mrvm.DepartmentList.Add(new DepartmentViewModel(mrvm) { Name = "Department 1", Total = 0 });
            mrvm.DepartmentList.Add(new DepartmentViewModel(mrvm) { Name = "Department 2", Total = 0 });
                        
            

            var mrvm2 = new MissingRowViewModel();
            mrvm2.CashTotal = 0;
            mrvm2.CreditTotal = 0;
            mrvm2.Zno = 252;
            mrvm2.TotalOfDepartments = 0;
            mrvm2.OKCNO = "Serial 1";
            mrvm2.DepartmentList.Add(new DepartmentViewModel(mrvm2) { Name = "Department 1", Total = 0 });
            mrvm2.DepartmentList.Add(new DepartmentViewModel(mrvm2) { Name = "Department 2", Total = 0 });

            this.MonthtlyMissingReports.Add(mrvm);
            this.MonthtlyMissingReports.Add(mrvm2);

            /******************************************/
        }

        private int taxpayerId;
        private string OKCSerial;
        private int ProcessMonth;
        private int ProcessYear;

        public ObservableCollection<ZReportDataCheckModel> MissingZCollection { get; set; }

        public ObservableCollection<string> DepartmentsByOKCSerial { get; private set; }
        public List<int> MissingZNoList { get; set; }
        public List<string> MissingZNoListStr { get; set; }

        private MonthtlyMissingReports monthtlyMissingReports;
        public MonthtlyMissingReports MonthtlyMissingReports
        {
            get { return monthtlyMissingReports; }
            set
            {
                if (monthtlyMissingReports != value)
                {
                    monthtlyMissingReports = value;
                    OnPropertyChanged(nameof(MonthtlyMissingReports));
                }
            }
        }

        private int? selectedZReportNumber { get; set; }
        public int? SelectedZReportNumber
        {
            get { return selectedZReportNumber; }
            set
            {
                if (selectedZReportNumber != value)
                {
                    selectedZReportNumber = value;
                    OnPropertyChanged(nameof(SelectedZReportNumber));
                    SelectedZReporDate = MissingZCollection.First(x => x.ZNumber == SelectedZReportNumber)?.ZDateTime;
                }
            }
        }
        private string selectedZReportNumberStr { get; set; }
        public string SelectedZReportNumberStr
        {
            get { return selectedZReportNumberStr; }
            set
            {
                if (selectedZReportNumberStr != value)
                {
                    selectedZReportNumberStr = value;
                    OnPropertyChanged(nameof(SelectedZReportNumberStr));
                    SelectedZReportNumber = Convert.ToInt32(string.Concat(SelectedZReportNumberStr.TakeWhile((c) => c != '-')));
                }
            }
        }
        private DateTime? selectedZReporDate = null;
        public DateTime? SelectedZReporDate
        {
            get
            {
                return selectedZReporDate;
            }
            set
            {
                selectedZReporDate = value;
                OnPropertyChanged(nameof(SelectedZReporDate));
            }
        }




        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Methods

        public void ExecuteAddZNoToDepartmentEntry(object param)
        {

            //Some validation here, please ignore or fiddle as you wish

            //if (SelectedZReportNumber == null)
            //{
            //    MessageBoxService.ShowMessage("Eksik Z-Raporu No seçiniz.", "Hata", MessageType.Error);
            //    return;
            //}

            //if (SelectedZReporDate == null)
            //{
            //    MessageBoxService.ShowMessage("Z Raporu Tarihi boş olamaz.", "Hata", MessageType.Error);
            //    return;
            //}



            if (SelectedZReportNumberStr.Contains("-"))
            {
                //TO DO, adding consecutive zno rows
                //Not implemented yet! And not the case of the problem. So please ignore too.
                //I just put it here for better understanding of the whole process
                return;
            }
            else
            {
                /************************************************************************
                 When the binding works as it below, the datagrid structure does not work as intended
                 
                UNCOMMENT THE NEXT BLOCK TO SEE HOW IT IS!!!
                
             */



                /*
                var selectedZNo = SelectedZReportNumber.Value;
                var mrvm = new MissingRowViewModel();
                mrvm.CashTotal = 0;
                mrvm.CreditTotal = 0;

                var depts = new ObservableCollection<DepartmentViewModel>();

                foreach (string deptName in DepartmentsByOKCSerial)
                {
                    depts.Add(new DepartmentViewModel(mrvm) { Name = deptName, Total = 0 });
                }

                mrvm.DepartmentList = depts;
                mrvm.OKCNO = "asd";
                mrvm.TotalOfDepartments = 0;
                mrvm.Zno = selectedZNo;

                this.MonthtlyMissingReports.Add(mrvm);
                

                */
                
            }
        }

        #endregion

        #region Commands

        public ICommand AddZNoToDepartmentEntry { get; }


        #endregion
    }
}
