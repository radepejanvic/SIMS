using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Commands.Farmacy;
using Library.Commands.HospitalTreatment;
using Library.Model;

using Library.Model.Enum;
using Library.Service.AppointmentService;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.HospitalTreatmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;

namespace Library.ViewModel.Table
{
    public class PatientTableViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PatientViewModel> _patients;

        public ObservableCollection<PatientViewModel> Patients => _patients;

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

        public ICommand OpenMedicalRecord { get; }
        public ICommand CreateUrgentAppointment { get; }
        public ICommand CreateRefferalAppointment { get; }
        public ICommand ExtendTherapy { get; }
        public ICommand ManageDrugOrders { get; }
        public ICommand AddPatient { get; }
        public ICommand UpdatePatient { get; }
        public ICommand RemovePatient { get; }
        public ICommand OpenHospitalTreatments { get; }


        private IPatientService _patientService;

        public PatientTableViewModel(IPatientService patientService, IDoctorService doctorService, IDoctorScheduleService doctorScheduleService,
            ISchedulingService schedulingService, IAppointmentNotificationService notificationService, IAppointmentService appointmentService, 
            IDoctorRefferalService doctorRefferalService, IHospitalRefferalService hospitalRefferalService, IPerscriptionService perscriptionService,
            IDrugService drugService, IDrugPerscribingService drugPerscribingService, IDrugWarehouseService drugWarehouseService, IRefferalSchedulingService refferalSchedulingService,
            IPerscriptionSchedulingService perscriptionSchedulingService, IHospitalTreatmentService hospitalTreatmentService, IPatientCheckupService patientCheckupService)
        {
            _patientService = patientService;
            _patients = new ObservableCollection<PatientViewModel>();
            LoadPatientViewModels();
            OpenMedicalRecord = new OpenMedicalRecordCommand(this, patientService, schedulingService, appointmentService);
            AddPatient = new OpenPatientCommand(this, patientService);
            UpdatePatient = new OpenPatientCommand(this, patientService);
            RemovePatient = new RemovePatientCommand(this, _patientService);
            CreateUrgentAppointment = new OpenUrgentAppointmentCommand(this, patientService, doctorService, doctorScheduleService, schedulingService, notificationService);
            CreateRefferalAppointment = new OpenRefferalTableCommand(this, schedulingService, doctorRefferalService, hospitalRefferalService, refferalSchedulingService, hospitalTreatmentService);
            ExtendTherapy = new OpenExtendTherapyCommand(this, perscriptionService, drugService, drugPerscribingService, perscriptionSchedulingService, schedulingService, appointmentService);
            ManageDrugOrders = new OpenDrugOrderManagmentCommand(drugService, drugWarehouseService);
            OpenHospitalTreatments = new OpenHospitalTreatmentsCommand(hospitalTreatmentService, patientCheckupService);
        }

        private void LoadPatientViewModels()
        {
            _patients.Clear();
            
            // LinQ can`t be used because ObservableCollection does not have a definition for AddRange(). 
            foreach (Patient patient in _patientService.GetAll().Values)
            {
                _patients.Add(new PatientViewModel(patient));
            }
        }
    }
}
