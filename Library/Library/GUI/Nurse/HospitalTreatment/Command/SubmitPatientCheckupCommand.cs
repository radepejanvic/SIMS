using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Library.Model.Checkup;
using Library.Model.Enum;
using Library.Service.HospitalTreatmentService.Interface;
using Library.ViewModel.Form.Checkup;
using Library.ViewModel.Table;

namespace Library.Commands.HospitalTreatment
{
    internal class SubmitPatientCheckupCommand : CommandBase
    {
        private readonly PatientCheckupFormViewModel _patientCheckupFormViewModel;
        private readonly IPatientCheckupService _patientCheckupService;

        public SubmitPatientCheckupCommand(PatientCheckupFormViewModel patientCheckupFormViewModel, IPatientCheckupService patientCheckupService)
        {
            _patientCheckupFormViewModel = patientCheckupFormViewModel;
            _patientCheckupService = patientCheckupService;
            _patientCheckupFormViewModel.PropertyChanged += OnViewModelPropertyChange;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_patientCheckupFormViewModel.TimeOfCheckup is not null) &&
                (_patientCheckupFormViewModel.SystolicPressure > 0) &&
                (_patientCheckupFormViewModel.DiastolicPressure > 0) &&
                (_patientCheckupFormViewModel.Temperature > 34) &&
                (!string.IsNullOrEmpty(_patientCheckupFormViewModel.Observations)) &&
                !_patientCheckupService.HasBeenDone(_patientCheckupFormViewModel.SelectedPatient.PatientPlacementId, (TimeOfCheckup)_patientCheckupFormViewModel.TimeOfCheckup);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _patientCheckupService.Add(GeneratePatientCheckup());
                OnExecutionCompleted(true, "Uspešno ste uneli rezultate vizite.");
            } catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom unosa rezultata vizite!");
            }
        }

        private void OnViewModelPropertyChange(object? sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(_patientCheckupFormViewModel.TimeOfCheckup)) ||
                (e.PropertyName == nameof(_patientCheckupFormViewModel.SystolicPressure)) ||
                (e.PropertyName == nameof(_patientCheckupFormViewModel.DiastolicPressure)) ||
                (e.PropertyName == nameof(_patientCheckupFormViewModel.Temperature)) ||
                (e.PropertyName == nameof(_patientCheckupFormViewModel.Observations)))
            {
                OnCanExecutedChanged();
            }
        }

        private PatientCheckup GeneratePatientCheckup()
        {
            return new PatientCheckup(
                _patientCheckupFormViewModel.SelectedPatient.PatientId,
                _patientCheckupFormViewModel.SelectedPatient.PatientPlacementId,
                (TimeOfCheckup)_patientCheckupFormViewModel.TimeOfCheckup,
                _patientCheckupFormViewModel.SystolicPressure,
                _patientCheckupFormViewModel.DiastolicPressure,
                _patientCheckupFormViewModel.Temperature,
                _patientCheckupFormViewModel.Observations);
        }
    }
}