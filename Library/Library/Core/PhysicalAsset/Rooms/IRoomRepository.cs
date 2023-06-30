using System.Collections.Generic;
using Library.Model;
using Library.Model.Enum;

namespace Library.Repository.Interface
{
    public interface IRoomRepository
    {
        void Add(Room room);
        void AddNewRoom(int id, RoomType roomType);
        Room Get(int id);
        IEnumerable<Room> GetAll();
        Dictionary<int, Room> GetAll(RoomType roomType);
        IEnumerable<DynamicalEquipment> GetDepletingDynamicalEquipment();
        List<StaticEquipment> GetEquipmentWithQuantity(IEnumerable<Room> rooms);
        void Remove(int id);
        void Update(Room room);
    }
}