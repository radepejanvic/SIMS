using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;

namespace Library.Model
{
    public class RoomDefusingRenovation : RoomRenovation
    {
        public RoomType SecondEndType;

        public RoomDefusingRenovation()
        {

        }
        public RoomDefusingRenovation(int id, RoomType secondEndType,RoomType endType, int roomID, DateTime begin, DateTime end) : base(id, endType, roomID, begin, end)
        {
            SecondEndType = secondEndType;
        }
    }
}
