using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Serializer;

namespace Library.Model
{
    public class DynamicalEquipmentRequest : DynamicalEquipment,ISerializable
    {
        public DateTime RequestExecutionTimeframe;
        public bool RequestCompletionStatus;
        public int Id { get; set; }
        public DynamicalEquipmentRequest(){}
        public DynamicalEquipmentRequest(DynamicalEquipmentType dynamicalEquipmentType, int quantity) : base(dynamicalEquipmentType, quantity)
        {
            RequestExecutionTimeframe = DateTime.UtcNow.AddDays(1);
            RequestCompletionStatus = false;
            Id = 1;
        }

        public bool IsRequestCompleted()
        {
            return RequestCompletionStatus;
        }
        public bool IsTimeLessThanNow()
        {
            return RequestExecutionTimeframe < DateTime.Now;
        }
        public void SetRequestComplete()
        {
            RequestCompletionStatus = true;
        }
    }
}
