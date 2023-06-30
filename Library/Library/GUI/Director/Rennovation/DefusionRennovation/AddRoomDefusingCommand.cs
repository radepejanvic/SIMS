using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Model;
using Library.Service.PhysicalAssetService.Interface;
using Library.View.Form;
using Library.ViewModel.Form;
using System.ComponentModel;

namespace Library.Commands
{
    public class AddRoomDefusingCommand : CommandBase
    {
        private IRenovationService _renovationService;
        private DateTime _now;
        private RoomDefusingRenovationFormViewModel _roomDefusingRenovationFormViewModel;
        private RoomDefusingRenovationFormView _roomDefusingRenovationFormView;

        public AddRoomDefusingCommand(IRenovationService renovationService, RoomDefusingRenovationFormViewModel roomDefusingRenovationFormViewModel,
            RoomDefusingRenovationFormView roomDefusingRenovationFormView) 
        {
            _roomDefusingRenovationFormView = roomDefusingRenovationFormView;
            _roomDefusingRenovationFormViewModel = roomDefusingRenovationFormViewModel;
            _roomDefusingRenovationFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _renovationService = renovationService;
            _now = DateTime.Now.Date;
        }


        public override bool CanExecute(object? parameter)
        {
            return (_roomDefusingRenovationFormViewModel.SelectedRoom is not null) &&
                     (_roomDefusingRenovationFormViewModel.CheckAvailability(_roomDefusingRenovationFormViewModel.RoomID)) &&
                     (_roomDefusingRenovationFormViewModel.End != _now) &&
                     (_roomDefusingRenovationFormViewModel.Begin >= _now) &&
                     (_roomDefusingRenovationFormViewModel.Begin < _roomDefusingRenovationFormViewModel.End) &&
                     (_renovationService.CheckAvailability(_roomDefusingRenovationFormViewModel.RoomID));
        }
        public override void Execute(object? parameter)
        {

            _renovationService.Add(new RoomDefusingRenovation(_roomDefusingRenovationFormViewModel.RoomID, _roomDefusingRenovationFormViewModel.SelectedSecondType, _roomDefusingRenovationFormViewModel.SelectedType, _roomDefusingRenovationFormViewModel.RoomID
                , _roomDefusingRenovationFormViewModel.Begin, _roomDefusingRenovationFormViewModel.End));
            _roomDefusingRenovationFormView.Close();

        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_roomDefusingRenovationFormViewModel.Begin) ||
                e.PropertyName == nameof(_roomDefusingRenovationFormViewModel.End) ||
                e.PropertyName == nameof(_roomDefusingRenovationFormViewModel.SelectedType) ||
                e.PropertyName == nameof(_roomDefusingRenovationFormViewModel.SelectedSecondType) ||
                e.PropertyName == nameof(_roomDefusingRenovationFormViewModel.SelectedRoom))
            {
                OnCanExecutedChanged();
            }
        }

    }
}
