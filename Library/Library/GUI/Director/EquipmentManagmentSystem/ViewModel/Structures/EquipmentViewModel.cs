using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Model;

namespace Library.ViewModel.Structure
{
    public class EquipmentViewModel:ViewModelBase
    {
        private readonly Equipment _equipment;

        public int Quantity => _equipment.Quantity;
        public EquipmentViewModel(Equipment equipment)
        {
            _equipment = equipment;
        }
    }
}
