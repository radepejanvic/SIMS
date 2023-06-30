using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class RoomRenovationFormViewModel : ViewModelBase
    {
        private ObservableCollection<RoomViewModel> _rooms;
        public ObservableCollection<RoomViewModel> Rooms
        {
            get
            {
                return _rooms;
            }
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms));
            }
        }
        private DateTime _begin;
        public DateTime Begin
        {
            get
            {
                return _begin;
            }
            set
            {
                _begin = value;
                OnPropertyChanged(nameof(Begin));
            }
        }
        private DateTime _end;
        public DateTime End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
                OnPropertyChanged(nameof(End));
            }
        }
        private RoomType _selectedType;
        public RoomType SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }
        private RoomViewModel _selectedRoom;
        public RoomViewModel SelectedRoom
        {
            get
            {
                return _selectedRoom;
            }
            set
            {
                _selectedRoom = value;
                RoomID = value.RoomID;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }
        public int RoomID { get; set; }
        public ObservableCollection<RoomType> Types { get; set; }
        public ICommand AddRoomRenovationCommand {get;}
        protected IRoomScheduleService _roomScheduleService;

        public RoomRenovationFormViewModel(IRoomService roomService, IRenovationService renovationService, IRoomScheduleService roomScheduleService, RoomRenovationFormView roomRenovationFormView)
        {
            _roomScheduleService = roomScheduleService;
			var roomViewModels = roomService.GetAll().Select(o => new RoomViewModel(o)).Where(o=>o.RoomType != RoomType.WAREHOUSE).ToList();
			_rooms = new ObservableCollection<RoomViewModel>(roomViewModels);
            
            
            var allTypes = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
            Types = new ObservableCollection<RoomType>(allTypes);
            
            AddRoomRenovationCommand = new AddRoomRenovationCommand(renovationService, this,roomRenovationFormView);
            Begin = DateTime.Now.Date;
            End = DateTime.Now.Date;

        }
        public RoomRenovationFormViewModel(IRoomService roomService, IRenovationService renovationService, IRoomScheduleService roomScheduleService)
        {
            _roomScheduleService = roomScheduleService;
            var roomViewModels = roomService.GetAll().Select(o => new RoomViewModel(o)).Where(o => o.RoomType != RoomType.WAREHOUSE).ToList();
            _rooms = new ObservableCollection<RoomViewModel>(roomViewModels);


            var allTypes = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
            Types = new ObservableCollection<RoomType>(allTypes);

            Begin = DateTime.Now.Date;
            End = DateTime.Now.Date;

        }

        public virtual bool CheckAvailability(int id)
        {
            if (SelectedRoom.RoomType == RoomType.OPERATION_ROOM || SelectedRoom.RoomType == RoomType.EXAMINATION_ROOM)
            {
                return _roomScheduleService.CheckAvailability(Begin, End, id);
            }
            return true;
        }

    }
}
