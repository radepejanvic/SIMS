using System.Collections;
using System.Collections.Generic;
using Library.Model;
using Library.Model.Enum;
using Library.ViewModel.Structure;

namespace Library.Service.PhysicalAssetService.Interface
{
    public interface IRoomService
    {
        void Add(Room room);
        void AddNewRoom(int id, RoomType roomType);
        Room Get(int id);
        IEnumerable<Room> GetAll();
        Dictionary<int, Room> GetAll(RoomType roomType);
        IEnumerable<DynamicalEquipment> GetDepletingDynamicalEquipment();
        IEnumerable<StaticEquipment> GetEquipmentWithQuantity(IEnumerable<Room> rooms);
        void MoveAllEquipmentToWarehouse(int fromRoom);
        void Remove(int id);
        void TransferDynamicalEquipment(EquipmentRedistributionViewModel selectedElementFrom, EquipmentRedistributionViewModel selectedElementTo, int transferQuantity);
        bool TransferStaticEquipment(StaticEquipmentRedistributionViewModel selectedElementFrom, StaticEquipmentRedistributionViewModel selectedElementTo, int transferQuantity);
        void UpdateDynamicalEquipmentBook(DynamicalEquipmentRequest _dynamicalEquipmentRequest);
        IEnumerable<StaticEquipment> UpdateEquipment(List<RoomType> roomTypes, List<EquipmentPurpose> equipmentPurposes, string search);
        void UpdateRoomType(int id, RoomType roomType);
    }
}