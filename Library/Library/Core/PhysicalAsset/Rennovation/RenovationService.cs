using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.PhysicalAssetService.Interface;

namespace Library.Service.PhysicalAssetService
{
    public class RenovationService : IRenovationService
    {
        private IRoomRenovationService _roomRenovationService;
        private IRoomDefusingRenovationService _defusingRenovationService;
        private IRoomFusingRenovationService _fusingRenovationService;

        public RenovationService(IRoomRenovationService roomRenovationService, IRoomDefusingRenovationService defusingRenovationService, IRoomFusingRenovationService roomFusingRenovation)
        {
            _roomRenovationService = roomRenovationService;
            _defusingRenovationService = defusingRenovationService;
            _fusingRenovationService = roomFusingRenovation;
        }
        public bool CheckAvailability(int id)
        {
            return _roomRenovationService.CheckAvailability(id) &&
                   _defusingRenovationService.CheckAvailability(id) &&
                   _fusingRenovationService.CheckAvailability(id);
        }
        public void UpdateCompletedRoomRenovation(List<RoomRenovation> roomRenovations, List<RoomFusingRenovation> roomFusingRenovations, List<RoomDefusingRenovation> roomDefusingRenovations)
        {
            _roomRenovationService.UpdateCompletedRoomRenovation(roomRenovations);
            _fusingRenovationService.UpdateCompletedRoomFusingRenovation(roomFusingRenovations);
            _defusingRenovationService.UpdateCompletedRoomDefusingRenovation(roomDefusingRenovations);
        }
        public void Add(RoomRenovation roomRenovation)
        {
            _roomRenovationService.Add(roomRenovation);
        }
        public void Add(RoomDefusingRenovation roomDefusingRenovation)
        {
            _defusingRenovationService.Add(roomDefusingRenovation);
        }
        public void Add(RoomFusingRenovation roomFusingRenovation)
        {
            _fusingRenovationService.Add(roomFusingRenovation);
        }
        public void ProcessRoomRenovation(IRoomService roomService)
        {
            List<RoomRenovation> roomRenovations = _roomRenovationService.GetUnfinishedRoomRenovation();
            roomRenovations.ForEach(roomRenovation => roomService.UpdateRoomType(roomRenovation.RoomID, roomRenovation.EndType));
            _roomRenovationService.UpdateCompletedRoomRenovation(roomRenovations);
        }
        public void ProcessRoomFusingRenovation(IRoomService roomService)
        {
            List<RoomFusingRenovation> roomRenovations = _fusingRenovationService.GetUnfinishedRoomFusingRenovation();
            foreach (var roomRenovation in roomRenovations)
            {
                roomService.UpdateRoomType(roomRenovation.RoomID, roomRenovation.EndType);
                roomService.MoveAllEquipmentToWarehouse(roomRenovation.SecondRoomID);
                roomService.Remove(roomRenovation.SecondRoomID);
            }
            _fusingRenovationService.UpdateCompletedRoomFusingRenovation(roomRenovations);

        }
        public void ProcessRoomDefusingRenovation(IRoomService roomService)
        {
            List<RoomDefusingRenovation> roomRenovations = _defusingRenovationService.GetUnfinishedRoomDefusingRenovation();
            foreach (var roomRenovation in roomRenovations)
            {
                roomService.MoveAllEquipmentToWarehouse(roomRenovation.RoomID);
                roomService.UpdateRoomType(roomRenovation.RoomID, roomRenovation.EndType);
                roomService.AddNewRoom(roomRenovation.RoomID, roomRenovation.SecondEndType);
            }
            _defusingRenovationService.UpdateCompletedRoomDefusingRenovation(roomRenovations);
        }
    }
}
