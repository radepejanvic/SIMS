using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Service.AppointmentService;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService;
using Library.Service.ScheduleService.Interface;
using Library.View;
using Library.View.Table;
using Library.ViewModel.Structure;

namespace Library.ViewModel.Table
{
    public class PatientDoctorSearchTableViewModel : ViewModelBase
    {
        private readonly ObservableCollection<DoctorViewModel> _doctors;
        public ObservableCollection<DoctorViewModel> Doctors => _doctors;

		private DoctorViewModel _selectedDoctor;
		public DoctorViewModel SelectedDoctor
		{
			get
			{
				return _selectedDoctor;
			}
			set
			{
				_selectedDoctor = value;
				OnPropertyChanged(nameof(SelectedDoctor));
			}
		}
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
            }
        }
        private Patient _patient;
        public ICommand OpenCreateAppointmentCommand { get; }
        public ICommand CloseCommand { get; }
        public IDoctorService _doctorService;
        private ISchedulingService _schedulingService;
        private IDoctorScheduleService _doctorScheduleService;
        private IPatientService _patientService;
        public PatientDoctorSearchTableViewModel(Window window, Patient patient, IDoctorService doctorService, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService, IPatientService patientService)
        {
            _patient = patient;
            _schedulingService = schedulingService;
            _doctorScheduleService = doctorScheduleService;
            _doctorService = doctorService;
            _patientService = patientService;
            CloseCommand = new CloseCommand(window);
            _doctors = new ObservableCollection<DoctorViewModel>(_doctorService.GetAll().Values.Select(o => new DoctorViewModel(o)));
            OpenCreateAppointmentCommand = new RelayCommand(OpenCreateAppointmentWindow, CanOpen);
            PropertyChanged += OnPropertyChanged;
        }

        private bool CanOpen()
        {
            return SelectedDoctor is not null;
        }

        private void OpenCreateAppointmentWindow()
        {
            var createAppointmentView = new PatientCreateAppointmentView(_patient, null, _schedulingService, _doctorScheduleService, _patientService, _doctorService);
            createAppointmentView.DataContext = new PatientAppointmentCreateFormViewModel(createAppointmentView, _patient, null, _schedulingService, _doctorScheduleService, _patientService, _doctorService, SelectedDoctor.Doctor.Id);
            createAppointmentView.ShowDialog();
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Search))
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    var filteredDoctors = _doctors.Where(doctor => doctor.FullName.ToLower().Contains(Search.ToLower())
                    || doctor.Specialization.ToString().ToLower().Contains(Search.ToLower())
                    || doctor.AverageReview.ToString().ToLower().Contains(Search.ToLower())).ToList();
                    _doctors.Clear();
                    foreach (var doctor in filteredDoctors)
                    {
                        _doctors.Add(doctor);
                    }
                }
                else
                {
                    _doctors.Clear();
                    foreach (var doctor in _doctorService.GetAll().Values)
                    {
                        _doctors.Add(new DoctorViewModel(doctor));
                    }
                }
            }
        }
    }
}
