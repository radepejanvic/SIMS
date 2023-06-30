using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Library.Commands;
using Library.Commands.HospitalTreatment;
using Library.EventArgument;
using Library.Model;
using Library.Model.Refferal;
using Library.Service.HospitalTreatmentService.Interface;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Structure.Refferal;

namespace Library.ViewModel.Table
{
    public class NurseRefferalTableViewModel : ViewModelBase
    {
        private string _from;
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        private DoctorRefferalViewModel _selectedDoctorRefferal;
        public DoctorRefferalViewModel SelectedDoctorRefferal
        {
            get
            {
                return _selectedDoctorRefferal;
            }
            set
            {
                _selectedDoctorRefferal = value;
                OnPropertyChanged(nameof(SelectedDoctorRefferal));
            }
        }

        private HospitalRefferalViewModel _selectedHospitalRefferal;
        public HospitalRefferalViewModel SelectedHospitalRefferal
        {
            get
            {
                return _selectedHospitalRefferal;
            }
            set
            {
                _selectedHospitalRefferal = value;
                OnPropertyChanged(nameof(SelectedHospitalRefferal));
            }
        }

        private ObservableCollection<DoctorRefferalViewModel> _doctorRefferals;
        public ObservableCollection<DoctorRefferalViewModel> DoctorRefferals
        {
            get
            {
                return _doctorRefferals;
            }
            set
            {
                _doctorRefferals = value;
                OnPropertyChanged(nameof(DoctorRefferals));
            }
        }

        private ObservableCollection<HospitalRefferalViewModel> _hospitalRefferals;
        public ObservableCollection<HospitalRefferalViewModel> HospitalRefferals
        {
            get
            {
                return _hospitalRefferals;
            }
            set
            {
                _hospitalRefferals = value;
                OnPropertyChanged(nameof(HospitalRefferals));
            }
        }

        public PatientViewModel SelectedPatient;

        private readonly IDoctorRefferalService _doctorRefferalService;
        private readonly IHospitalRefferalService _hospitalRefferalService;

        public CommandBase CreateDoctorRefferalAppointment { get; }
        public CommandBase CreateSpecializationRefferalAppointment { get; }
        public CommandBase StartHospitalTreatment { get; }

        public NurseRefferalTableViewModel(PatientViewModel selectedPatient, ISchedulingService schedulingService, IDoctorRefferalService doctorRefferalService, IHospitalRefferalService hospitalRefferalService, IRefferalSchedulingService refferalSchedulingService, IHospitalTreatmentService hospitalTreatmentService)
        {
            SelectedPatient = selectedPatient;
            _doctorRefferalService = doctorRefferalService;
            _hospitalRefferalService = hospitalRefferalService;

            CreateDoctorRefferalAppointment = new CreateDoctorRefferalAppointmentCommand(this, schedulingService, refferalSchedulingService);
            CreateSpecializationRefferalAppointment = new CreateSpecializationRefferalCommand(this, schedulingService, refferalSchedulingService);
            StartHospitalTreatment = new OpenUnderoccupiedRoomsTableCommand(this, hospitalTreatmentService);

            CreateDoctorRefferalAppointment.ExcecutionCompleted += ExecutionCompleted;
            CreateSpecializationRefferalAppointment.ExcecutionCompleted += ExecutionCompleted;

            LoadDoctorRefferals();
            LoadHospitalRefferals();
        }

        private void LoadDoctorRefferals()
        {
            _doctorRefferals = new ObservableCollection<DoctorRefferalViewModel>();
            foreach (DoctorRefferal doctorRefferal in _doctorRefferalService.GetAll(SelectedPatient.Id).Values)
            {
                _doctorRefferals.Add(new DoctorRefferalViewModel(doctorRefferal));
            }
        }

        private void LoadHospitalRefferals()
        {
            _hospitalRefferals = new ObservableCollection<HospitalRefferalViewModel>();
            foreach (HospitalRefferal hospitalRefferals in _hospitalRefferalService.GetAll(SelectedPatient.Id).Values)
            {
                _hospitalRefferals.Add(new HospitalRefferalViewModel(hospitalRefferals));
            }
        }

        public TimeSlot GetTimeSlot()
        {
            return new TimeSlot(DateTime.ParseExact(_from, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), SelectedDoctorRefferal.Duration);
        }
    }
}
