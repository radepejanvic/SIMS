using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Library.Commands;
using Library.Model;

using Library.Repository;
using Library.Service;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Table;

namespace Library.ViewModel
{
    public class PatientAppointmentCreateFormViewModel : ViewModelBase
    {
        private readonly ObservableCollection<DoctorViewModel> _doctors;
        public ObservableCollection<DoctorViewModel> Doctors => _doctors;
        private DoctorViewModel _selectedDoctor;
        public DoctorViewModel SelectedDoctor
        {
            get { return _selectedDoctor; }
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged(nameof(SelectedDoctor));
            }
        }

        public Patient _patient;
        private ObservableCollection<AppointmentViewModel> _appointments;
        public string DateAndTime { get; set; }
        public bool IsListViewSelectable { get; set; }
        private ISchedulingService _schedulingService;
        private IDoctorScheduleService _doctorScheduleService;
        private IPatientService _patientService;
        private IDoctorService _doctorService;
        public ICommand CreateAppointmentCommand { get; }
        public ICommand CloseCommand { get; set; }
        public PatientAppointmentCreateFormViewModel(Window window, Patient patient, ObservableCollection<AppointmentViewModel> appointments, 
            ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService, IPatientService patientService, IDoctorService doctorService, int doctorId = -1)
        {
            _patient = patient;
            _appointments = appointments;
            _schedulingService = schedulingService;
            _doctorService = doctorService;
            _doctorScheduleService = doctorScheduleService;
            _patientService = patientService;
            _doctors = new ObservableCollection<DoctorViewModel>();
            IsListViewSelectable = true;
            LoadDoctorsViewModels(doctorId);

            CloseCommand = new CloseCommand(window);
            CreateAppointmentCommand = new RelayCommand(CreateAppointment, CanCreateAppointment);
            //CreateAppointmentCommand = new PatientScheduleAppointmentCommand(window,this, SelectedDoctor, patient, _appointments, DateAndTime, schedulingService, patientService, doctorService);
            _patientService = patientService;
        }
        private void LoadDoctorsViewModels(int doctorId)
        {
            _doctors.Clear();
            // LinQ can`t be used because ObservableCollection does not have a definition for AddRange(). 
            foreach (Doctor doctor in _doctorService.GetAll().Values)
            {
                var doctorViewModel = new DoctorViewModel(doctor);
                _doctors.Add(doctorViewModel);
                if (doctorId != -1 && doctor.Id == doctorId)
                {
                    SelectedDoctor = doctorViewModel;
                    IsListViewSelectable = false;
                }
            }
        }
        private bool CanCreateAppointment()
        {
            return (SelectedDoctor != null) && !(String.IsNullOrEmpty(DateAndTime))
                && (ConvertStringToDateTime(this.DateAndTime).CompareTo(DateTime.Now) > 0);
        }

        public static DateTime ConvertStringToDateTime(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }
        public static TimeSlot MakeTimeSlot(DateTime date, int minutes)
        {
            return new TimeSlot(date, date.AddMinutes(minutes));
        }
        private void CreateAppointment()
        {
            TimeSlot timeSlot = MakeTimeSlot(ConvertStringToDateTime(this.DateAndTime), 15);

            if (CanCreateAppointment()
                && (_schedulingService.IsAvaliable(SelectedDoctor.Doctor, timeSlot))
                && (_schedulingService.IsAvaliable(_patient, timeSlot)) 
               && (_schedulingService.GetFirstAvaliableRoom(timeSlot) != 0))
            {

                Appointment newAppointment = new Appointment(SelectedDoctor.Doctor.Id, _patient.Id, _schedulingService.GetFirstAvaliableRoom(timeSlot), timeSlot, false);

                _schedulingService.Schedule(newAppointment);

                _appointments?.Add(new AppointmentViewModel(newAppointment, _patientService, _doctorService));
                MessageBox.Show("Uspesno ste zakazali pregled.");
                CloseCommand.Execute(null);  
            }
            else
            {
                MessageBox.Show("Doktor ili vi niste slobodni u tom trenutku.");
            }
        }


    }
}
