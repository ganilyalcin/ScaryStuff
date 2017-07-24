using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ScaryStuff.ViewModel
{
    public class MonthtlyMissingReports : ObservableCollection<MissingRowViewModel>, ITypedList
    {
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (Count > 0)
            {
                return TypeDescriptor.GetProperties(this[0]);
            }
            else
            {
                return TypeDescriptor.GetProperties(typeof(MissingRowViewModel));
            }
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "MonthtlyMissingReports";
        }
    }
}
