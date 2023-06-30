using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model.Enum;
using Library.Service.PhysicalAssetService;
using Library.Service.PhysicalAssetService.Interface;
using Library.View.Form;

namespace Library.ViewModel.Form
{
    public class RoomFusingRenovationFormViewModel : RoomRenovationFormViewModel
    {
        private RoomViewModel _selectedSecondRoomdRoom;
        public RoomViewModel SelectedSecondRoom
        {
            get
            {
                return _selectedSecondRoomdRoom;
            }
            set
            {
                _selectedSecondRoomdRoom = value;
                SecondRoomID = value.RoomID;
                OnPropertyChanged(nameof(SelectedSecondRoom));
            }
        }
        public int SecondRoomID { get; set; }
        public ICommand AddRoomFusingCommand { get; }
        private IRoomService _roomService;

        public RoomFusingRenovationFormViewModel(IRoomService roomService, IRenovationService renovationService, IRoomScheduleService roomScheduleService, RoomFusingRenovationFormView roomFusingRenovationFormView) : base(roomService, renovationService, roomScheduleService)
        {
            AddRoomFusingCommand = new AddRoomFusingCommand(renovationService, this, roomFusingRenovationFormView);
            _roomService = roomService;
        }
        public override bool CheckAvailability(int id)
        {
            var type = _roomService.Get(id).RoomType;
            if (type == RoomType.OPERATION_ROOM || type == RoomType.EXAMINATION_ROOM )
            {
                return _roomScheduleService.CheckAvailability(Begin, End, id);
            }
            return true;
        }
    }
}
