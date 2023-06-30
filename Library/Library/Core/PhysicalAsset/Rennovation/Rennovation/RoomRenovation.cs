using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Library.Model.Enum;
using Library.Serializer;

namespace Library.Model
{
    public class RoomRenovation : ISerializable
    {
        public int Id { get; set; }
        public RoomType EndType;
        public bool IsFinished;
        public int RoomID;
        public DateTime Begin;
        public DateTime End;

        public RoomRenovation(){ }

        public RoomRenovation(int id, RoomType endType, int roomID, DateTime begin, DateTime end)
        {
            Id = id;
            EndType = endType;
            IsFinished = false;
            RoomID = roomID;
            Begin = begin;
            End = end;
        }

        public bool IsRequestCompleted()
        {
            return IsFinished;
        }
        public bool IsTimeLessThanNow()
        {
            return End< DateTime.Now;
        }
        public void SetRequestComplete()
        {
            IsFinished = true;
        }
    }
}
