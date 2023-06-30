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
    public class ShowRoomRenovationFormCommand : CommandBase
    {
        protected IRoomService _roomService;
        protected IRenovationService _renovationService;
        protected IRoomScheduleService _roomScheduleService;


        public ShowRoomRenovationFormCommand(IRoomService roomService, IRenovationService renovationService, IRoomScheduleService roomScheduleService)
        {
            _roomService = roomService;
            _renovationService = renovationService;
            _roomScheduleService = roomScheduleService;
        }

        public override void Execute(object? parameter)
        {
            var  roomRenovationFormView = new RoomRenovationFormView();
            roomRenovationFormView.DataContext = new RoomRenovationFormViewModel(_roomService, _renovationService, _roomScheduleService,roomRenovationFormView);
            roomRenovationFormView.Show();
        }
    }
}
