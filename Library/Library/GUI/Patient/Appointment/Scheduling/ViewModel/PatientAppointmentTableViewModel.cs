using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using Library.Commands;
using Library.Model;

using Library.Model.Enum;
using Library.Service;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.View;
using Library.View.Table;

namespace Library.ViewModel.Table
{
    public class PatientAppointmentTableViewModel : ViewModelBase, INotifyPropertyChanged
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
        private Patient _patient { get; set; }
        private IAppointmentService _appointmentService;
        private IPatientService _patientService;
        private IDoctorService _doctorService;
        private ISchedulingService _schedulingService;
        public ICommand CreateAppointmentCommand { get; }
        public ICommand UpdateAppointmentCommand { get; }
        public ICommand CancelAppointmentCommand { get; }
        private IDoctorScheduleService _doctorScheduleService;
        public PatientAppointmentTableViewModel(Patient patient, ISchedulingService schedulingService, IAppointmentService appointmentService, IDoctorScheduleService doctorScheduleService, IPatientService patientService, IDoctorService doctorService)
        {
            _doctorService = doctorService;
            _patient = patient;
            _appointmentService = appointmentService;
            _doctorScheduleService = doctorScheduleService;
            _schedulingService = schedulingService;
            _patientService = patientService;
            _appointments = new ObservableCollection<AppointmentViewModel>();
            foreach (var appointment in _appointmentService.GetAllByPatient(patient.Id).Values)
            {
                   _appointments.Add(new AppointmentViewModel(appointment, patientService, doctorService));
            }
            CancelAppointmentCommand = new RelayCommand(CancelSelectedRow, CanCancelSelectedRow);
            CreateAppointmentCommand = new RelayCommand(CreateRow, CanCreateRow);
            UpdateAppointmentCommand = new RelayCommand(UpdateAppointment, CanUpdateAppointment);
        }

        private bool CanUpdateAppointment()
        {
            return CanCancelSelectedRow();
        }
        private void UpdateAppointment()
        {
            var updateAppointmentView = new PatientUpdateAppointmentView(_appointments, SelectedAppointment, _schedulingService, _doctorScheduleService);
            updateAppointmentView.ShowDialog();
        }
        private bool CanCancelSelectedRow()
        {
            return (SelectedAppointment != null) && !(SelectedAppointment.Appointment.IsCanceled) && !(IsPastOrWithin24Hours(SelectedAppointment.Appointment.TimeSlot.From));
        }

        public static bool IsPastOrWithin24Hours(DateTime time)
        {
            return (time.CompareTo(DateTime.Now) < 0) || ((time - DateTime.Now).TotalHours < 24);
        }

        private void CancelSelectedRow()
        {
            if (CanCancelSelectedRow())
            {
                MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite otkazati pregled?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SelectedAppointment.Appointment.IsCanceled = true;
                    _schedulingService.Unschedule(SelectedAppointment.Appointment);
                    CollectionViewSource.GetDefaultView(Appointments).Refresh();
                }
            }
        }

        public bool CanCreateRow()
        {
            return true;
        }

        public void CreateRow()
        {
            var createAppointmentView = new PatientCreateAppointmentView(_patient, _appointments, _schedulingService, _doctorScheduleService, _patientService, _doctorService);
            createAppointmentView.ShowDialog();
        }
    }
}

