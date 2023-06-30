using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using Library.Commands;

using Library.Model.Enum;
using Library.Model;
using Library.View;
using System.Collections.Specialized;
using System.IO.Packaging;
using System.Globalization;
using Library.Service;
using System.Numerics;
using System.Runtime.CompilerServices;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.AppointmentService.Interface;

namespace Library.ViewModel.Table
{
    public class DoctorAppointmentTableViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<AppointmentViewModel> _appointments;
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
        private Doctor Doctor { get; set; }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                GenerateDays(value);
                OnPropertyChanged(nameof(Date));
            }
        }
        public ICommand CreateAppointmentCommand { get; }
        public ICommand UpdateAppointmentCommand { get; }
        public ICommand CancelAppointmentCommand { get; }

        private ISchedulingService _schedulingService;
        private IDoctorScheduleService _doctorScheduleService;
        private IPatientService _patientService;
        private IDoctorService _doctorService;
        private IAppointmentService _appointmentService;
        public DoctorAppointmentTableViewModel(Doctor doctor, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService, IPatientService patientService, IAppointmentService appointmentService, IDoctorService doctorService)
        {
            Doctor = doctor;

            _schedulingService = schedulingService;
            _doctorScheduleService = doctorScheduleService;
            _patientService = patientService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;

            Date = DateTime.Now;  
            _appointments = new ObservableCollection<AppointmentViewModel>();

            foreach (var appointment in _appointmentService.GetAllByDoctor(doctor.Id).Values)
            {
                _appointments.Add(new AppointmentViewModel(appointment, _patientService, _doctorService));
            }

            CreateAppointmentCommand = new RelayCommand(CreateRow, CanCreateRow);
            CancelAppointmentCommand = new RelayCommand(CancelSelectedRow, CanCancelSelectedRow);
            UpdateAppointmentCommand = new RelayCommand(UpdateAppointment, CanCancelSelectedRow);

        }

        private bool CanCancelSelectedRow()
        {
            return (SelectedAppointment != null) && !(SelectedAppointment.Appointment.IsCanceled) && !(IsPastOrWithin24Hours(SelectedAppointment.Appointment.TimeSlot.From));
        }

        private void UpdateListOfAppointments(List<DateTime> nextThreeDays)
        {
            _appointments = new ObservableCollection<AppointmentViewModel>();
            foreach (var day in nextThreeDays)
            {
                // TODO: Remove call to the static class and call function from corresponding Service.
                foreach (var appointment in _appointmentService.GetAllByDoctor(Doctor.Id).Values)
                {
                        if (day.Year == appointment.TimeSlot.From.Year && day.Month == appointment.TimeSlot.From.Month && day.Day == appointment.TimeSlot.From.Day)
                        {
                            _appointments.Add(new AppointmentViewModel(appointment, _patientService, _doctorService));
                        }
                }
            }
            OnPropertyChanged(nameof(Appointments));
            CollectionViewSource.GetDefaultView(Appointments).Refresh();
        }
        public static bool IsPastOrWithin24Hours(DateTime time)
        {
            return (time.CompareTo(DateTime.Now) < 0) || ((time - DateTime.Now).TotalHours < 24); ;
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

        private DateTime ConvertString(string date)
        {
            DateTime result;
            if (!DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                throw new ArgumentException("Input string is not in the correct format", nameof(date));
            }
            return result;
        }

        public bool CanCreateRow()
        {
            return true;
        }

        private void GenerateDays(DateTime currentDate)
        {
            List<DateTime> nextThreeDays = new List<DateTime>();
            nextThreeDays.Add(currentDate);
            for (int i = 1; i <= 3; i++)
            {
                DateTime nextDay = currentDate.AddDays(i);
                nextThreeDays.Add(nextDay);
            }

            UpdateListOfAppointments(nextThreeDays);
        }

        public void CreateRow()
        {
            var createAppointmentView = new DoctorCreateAppointmentView(Doctor, _appointments, _schedulingService, _doctorScheduleService, _patientService, _doctorService);
            createAppointmentView.ShowDialog();
        }

        private void UpdateAppointment()
        {
            var updateAppointmentView = new DoctorUpdateAppointmentView(_appointments, SelectedAppointment, _schedulingService, _doctorScheduleService);
            updateAppointmentView.ShowDialog();
        }
    }
}
