using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Model.Enum;
using Library.Service;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel.Form;

namespace Library.ViewModel.Table
{
    public class DelayableAppointmentTableViewModel : ViewModelBase
    {

		public UrgentAppointmentFormViewModel UrgentAppointmentForm;

        private readonly ObservableCollection<AppointmentViewModel> _appointments;

        public ObservableCollection<AppointmentViewModel> Appointments => _appointments;

        private AppointmentViewModel _selectedAppointment;
		public AppointmentViewModel SelectedAppointment
		{
			get
			{
				return _selectedAppointment;
			}
			set
			{
				_selectedAppointment = value;
				OnPropertyChanged(nameof(SelectedAppointment));
			}
		}

		public ICommand DelayAndCreateAppointment { get; }

		private ISchedulingService _schedulingService;
		private IPatientService _patientService;
		private IDoctorService _doctorService;

        public DelayableAppointmentTableViewModel(UrgentAppointmentFormViewModel urgentAppointmentForm, IPatientService patientService, IDoctorService doctorService, IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IAppointmentNotificationService notificationService)
        {
			UrgentAppointmentForm = urgentAppointmentForm;
			_schedulingService = schedulingService;
            _patientService = patientService;
			_doctorService = doctorService;
            _appointments = new ObservableCollection<AppointmentViewModel>();
            LoadAppointmentViewModels();
            DelayAndCreateAppointment = new DelayAndCreateAppointmentCommand(this, patientService, doctorService, doctorScheduleService, _schedulingService, notificationService);
        }

		private void LoadAppointmentViewModels()
		{
            var delayableAppointments = _schedulingService.GetDelayableAppointments((Specialization)UrgentAppointmentForm.SelectedSpecialization, new TimeSlot(2), new TimeSlot(DateTime.Today.AddHours(20)), UrgentAppointmentForm.Duration, 5);

			foreach (KeyValuePair<int, Appointment> pair in delayableAppointments)
			{
				_appointments.Add(new AppointmentViewModel(pair.Value, _patientService, _doctorService));
			}
		}
    }
}
