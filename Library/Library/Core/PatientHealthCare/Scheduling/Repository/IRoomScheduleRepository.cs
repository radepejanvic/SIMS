using System;
using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IRoomScheduleRepository
    {
        void Add(RoomSchedule roomSchedule);
        bool CheckAvailability(DateTime begin, DateTime end, int id);
        RoomSchedule Get(int id);
        IEnumerable<RoomSchedule> GetAll();
        void Remove(int id);
        void Update(RoomSchedule roomSchedule);
    }
}