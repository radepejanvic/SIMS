using System;
using System.Collections.Generic;
using Library.Model;

namespace Library.Service.PhysicalAssetService.Interface
{
    public interface IRoomScheduleService
    {
        void Add(RoomSchedule roomSchedule);
        bool CheckAvailability(DateTime begin, DateTime end, int id);
        RoomSchedule Get(int id);
        IEnumerable<RoomSchedule> GetAll();
        void Remove(int id);
        void Update(RoomSchedule roomSchedule);
    }
}