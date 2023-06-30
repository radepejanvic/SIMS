using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;

namespace Library.Model
{
    public class DynamicalEquipment : Equipment
    {

        public DynamicalEquipmentType Type { get; set; }
        public DynamicalEquipment(){}
        public DynamicalEquipment(DynamicalEquipmentType dynamicalEquipmentType,int quantity) : base(quantity)
        {
           Type = dynamicalEquipmentType;
        }
    }
}
