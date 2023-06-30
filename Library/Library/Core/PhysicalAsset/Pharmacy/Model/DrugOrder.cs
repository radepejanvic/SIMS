using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public class DrugOrder : ISerializable
    {
        public int Id { get; set; }
        public int DrugId;
        public int OrderQuantity;
        public bool IsFinished;
        public DateTime RestockingDate;

        public DrugOrder()
        {
            
        }

        public DrugOrder(int drugId, int orderQuantity)
        {
            DrugId = drugId;
            OrderQuantity = orderQuantity;
            IsFinished = false;
            RestockingDate = DateTime.Now.AddDays(1);
        }

        public void Finish()
        {
            IsFinished = true;
        }
    }
}
