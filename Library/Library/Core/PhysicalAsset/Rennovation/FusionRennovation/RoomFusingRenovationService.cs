using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.PhysicalAssetService.Interface;

namespace Library.Service.PhysicalAssetService
{
    public class RoomFusingRenovationService : IRoomFusingRenovationService
    {
        private IRoomFusingRenovationRepository _crud;

        public RoomFusingRenovationService(IRoomFusingRenovationRepository crud)
        {
            _crud = crud;
        }
        public void Add(RoomFusingRenovation roomFusingRenovation)
        {
            _crud.Add(roomFusingRenovation);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public RoomFusingRenovation Get(int id)
        {
            return _crud.Get(id);
        }

        public IEnumerable<RoomFusingRenovation> GetAll()
        {
            return _crud.GetAll();
        }
        public List<RoomFusingRenovation> GetUnfinishedRoomFusingRenovation()
        {
            return _crud.GetUnfinishedRoomFusingRenovation();
        }

        public bool CheckAvailability(int id)
        {
            return _crud.CheckAvailability(id);
        }
        public void UpdateCompletedRoomFusingRenovation(List<RoomFusingRenovation> roomFusingRenovations)
        {
            foreach (var item in roomFusingRenovations)
            {
                var request = _crud.Get(item.Id);
                request.SetRequestComplete();
                _crud.Update(request);
            }
        }
    }
}
