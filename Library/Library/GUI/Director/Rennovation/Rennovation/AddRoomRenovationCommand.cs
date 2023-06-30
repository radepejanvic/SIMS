using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Service.PhysicalAssetService.Interface;
using Library.ViewModel.Form;
using Library.Model;
using Library.View.Form;
using System.Security.AccessControl;
using Library.Model.Enum;

namespace Library.Commands
{
    public class AddRoomRenovationCommand : CommandBase
    {
        private IRenovationService _renovationService;
        private RoomRenovationFormViewModel _roomRenovationFormViewModel;
        private DateTime _now;
        private RoomRenovationFormView _roomRenovationView;
        


        public AddRoomRenovationCommand(IRenovationService renovationService, RoomRenovationFormViewModel roomRenovationFormViewModel, RoomRenovationFormView roomRenovationFormView)
        {
            _renovationService = renovationService;
            _roomRenovationFormViewModel = roomRenovationFormViewModel;
            _roomRenovationFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _roomRenovationView = roomRenovationFormView;
            _now = DateTime.Now.Date;

        }

        public override bool CanExecute(object? parameter)
        {
           return   (_roomRenovationFormViewModel.SelectedRoom is not null) &&
                    (_roomRenovationFormViewModel.CheckAvailability(_roomRenovationFormViewModel.RoomID))&&
                    (_roomRenovationFormViewModel.End != _now) &&
                    (_roomRenovationFormViewModel.Begin >= _now) &&
                    (_roomRenovationFormViewModel.Begin < _roomRenovationFormViewModel.End) &&
                    (_renovationService.CheckAvailability(_roomRenovationFormViewModel.RoomID));
        }
        public override void Execute(object? parameter)
        {

            _renovationService.Add(new RoomRenovation(_roomRenovationFormViewModel.RoomID,_roomRenovationFormViewModel.SelectedType,_roomRenovationFormViewModel.RoomID,
                _roomRenovationFormViewModel.Begin,_roomRenovationFormViewModel.End));
            _roomRenovationView.Close();

        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_roomRenovationFormViewModel.Begin) ||
                e.PropertyName == nameof(_roomRenovationFormViewModel.End)   ||
                e.PropertyName == nameof(_roomRenovationFormViewModel.SelectedType) ||
                e.PropertyName == nameof(_roomRenovationFormViewModel.SelectedRoom))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
