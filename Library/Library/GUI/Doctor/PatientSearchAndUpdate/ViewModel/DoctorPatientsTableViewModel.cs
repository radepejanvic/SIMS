using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;

using Library.Model;
using Library.View;
using System.ComponentModel;
using Library.Repository;
using Library.Service;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.AppointmentService.Interface;

namespace Library.ViewModel.Table
{
    public class DoctorPatientsTableViewModel: ViewModelBase
    {
        private readonly ObservableCollection<PatientViewModel> _patients;

        public ObservableCollection<PatientViewModel> Patients => _patients;
        
        private string _search;
        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value.ToLower();
                OnPropertyChanged(nameof(Search));
                SearchPatient();
            }
        }
        private Doctor Doctor { get; set; }
        private PatientViewModel _selectedPatient;
        public PatientViewModel SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        private IPatientService _patientService;
        public ICommand OpenMedicalRecord { get; }

        public DoctorPatientsTableViewModel(Doctor doctor, IPatientService patientService, ISchedulingService schedulingService, IAppointmentService appointmentService)
        {
            Doctor = doctor;
            _patients = new ObservableCollection<PatientViewModel>();
            _patientService = patientService;
            LoadPatientsViewModels();
            OpenMedicalRecord = new OpenMedicalRecordCommand(this, doctor, schedulingService, appointmentService, patientService);
        }

        private void LoadPatientsViewModels()
        {
            _patients.Clear();
            // LinQ can`t be used because ObservableCollection does not have a definition for AddRange(). 
            foreach (Patient patient in _patientService.GetAll().Values)
            {
                _patients.Add(new PatientViewModel(patient));
            }
        }

        private void SearchPatient()
        {
            if (!string.IsNullOrEmpty(Search))
            {
                var SearchedPatients = new ObservableCollection<PatientViewModel>(_patients.Where(obj => obj.FirstName.ToString().ToLower().Contains(Search) || obj.LastName.ToString().ToLower().Contains(Search)));
                _patients.Clear();
                foreach(PatientViewModel Patient in SearchedPatients)
                {
                    _patients.Add(Patient);
                }
            }
            else
            {
                LoadPatientsViewModels();
            }

        }
    }

}
