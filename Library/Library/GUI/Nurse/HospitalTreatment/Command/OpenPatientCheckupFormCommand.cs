using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Library.Service.HospitalTreatmentService.Interface;
using Library.View.Form.Checkup;
using Library.ViewModel.Form.Checkup;
using Library.ViewModel.Structure.Checkup;
using Library.ViewModel.Table;
using Library.ViewModel.Table.Checkup;

namespace Library.Commands.HospitalTreatment
{
    public class OpenPatientCheckupFormCommand : CommandBase
    {
        private readonly IPatientCheckupService _patientCheckupService;
        private readonly HospitalTreatmentPatientTableViewModel _hospitalTreatmentPatientTableViewModel;

        public OpenPatientCheckupFormCommand(HospitalTreatmentPatientTableViewModel hospitalTreatmentPatientTableViewModel, IPatientCheckupService patientCheckupService)
        {
            _patientCheckupService = patientCheckupService;
            _hospitalTreatmentPatientTableViewModel = hospitalTreatmentPatientTableViewModel;
            _hospitalTreatmentPatientTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _hospitalTreatmentPatientTableViewModel.SelectedPatient is not null;
        }

        public override void Execute(object? parameter)
        {
            var popup = new PatientCheckupFormView
            {
                DataContext = new PatientCheckupFormViewModel(_hospitalTreatmentPatientTableViewModel.SelectedPatient, _patientCheckupService)
            };
            popup.Show();
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_hospitalTreatmentPatientTableViewModel.SelectedPatient))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
