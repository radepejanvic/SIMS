using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Service.AppointmentService;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.LeaveRequestService;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.RefferalService;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.View;
using Library.View.Form;
using Library.View.Table;
using Library.ViewModel.Table;

namespace Library.ViewModel
{
    public class DoctorMainViewModel: ViewModelBase
    {
        private Doctor Doctor { get; set; }

        private ISchedulingService _schedulingService;
        private IDoctorScheduleService _doctorScheduleService;
        private IPatientService _patientService;
        private IAppointmentService _appointmentService;
        private IDoctorService _doctorService;
        private IAnamnesisService _anamnesisService;
        private IAppointmentInitiationService _appointmentInitiationService;
        private IDoctorRefferalService _doctorRefferalService;
        private IDrugService _drugService;
        private IDrugPerscribingService _drugPerscribingService;
        private IHospitalRefferalService _hospitalRefferalService;
        private ILeaveRequestService _leaveRequestService;

        public ICommand CreateWindowAppointmentsCommand { get; }
        public ICommand CreateWindowPatientsCommand { get; }
        public ICommand CreateWindowStartExaminationCommand { get; }
        public ICommand CreateWindowLeaveRequestCommand { get; }
        public DoctorMainViewModel(Doctor doctor, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService, 
            IPatientService patientService, IAppointmentService appointmentService, IDoctorService doctorService, 
            IAnamnesisService anamnesisService, IAppointmentInitiationService appointmentInitiationService, 
            IDoctorRefferalService doctorRefferalService, IDrugService drugService, IDrugPerscribingService drugPerscribingService,
            IHospitalRefferalService hospitalRefferalService, ILeaveRequestService leaveRequestService)
        {
            Doctor = doctor;

            _schedulingService = schedulingService;
            _patientService = patientService;
            _doctorScheduleService = doctorScheduleService;
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _anamnesisService = anamnesisService;
            _appointmentInitiationService = appointmentInitiationService;
            _doctorRefferalService = doctorRefferalService;
            _drugService = drugService;
            _drugPerscribingService = drugPerscribingService;
            _hospitalRefferalService = hospitalRefferalService;
            _leaveRequestService = leaveRequestService;

            CreateWindowAppointmentsCommand = new RelayCommand(CreateWindowAppointments, CanExecute);
            CreateWindowPatientsCommand = new RelayCommand(CreateWindowPatients, CanExecute);
            CreateWindowStartExaminationCommand = new RelayCommand(CreateWindowStartExamination, CanExecute);
            CreateWindowLeaveRequestCommand = new RelayCommand(CreateWindowLeaveRequest, CanExecute);
        }

        public static bool CanExecute()
        {
            return true;
        }

        public void CreateWindowAppointments()
        {
            var createAppointmentView = new DoctorAppointmentView(Doctor, _schedulingService, _doctorScheduleService, _patientService,
                _appointmentService, _doctorService);
            createAppointmentView.ShowDialog();
        }

        public void CreateWindowPatients()
        {
            var createWindowPatients = new DoctorsPatients(Doctor, _patientService, _schedulingService, _appointmentService);
            createWindowPatients.ShowDialog();
        }

        public void CreateWindowStartExamination()
        {
            var createWindowStartExamination = new DoctorInitiateAppointmentView(Doctor, _schedulingService, _patientService, _appointmentService, 
                _doctorService, _anamnesisService, _appointmentInitiationService, _doctorRefferalService, _drugService, _drugPerscribingService, 
                _hospitalRefferalService);
            createWindowStartExamination.ShowDialog();
        }

        public void CreateWindowLeaveRequest()
        {
            var createWindowLeaveRequest = new LeaveRequestFormView(Doctor, _schedulingService, _leaveRequestService);
            createWindowLeaveRequest.ShowDialog();

        }
    }
}
