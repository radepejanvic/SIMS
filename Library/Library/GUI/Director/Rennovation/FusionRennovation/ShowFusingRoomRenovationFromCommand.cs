using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.PhysicalAssetService.Interface;
using Library.View.Form;
using Library.ViewModel.Form;

namespace Library.Commands
{
    public class ShowFusingRoomRenovationFromCommand : ShowRoomRenovationFormCommand
    {


        public ShowFusingRoomRenovationFromCommand(IRoomService roomService, IRenovationService renovationService, IRoomScheduleService roomScheduleService) : base(roomService, renovationService, roomScheduleService)
        {
        }

        public override void Execute(object? parameter)
        {
            var roomFusingRenovationFormView = new RoomFusingRenovationFormView();
            roomFusingRenovationFormView.DataContext = new RoomFusingRenovationFormViewModel(_roomService, _renovationService, _roomScheduleService, roomFusingRenovationFormView);
            roomFusingRenovationFormView.Show();
        }
    }
}
