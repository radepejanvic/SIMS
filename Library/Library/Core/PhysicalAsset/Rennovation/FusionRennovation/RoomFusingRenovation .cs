using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;

namespace Library.Model
{
    public class RoomFusingRenovation : RoomRenovation
    {
        public int SecondRoomID;

        public RoomFusingRenovation()
        {
        }

        public RoomFusingRenovation(int id, RoomType endType, int roomID, int secondRoomID, DateTime begin, DateTime end) : base(id, endType, roomID, begin, end)
        {
            SecondRoomID = secondRoomID;
        }
    }
}
