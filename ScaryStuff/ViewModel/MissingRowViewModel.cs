using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace ScaryStuff.ViewModel
{
    public class MissingRowViewModel : ICustomTypeDescriptor, INotifyPropertyChanged
    {
        public string OKCNO { get; set; }
        public int Zno { get; set; }
        public decimal CashTotal { get; set; }
        public decimal CreditTotal { get; set; }
        private decimal totalOfDepartments;

        public decimal TotalOfDepartments
        {
            get { return totalOfDepartments; }
            set
            {
                if (totalOfDepartments != value)
                {
                    totalOfDepartments = value;
                    OnPropertyChanged(nameof(TotalOfDepartments));

                }
            }
        }

        public ObservableCollection<DepartmentViewModel> DepartmentList { get; set; }

        public MissingRowViewModel()
        {
            this.DepartmentList = new ObservableCollection<DepartmentViewModel>();

            this.DepartmentList.CollectionChanged += OnCollectionChanged;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void GetSum()
        {
            TotalOfDepartments = DepartmentList.Sum(x => x.Total);
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TotalOfDepartments = DepartmentList.Sum(x => x.Total);
        }

        public event PropertyChangedEventHandler PropertyChanged;



        public AttributeCollection GetAttributes()
        {
            throw new NotImplementedException();
        }

        public string GetClassName()
        {
            return "MissingRowViewModel";
        }

        public string GetComponentName()
        {
            return "";
        }

        public TypeConverter GetConverter()
        {
            return null;
        }

        public EventDescriptor GetDefaultEvent()
        {
            return null;
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        public object GetEditor(Type editorBaseType)
        {
            return null;
        }

        public EventDescriptorCollection GetEvents()
        {
            return null;
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return null;
        }


        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pdc0 = TypeDescriptor.GetProperties(typeof(MissingRowViewModel));
            List<PropertyDescriptor> pdList = new List<PropertyDescriptor>();
            pdList.Add(pdc0["Zno"]);
            for (int i = 0; i < DepartmentList.Count; ++i)
            {
                pdList.Add(new MissingRowViewModelProperty(DepartmentList[i].Name, i));
            }
            pdList.Add(pdc0["TotalOfDepartments"]);
            pdList.Add(pdc0["CashTotal"]);
            pdList.Add(pdc0["CreditTotal"]);
            return new PropertyDescriptorCollection(pdList.ToArray());
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
}
