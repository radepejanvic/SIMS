using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;

namespace Library.ViewModel
{
    public class RoomViewModel : ViewModelBase
    {
        private readonly Room _room;

        public int RoomID => _room.Id;

        public RoomType RoomType => _room.RoomType;

        public string RoomIDandType => $"{_room.Id} {_room.RoomType}";

        public RoomViewModel(Room room)
        {
            _room = room;
        }
    }
}
