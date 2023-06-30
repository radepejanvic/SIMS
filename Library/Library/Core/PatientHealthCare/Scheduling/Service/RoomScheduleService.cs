using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.PhysicalAssetService.Interface;

namespace Library.Service.PhysicalAssetService
{
    public class RoomScheduleService : IRoomScheduleService
    {
        private IRoomScheduleRepository _crud;

        public RoomScheduleService(IRoomScheduleRepository crud)
        {
            _crud = crud;
        }
        public void Add(RoomSchedule roomSchedule)
        {
            _crud.Add(roomSchedule);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public void Update(RoomSchedule roomSchedule)
        {
            _crud.Update(roomSchedule);
        }
        public RoomSchedule Get(int id)
        {
            return _crud.Get(id);
        }

        public IEnumerable<RoomSchedule> GetAll()
        {
            return _crud.GetAll();
        }
        public bool CheckAvailability(DateTime begin, DateTime end, int id)
        {
            return _crud.CheckAvailability(begin, end, id);
        }
    }
}
