using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model.Enum;
using Library.Service.PhysicalAssetService.Interface;
using Library.View.Form;

namespace Library.ViewModel.Form
{
    public class RoomDefusingRenovationFormViewModel : RoomRenovationFormViewModel
    {
        private RoomType _selectedSecondType;
        public RoomType SelectedSecondType
        {
            get
            {
                return _selectedSecondType;
            }
            set
            {
                _selectedSecondType = value;
                OnPropertyChanged(nameof(SelectedSecondType));
            }
        }
        public ICommand AddRoomDefusingCommand { get; }

        public RoomDefusingRenovationFormViewModel(IRoomService roomService, IRenovationService renovationService, IRoomScheduleService roomScheduleService, RoomDefusingRenovationFormView roomDefusingRenovationFormView) : base(roomService, renovationService, roomScheduleService)
        {
            AddRoomDefusingCommand = new AddRoomDefusingCommand(renovationService, this, roomDefusingRenovationFormView);
        }
    }
}
