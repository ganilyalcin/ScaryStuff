using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryStuff.ViewModel
{
    class MissingRowViewModelProperty : PropertyDescriptor
    {
        int _index;
        public MissingRowViewModelProperty(string name, int index)
            : base(name, new Attribute[0])
        {
            _index = index;
        }
        public override Type ComponentType
        {
            get
            {
                return typeof(MissingRowViewModel);
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return typeof(decimal);
            }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object GetValue(object component)
        {
            MissingRowViewModel dr = component as MissingRowViewModel;
            if (dr != null && _index >= 0 && _index < dr.DepartmentList.Count)
            {
                return dr.DepartmentList[_index].Total;
            }
            else
            {
                return (decimal)0;
            }
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
            MissingRowViewModel dr = component as MissingRowViewModel;
            if (dr != null && _index >= 0 && _index < dr.DepartmentList.Count && value is decimal)
            {
                dr.DepartmentList[_index].Total = (decimal)value;
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}