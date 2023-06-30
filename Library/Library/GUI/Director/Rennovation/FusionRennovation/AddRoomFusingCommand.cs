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
    public class AddRoomFusingCommand : CommandBase
    {
        private IRenovationService _renovationService;
        private DateTime _now;
        private RoomFusingRenovationFormView _fusingRenovationFormView;
        private RoomFusingRenovationFormViewModel _fusingRenovationFormViewModel;
        public AddRoomFusingCommand(IRenovationService renovationService, RoomFusingRenovationFormViewModel fusingRenovationFormViewModel, RoomFusingRenovationFormView fusingRenovationFormView) 
        {
            _fusingRenovationFormView = fusingRenovationFormView;
            _fusingRenovationFormViewModel = fusingRenovationFormViewModel;
            _fusingRenovationFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _now = DateTime.Now.Date;
            _renovationService = renovationService;
        }


        public override bool CanExecute(object? parameter)
        {
            return (_fusingRenovationFormViewModel.SelectedRoom is not null) &&
                     (_fusingRenovationFormViewModel.SelectedSecondRoom is not null) &&
                     (_fusingRenovationFormViewModel.CheckAvailability(_fusingRenovationFormViewModel.RoomID)) &&
                     (_fusingRenovationFormViewModel.CheckAvailability(_fusingRenovationFormViewModel.SecondRoomID)) &&
                     (_fusingRenovationFormViewModel.RoomID != _fusingRenovationFormViewModel.SecondRoomID) &&
                     (_fusingRenovationFormViewModel.End != _now) &&
                     (_fusingRenovationFormViewModel.Begin >= _now) &&
                     (_fusingRenovationFormViewModel.Begin < _fusingRenovationFormViewModel.End) &&
                     (_renovationService.CheckAvailability(_fusingRenovationFormViewModel.RoomID)) &&
                     (_renovationService.CheckAvailability(_fusingRenovationFormViewModel.SecondRoomID));
            
        }
        public override void Execute(object? parameter)
        {

            _renovationService.Add(new RoomFusingRenovation(_fusingRenovationFormViewModel.RoomID, _fusingRenovationFormViewModel.SelectedType, _fusingRenovationFormViewModel.RoomID,
                _fusingRenovationFormViewModel.SecondRoomID,_fusingRenovationFormViewModel.Begin, _fusingRenovationFormViewModel.End));
            _fusingRenovationFormView.Close();

        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_fusingRenovationFormViewModel.Begin) ||
                e.PropertyName == nameof(_fusingRenovationFormViewModel.End) ||
                e.PropertyName == nameof(_fusingRenovationFormViewModel.SelectedType) ||
                e.PropertyName == nameof(_fusingRenovationFormViewModel.SelectedSecondRoom) ||
                e.PropertyName == nameof(_fusingRenovationFormViewModel.SelectedRoom))
            {
                OnCanExecutedChanged();
            }
        }

    }
}
