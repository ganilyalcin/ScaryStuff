using System.ComponentModel;

namespace ScaryStuff.ViewModel
{
    public class DepartmentViewModel : INotifyPropertyChanged
    {
        public MissingRowViewModel ParentVm { get; }


        public DepartmentViewModel(MissingRowViewModel parentVm)
        {
            ParentVm = parentVm;
        }
        public string Name { get; set; }

        private decimal total;

        public decimal Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                    OnPropertyChanged(nameof(Total));

                    ParentVm.GetSum();


                }
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}