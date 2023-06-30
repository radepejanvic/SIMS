using System.Collections.Generic;
using Library.Model;
using Library.Model.Enum;

namespace Library.Repository.Interface
{
    public interface IDynamicalEquipmentRequestRepository
    {
        DynamicalEquipmentRequest Get(int id);
        List<DynamicalEquipmentRequest> GetUnfinishedDynamicalEquipmentRequests();
        void Add(DynamicalEquipmentRequest dynamicalEquipmentRequest);
        void Update(DynamicalEquipmentRequest dynamicalEquipmentRequest);
    }
}