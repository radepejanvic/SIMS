using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;
using Library.Repository.Interface;
using Library.Service.PhysicalAssetService.Interface;
using Library.ViewModel;
using Library.ViewModel.Structure;

namespace Library.Service.PhysicalAssetService
{
    public class RoomService : IRoomService
    {
        private IRoomRepository _crud;

        public RoomService(IRoomRepository crud)
        {
            _crud = crud;
        }

        public void Add(Room room)
        {
            _crud.Add(room);
        }

        public void AddNewRoom(int id,RoomType roomType)
        {
            var room = _crud.Get(id);
            _crud.Add(new Room(0, roomType, room.StaticEquipmentBook, room.DynamicalEquipmentBook));
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public Room Get(int id)
        {
            return _crud.Get(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _crud.GetAll();
        }
        public IEnumerable<StaticEquipment> GetEquipmentWithQuantity(IEnumerable<Room> rooms)
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
        public IEnumerable<StaticEquipment> UpdateEquipment(List<RoomType> roomTypes, List<EquipmentPurpose> equipmentPurposes, string search)
        {

            IEnumerable<Room> rooms = GetAll();

            IEnumerable<Room> roomResult;

            IEnumerable<StaticEquipment> filteredEquipment;
            if (roomTypes.Count != 0 && equipmentPurposes.Count != 0)
            {
                roomResult = rooms.Where(s => roomTypes.Contains(s.RoomType)).ToList();
                var staticEquipment = GetEquipmentWithQuantity(roomResult);
                filteredEquipment = staticEquipment.Where(s => equipmentPurposes.Contains(s.Purpose)).ToList();

            }
            else if (roomTypes.Count != 0)
            {
                roomResult = rooms.Where(s => roomTypes.Contains(s.RoomType)).ToList();
                filteredEquipment = GetEquipmentWithQuantity(roomResult);

            }
            else if (equipmentPurposes.Count != 0)
            {
                var staticEquipment = GetEquipmentWithQuantity(rooms);
                filteredEquipment = staticEquipment.Where(s => equipmentPurposes.Contains(s.Purpose)).ToList();

            }
            else
            {
                filteredEquipment = GetEquipmentWithQuantity(rooms);

            }

            IEnumerable<StaticEquipment> researchedEquipment;
            if (!string.IsNullOrEmpty(search))
            {
                researchedEquipment = filteredEquipment.Where(obj => obj.Purpose.ToString().ToLower().Contains(search) || obj.Quantity.ToString().ToLower().Contains(search) || obj.Type.ToString().ToLower().Contains(search)).ToList();

            }
            else
            {
                researchedEquipment = filteredEquipment;
            }
            return researchedEquipment;
        }


        public void TransferDynamicalEquipment(EquipmentRedistributionViewModel selectedElementFrom, EquipmentRedistributionViewModel selectedElementTo, int transferQuantity)
        {
            var Type = (DynamicalEquipmentType)Enum.Parse(typeof(DynamicalEquipmentType), selectedElementTo.Type);
            var sourceRoom = _crud.Get(selectedElementFrom.RoomID);
            sourceRoom.DecreaseDynamicalEquipmentQuantity(transferQuantity, Type);
            _crud.Update(sourceRoom);

            var destinationRoom = _crud.Get(selectedElementTo.RoomID);
            destinationRoom.IncreaseDynamicalEquipmentQuantity(transferQuantity, Type);
            _crud.Update(destinationRoom);

        }

        public bool TransferStaticEquipment(StaticEquipmentRedistributionViewModel selectedElementFrom, StaticEquipmentRedistributionViewModel selectedElementTo, int transferQuantity)
        {
            StaticEquipmentType type = Enum.Parse<StaticEquipmentType>(selectedElementTo.Type);
            EquipmentPurpose purpose = selectedElementTo.Purpose;
            var sourceRoom = _crud.Get(selectedElementFrom.RoomID);


            if (sourceRoom.GetStaticEquipmentQuantity(type, purpose) >= transferQuantity)
            {
                sourceRoom.DecreaseStaticEquipmentQuantity(transferQuantity, type, purpose);
                _crud.Update(sourceRoom);

                var destinationRoom = _crud.Get(selectedElementTo.RoomID);
                destinationRoom.IncreaseStaticEquipmentQuantity(transferQuantity, type, purpose);
                _crud.Update(destinationRoom);
                return true;

            }
            else
            {
                return false;
            }

        }

        public void UpdateDynamicalEquipmentBook(DynamicalEquipmentRequest _dynamicalEquipmentRequest)
        {
            var warehouse = GetAll().Where(o => o.RoomType == RoomType.WAREHOUSE).ToList()[0];
            warehouse.DynamicalEquipmentBook.Find(x => x.Type == _dynamicalEquipmentRequest.Type).Quantity += _dynamicalEquipmentRequest.Quantity;
            _crud.Update(warehouse);
        }
        public void MoveAllEquipmentToWarehouse(int fromRoom)
        {
            var room = Get(fromRoom);
            var warehouse = GetAll().Where(o => o.RoomType == RoomType.WAREHOUSE).ToList()[0];
            room.DynamicalEquipmentBook.ForEach(o => warehouse.IncreaseDynamicalEquipmentQuantity(o.Quantity, o.Type));
            room.DynamicalEquipmentBook.ForEach(o => room.DecreaseDynamicalEquipmentQuantity(o.Quantity, o.Type));

            room.StaticEquipmentBook.ForEach(o => warehouse.IncreaseStaticEquipmentQuantity(o.Quantity, o.Type));
            room.StaticEquipmentBook.ForEach(o => room.DecreaseStaticEquipmentQuantity(o.Quantity, o.Type));
            _crud.Update(warehouse);
            _crud.Update(room);
        }
        public void UpdateRoomType(int id,RoomType roomType)
        {
            var room = _crud.Get(id);
            room.RoomType = roomType;
            _crud.Update(room);
        }

        public Dictionary<int, Room> GetAll(RoomType roomType)
        {
            return _crud.GetAll(roomType);
        }
    }
}
