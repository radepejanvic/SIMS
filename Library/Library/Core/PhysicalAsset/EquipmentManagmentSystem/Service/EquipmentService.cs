using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;
using Library.Repository.Interface;
using Library.Service.PhysicalAssetService.Interface;
using Library.ViewModel.Structure;

namespace Library.Service.PhysicalAssetService
{
    public class EquipmentService : IEquipmentService
    {
        private IDynamicalEquipmentRequestRepository _crud;
        private IRoomService _roomService;

        public EquipmentService(IDynamicalEquipmentRequestRepository dynamicalEquipmentRequestRepository, IRoomService roomService)
        {
            _crud = dynamicalEquipmentRequestRepository;
            _roomService = roomService;
        }

        public IEnumerable<DynamicalEquipment> GetDepletingDynamicalEquipment()
        {
            return _roomService.GetDepletingDynamicalEquipment();

        }

        public void MakeDynamicalEquipmentRequest(DynamicalEquipmentType type, int requestedQuantity)
        {
            _crud.Add(new DynamicalEquipmentRequest(type, requestedQuantity));
        }

        public IEnumerable<EquipmentRedistributionViewModel> GetEquipmentRedistributions()
        {

            return _roomService.GetAll().SelectMany(room => room.DynamicalEquipmentBook
                .Select(equipment => new EquipmentRedistributionViewModel(
                    equipment.Quantity,
                    equipment.Type.ToString(),
                    room.RoomID,
                    room.RoomType.ToString())))
                .ToList();
        }
        public IEnumerable<StaticEquipmentRedistributionViewModel> GetStaticEquipmentRedistributions()
        {

            return _roomService.GetAll().SelectMany(room => room.StaticEquipmentBook
                .Select(equipment => new StaticEquipmentRedistributionViewModel(
                    equipment.Quantity,
                    equipment.Type.ToString(),
                    room.RoomID,
                    room.RoomType.ToString(),
                    equipment.Purpose)))
                .ToList();
        }

        public void TransferDynamicalEquipment(EquipmentRedistributionViewModel selectedElementFrom, EquipmentRedistributionViewModel selectedElementTo, int transferQuantity)
        {
            _roomService.TransferDynamicalEquipment(selectedElementFrom, selectedElementTo, transferQuantity);
        }
        public bool TransferStaticEquipment(StaticEquipmentRedistributionViewModel selectedFrom, StaticEquipmentRedistributionViewModel selectedTo, int transferQuantity)
        {
            return _roomService.TransferStaticEquipment(selectedFrom, selectedTo, transferQuantity);
        }
        public List<DynamicalEquipmentRequest> GetUnfinishedDynamicalEquipmentRequests()
        {
            return _crud.GetUnfinishedDynamicalEquipmentRequests();
        }
        public void UpdateCompletedEquipmentRequests(List<DynamicalEquipmentRequest> dynamicalEquipmentRequests)
        {
            foreach (var item in dynamicalEquipmentRequests)
            {
                var request = _crud.Get(item.Id);
                request.SetRequestComplete();
                _crud.Update(request);
            }
        }
        public void UpdateDynamicalEquipmentBook(DynamicalEquipmentRequest x)
        {
            _roomService.UpdateDynamicalEquipmentBook(x);

        }
    }
}
