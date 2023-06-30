using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.HospitalTreatmentService.Interface;
using Library.ViewModel.Table;

namespace Library.Commands.HospitalTreatment
{
    public class StartHospitalTreatmentCommand : CommandBase
    {
        private HospitalTreatmentRoomsTableViewModel _hospitalTreatmentRoomsViewModel;
        private readonly IHospitalTreatmentService _hospitalTreatmentService;

        public StartHospitalTreatmentCommand(HospitalTreatmentRoomsTableViewModel hospitalTreatmentRoomsViewModel, IHospitalTreatmentService hospitalTreatmentService)
        {
            _hospitalTreatmentRoomsViewModel = hospitalTreatmentRoomsViewModel;
            _hospitalTreatmentService = hospitalTreatmentService;
            _hospitalTreatmentRoomsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _hospitalTreatmentRoomsViewModel.SelectedRoom is not null &&
                !_hospitalTreatmentService.IsPlaced(_hospitalTreatmentRoomsViewModel.SelectedHospitalRefferal.PatientId);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _hospitalTreatmentService.StartHospitaltreatment(_hospitalTreatmentRoomsViewModel.SelectedHospitalRefferal.Id, _hospitalTreatmentRoomsViewModel.SelectedRoom.RoomID);
                OnExecutionCompleted(true, "Bolničko lečenje je uspešno započeto.");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom prijave na bolničko lečenje.");
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_hospitalTreatmentRoomsViewModel.SelectedRoom))
            {
                OnCanExecutedChanged();
            }

        }
    }
}
