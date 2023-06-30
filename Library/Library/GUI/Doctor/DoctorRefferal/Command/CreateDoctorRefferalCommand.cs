using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Model.Refferal;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.View;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class CreateDoctorRefferalCommand: CommandBase
    {
        private DoctorRefferalFormViewModel _doctorRefferalFormViewModel;
        private Appointment _appointment;
        private IDoctorRefferalService _doctorRefferalService;
        public CreateDoctorRefferalCommand(DoctorRefferalFormViewModel doctorRefferalFormViewModel, Appointment appointment, IDoctorRefferalService doctorRefferalService)
        {
            _doctorRefferalFormViewModel = doctorRefferalFormViewModel;
            _appointment = appointment;
            _doctorRefferalService = doctorRefferalService;

            _doctorRefferalFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            if (_doctorRefferalFormViewModel.IsSpecificDoctorSelected)
            {
                return (_doctorRefferalFormViewModel.SelectedDoctor is not null && _doctorRefferalFormViewModel.IsOperationSelected) ||
                       (_doctorRefferalFormViewModel.SelectedDoctor is not null && _doctorRefferalFormViewModel.IsAppointmentSelected &&
                       _doctorRefferalFormViewModel.Duration is not "");
            }
            return (_doctorRefferalFormViewModel.IsAppointmentSelected && _doctorRefferalFormViewModel.Duration is not "") ||
                (_doctorRefferalFormViewModel.IsOperationSelected);
        }

        public override void Execute(object? parameter)
        {
            if (_doctorRefferalFormViewModel.IsSpecificDoctorSelected)
            {
                var doctorRefferal = new DoctorRefferal(_doctorRefferalFormViewModel.SelectedDoctor.Doctor.Id, _appointment.PatientId,
                    _doctorRefferalFormViewModel.IsOperationSelected, GetDuration());
                _doctorRefferalService.Add(doctorRefferal);
            }
            else
            {
                var doctorRefferal = new DoctorRefferal(_doctorRefferalFormViewModel.SelectedSpecialization, _appointment.PatientId,
                    _doctorRefferalFormViewModel.IsOperationSelected, GetDuration());
                _doctorRefferalService.Add(doctorRefferal);
            }
            MessageBox.Show("Uspešno ste dodali uput", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(_doctorRefferalFormViewModel.SelectedDoctor)) ||
                (e.PropertyName == nameof(_doctorRefferalFormViewModel.SelectedSpecialization)) ||
                (e.PropertyName == nameof(_doctorRefferalFormViewModel.IsOperationSelected)) ||
                (e.PropertyName == nameof(_doctorRefferalFormViewModel.IsAppointmentSelected)) ||
                (e.PropertyName == nameof(_doctorRefferalFormViewModel.Duration)))
            {
                OnCanExecutedChanged();
            }
        }

        private int GetDuration()
        {
            if (_doctorRefferalFormViewModel.IsOperationSelected)
            {
                return int.Parse(_doctorRefferalFormViewModel.Duration);
            }
            return 15;
        }
    }
}
