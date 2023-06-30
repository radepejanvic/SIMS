using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

using Library.Model;
using Library.ViewModel.Form;
using System.ComponentModel;
using Library.ViewModel.Table;
using Library.Repository;
using Library.Service.PersonService.Interface;

namespace Library.Commands
{
    public class RemovePatientCommand : CommandBase
    {
        private readonly PatientTableViewModel _patientTableViewModel;
        private IPatientService _patientService;

        public RemovePatientCommand(PatientTableViewModel patientTableViewModel, IPatientService patientService)
        {
            _patientTableViewModel = patientTableViewModel;
            _patientService = patientService;
            _patientTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _patientTableViewModel.SelectedPatient is not null;
        }
        public override void Execute(object? parameter)
        {
            var patient = _patientService.Get(_patientTableViewModel.SelectedPatient.Id);
            _patientTableViewModel.Patients.Remove(_patientTableViewModel.SelectedPatient);
            _patientService.Remove(patient.Id);
        }

        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientTableViewModel.SelectedPatient))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
