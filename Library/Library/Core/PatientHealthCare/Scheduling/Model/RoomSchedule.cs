using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class RoomSchedule : Scheduler
    {
        public RoomSchedule()
        {
        }

        public RoomSchedule(int id, Dictionary<DateOnly, List<TimeSlot>> freeTimeSlots, Dictionary<DateOnly, List<int>> appointments) : base(id, freeTimeSlots, appointments)
        {
        }
    }
}
