using System.Collections.Generic;
using Library.Model;
using Library.Model.Enum;
using Library.ViewModel.Structure;

namespace Library.Service.PhysicalAssetService.Interface
{
    public interface IEquipmentService
    {
        IEnumerable<DynamicalEquipment> GetDepletingDynamicalEquipment();
        IEnumerable<EquipmentRedistributionViewModel> GetEquipmentRedistributions();
        IEnumerable<StaticEquipmentRedistributionViewModel> GetStaticEquipmentRedistributions();
        List<DynamicalEquipmentRequest> GetUnfinishedDynamicalEquipmentRequests();
        void MakeDynamicalEquipmentRequest(DynamicalEquipmentType type, int requestedQuantity);
        void TransferDynamicalEquipment(EquipmentRedistributionViewModel selectedElementFrom, EquipmentRedistributionViewModel selectedElementTo, int transferQuantity);
        bool TransferStaticEquipment(StaticEquipmentRedistributionViewModel selectedFrom, StaticEquipmentRedistributionViewModel selectedTo, int transferQuantity);
        void UpdateCompletedEquipmentRequests(List<DynamicalEquipmentRequest> dynamicalEquipmentRequests);
        void UpdateDynamicalEquipmentBook(DynamicalEquipmentRequest x);
    }
}