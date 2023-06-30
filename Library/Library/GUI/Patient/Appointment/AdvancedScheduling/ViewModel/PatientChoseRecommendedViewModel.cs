using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.ViewModel.Table
{
    public class PatientChoseRecommendedViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AppointmentViewModel> _appointments;
        public ObservableCollection<AppointmentViewModel> Appointments => _appointments;
        private AppointmentViewModel _selectedAppointment;
        public AppointmentViewModel SelectedAppointment
        {
            get { return _selectedAppointment; }
            set
            {
                _selectedAppointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
            }
        }
        private Patient Patient { get; set; }
        public ICommand ScheduleAppointmentCommand { get; }
        public ICommand CloseCommand { get; }
        public Window window;
        private IDoctorScheduleService _doctorScheduleService;
        private IPatientService _patientService;
        public PatientChoseRecommendedViewModel(Patient patient, Window window, List<TimeSlot> timeSlots, Doctor doctor, IDoctorScheduleService doctorScheduleService, IPatientService patientService, IDoctorService doctorService)
        {
            _appointments = new ObservableCollection<AppointmentViewModel>();
            _doctorScheduleService = doctorScheduleService;
            _patientService = patientService;
            foreach (var slot in timeSlots)
            {
                Appointment appointment = new Appointment(doctor.Id, patient.Id,0, slot, false);
                _appointments.Add(new AppointmentViewModel(appointment, patientService, doctorService));
            }
            Patient = patient;
            CloseCommand = new CloseCommand(window);
            ScheduleAppointmentCommand = new ScheduleAppointmentCommand(this, _doctorScheduleService, patientService, doctorService);
        }

    }
}
