using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;

namespace Library.ViewModel.Structure
{
    public class DynamicalEquipmentViewModel:EquipmentViewModel
    {
        private readonly DynamicalEquipment _dynamicalEquipment;

        public DynamicalEquipmentType Type => _dynamicalEquipment.Type; 

        public DynamicalEquipmentViewModel(DynamicalEquipment dynamicalEquipment) : base(dynamicalEquipment)
        {
            _dynamicalEquipment = dynamicalEquipment;
        }
    }
}
