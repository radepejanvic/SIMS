using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.PhysicalAssetService.Interface;
using Library.Repository.Interface;

namespace Library.Service.PhysicalAssetService
{
    public class RoomRenovationService : IRoomRenovationService
    {
        private IRoomRenovationRepository _crud;

        public RoomRenovationService(IRoomRenovationRepository crud)
        {
            _crud = crud;
        }
        public void Add(RoomRenovation roomRenovation)
        {
            _crud.Add(roomRenovation);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public RoomRenovation Get(int id)
        {
            return _crud.Get(id);
        }

        public IEnumerable<RoomRenovation> GetAll()
        {
            return _crud.GetAll();
        }
        public List<RoomRenovation> GetUnfinishedRoomRenovation()
        {
            return _crud.GetUnfinishedRoomRenovation();
        }

        public bool CheckAvailability(int id)
        {
            return _crud.CheckAvailability(id);
        }
        public void UpdateCompletedRoomRenovation(List<RoomRenovation> roomRenovations)
        {
            foreach (var item in roomRenovations)
            {
                var request = _crud.Get(item.Id);
                request.SetRequestComplete();
                _crud.Update(request);
            }
        }
    }
}
