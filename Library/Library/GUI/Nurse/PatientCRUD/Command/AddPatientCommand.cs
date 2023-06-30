using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Library.Model;

using Library.Model.Enum;
using Library.Service;
using Library.Service.PersonService.Interface;
using Library.View;
using Library.ViewModel;
using Library.ViewModel.Form;

namespace Library.Commands
{
    public class AddPatientCommand : CommandBase
    {
        private readonly PatientFormViewModel _patientFormViewModel;
        private IPatientService _patientService;
        

        public AddPatientCommand(PatientFormViewModel patientFormViewModel, IPatientService patientService)
        {
            _patientFormViewModel = patientFormViewModel;
            _patientFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _patientService = patientService;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_patientFormViewModel.Username is not null) &&  
                (_patientFormViewModel.FirstName is not null) && _patientService.IsMatch(_patientFormViewModel.FirstName) &&
                (_patientFormViewModel.LastName is not null) && _patientService.IsMatch(_patientFormViewModel.LastName) &&
                (_patientFormViewModel.Password is not null) &&
                (_patientFormViewModel.PasswordCheck is not null);
        }

        public override void Execute(object? parameter)
        {
            if (!_patientService.IsUnique(_patientFormViewModel.Username))
            {
                MessageBox.Show("Korisničko ime je zauzeto.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (_patientFormViewModel.Password != _patientFormViewModel.PasswordCheck)
            {
                MessageBox.Show("Šifra se ne poklapa", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                //TODO: Make DTO object that will be sent from this to service.
                var patient = new Patient(0, _patientFormViewModel.Username, _patientFormViewModel.FirstName, _patientFormViewModel.LastName, _patientFormViewModel.Password, new MedicalRecord());
                
                _patientService.Add(patient);
                _patientFormViewModel.PatientTableViewModel.Patients.Add(new PatientViewModel(patient));
                _patientFormViewModel.PatientFormView.Close();
                CollectionViewSource.GetDefaultView(_patientFormViewModel.PatientTableViewModel.Patients).Refresh();
            }
        }

        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(_patientFormViewModel.Username)) ||
                (e.PropertyName == nameof(_patientFormViewModel.FirstName)) ||
                (e.PropertyName == nameof(_patientFormViewModel.LastName)) ||
                (e.PropertyName == nameof(_patientFormViewModel.Password)) || 
                (e.PropertyName == nameof(_patientFormViewModel.PasswordCheck)))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
            
