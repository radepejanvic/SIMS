using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Media3D;
using Library.Model;

using Library.Model.Enum;
using Library.Service;
using Library.Service.PersonService.Interface;
using Library.ViewModel;
using Library.ViewModel.Form;

namespace Library.Commands
{
    class SubmitMedicalRecordCommand : CommandBase
    {
        private MedicalRecordFormViewModel _medicalRecordFormViewModel { get; }
        private ExaminationMedicalRecordViewModel _examinationMedicalRecordViewModel { get; }

        private IPatientService _patientService;

        private bool _isExaminationMedicalRecord;
        public double Height;
        public double Weight;

        public SubmitMedicalRecordCommand(MedicalRecordFormViewModel medicalRecordFormViewModel, IPatientService patientService)
        {
            _isExaminationMedicalRecord = false;
            _patientService = patientService;
            _medicalRecordFormViewModel = medicalRecordFormViewModel;
            _medicalRecordFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public SubmitMedicalRecordCommand(ExaminationMedicalRecordViewModel examinationMedicalRecordViewModel, IPatientService patientService)
        {
            _isExaminationMedicalRecord = true;
            _patientService = patientService;
            _examinationMedicalRecordViewModel = examinationMedicalRecordViewModel;
            _examinationMedicalRecordViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _isExaminationMedicalRecord ? (_examinationMedicalRecordViewModel.Weight > 1.5 && _examinationMedicalRecordViewModel.Weight < 635) :
                (_medicalRecordFormViewModel.Weight > 1.5 && _medicalRecordFormViewModel.Weight < 635);
        }

        public override void Execute(object? parameter)
        {
            if (_isExaminationMedicalRecord)
            {
                ExecuteExaminationMedicalRecordView();
            }
            else
            {
                ExecuteMedicalRecordFormView();
            }
        }

        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Height = GetHeight();
            Weight = GetWeight();
            if ((e.PropertyName == nameof(Height)) || (e.PropertyName == nameof(Weight)))
            {
                OnCanExecutedChanged();
            }
        }

        private double GetHeight()
        {
            return _isExaminationMedicalRecord ? _examinationMedicalRecordViewModel.Height : _medicalRecordFormViewModel.Height;
        }
        private double GetWeight()
        {
            return _isExaminationMedicalRecord ? _examinationMedicalRecordViewModel.Weight : _medicalRecordFormViewModel.Weight;
        }

        public void ExecuteMedicalRecordFormView()
        {
            var medicalRecord = new MedicalRecord(_medicalRecordFormViewModel.Height, _medicalRecordFormViewModel.Weight, _medicalRecordFormViewModel.Diseases.ToList(), _medicalRecordFormViewModel.Alergies.ToList());
            try
            {
                _medicalRecordFormViewModel.SelectedPatient.MedicalRecord = new MedicalRecordViewModel(medicalRecord);
                var patient = _patientService.Get(_medicalRecordFormViewModel.SelectedPatient.Id);
                patient.MedicalRecord = medicalRecord;
                _patientService.Update(patient);

                MessageBox.Show("Uspešno ste izmenili zdravstveni karton", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom izmene zdravstvenog kartona.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void ExecuteExaminationMedicalRecordView()
        {
            var medicalRecord = new MedicalRecord(_examinationMedicalRecordViewModel.Height, _examinationMedicalRecordViewModel.Weight, _examinationMedicalRecordViewModel.Diseases.ToList(), _examinationMedicalRecordViewModel.Alergies.ToList());
            try
            {
                _examinationMedicalRecordViewModel.SelectedPatient.MedicalRecord = new MedicalRecordViewModel(medicalRecord);
                var patient = _patientService.Get(_examinationMedicalRecordViewModel.SelectedAppointment.PatientId);
                patient.MedicalRecord = medicalRecord;
                _patientService.Update(patient);

                MessageBox.Show("Uspešno ste izmenili zdravstveni karton", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom izmene zdravstvenog kartona.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
