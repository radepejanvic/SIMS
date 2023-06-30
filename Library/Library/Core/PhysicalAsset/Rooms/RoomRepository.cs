using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Model;
using Library.Repository.Interface;
using Library.ViewModel.Structure;

namespace Library.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private ICRUDRepository<Room> _repo;

        public RoomRepository(ICRUDRepository<Room> repo)
        {
            _repo = repo;
        }

        public void Add(Room room)
        {
            _repo.Add(room);
        }

        public void AddNewRoom(int id, RoomType roomType)
        {
            var room = _repo.Get(id);
            _repo.Add(new Room(0, roomType, room.StaticEquipmentBook, room.DynamicalEquipmentBook));
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Room Get(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _repo.GetAll().Values.ToList();
        }
        public List<StaticEquipment> GetEquipmentWithQuantity(IEnumerable<Room> rooms)
        {
            var equipments = rooms.SelectMany(s => s.StaticEquipmentBook).GroupBy(o => new { o.Type, o.Purpose })
                .Select(g => new { g.Key.Type, g.Key.Purpose, Quantity = g.Sum(o => o.Quantity) }).ToList();

            List<StaticEquipment> staticEquipments = new List<StaticEquipment>();
            foreach (var o in equipments)
            {
                var equipment = new StaticEquipment(o.Type, o.Purpose, o.Quantity);
                staticEquipments.Add(equipment);
            }
            return staticEquipments;
        }

        public IEnumerable<DynamicalEquipment> GetDepletingDynamicalEquipment()
        {
            var equipment = GetAll().SelectMany(s => s.DynamicalEquipmentBook)
                      .GroupBy(o => new { o.Type })
                      .Select(g => new { g.Key.Type, Quantity = g.Sum(o => o.Quantity) })
                      .Where(e => e.Quantity <= 5)
                      .ToList();
            return equipment.Select(e => new DynamicalEquipment(e.Type, e.Quantity)).ToList();
        }
        public void Update(Room room)
        {
            _repo.Update(room);
        }

        public Dictionary<int, Room> GetAll(RoomType roomType)
        {
            return _repo.GetAll().Values
                .Where(room => room.RoomType == roomType)
                .ToDictionary(room => room.Id, room => room);
        }
    }

}
