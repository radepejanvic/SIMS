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
    public class RoomDefusingRenovationService : IRoomDefusingRenovationService
    {
        private IRoomDefusingRenovationRepository _crud;

        public RoomDefusingRenovationService(IRoomDefusingRenovationRepository crud)
        {
            _crud = crud;
        }
        public void Add(RoomDefusingRenovation roomDefusingRenovation)
        {
            _crud.Add(roomDefusingRenovation);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public RoomDefusingRenovation Get(int id)
        {
            return _crud.Get(id);
        }

        public IEnumerable<RoomDefusingRenovation> GetAll()
        {
            return _crud.GetAll();
        }
        public List<RoomDefusingRenovation> GetUnfinishedRoomDefusingRenovation()
        {
            return _crud.GetUnfinishedRoomDefusingRenovation();
        }

        public bool CheckAvailability(int id)
        {
            return _crud.CheckAvailability(id);
        }
        public void UpdateCompletedRoomDefusingRenovation(List<RoomDefusingRenovation> roomDefusingRenovations)
        {
            foreach (var item in roomDefusingRenovations)
            {
                var request = _crud.Get(item.Id);
                request.SetRequestComplete();
                _crud.Update(request);
            }
        }
    }
}
