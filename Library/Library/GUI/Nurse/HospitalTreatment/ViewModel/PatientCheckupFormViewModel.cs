using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Commands;
using Library.Commands.HospitalTreatment;
using Library.Model.Enum;
using Library.Service.HospitalTreatmentService.Interface;
using Library.ViewModel.Structure.Checkup;

namespace Library.ViewModel.Form.Checkup
{
	public class PatientCheckupFormViewModel : ViewModelBase
	{
		public PatientAndRoomViewModel SelectedPatient;

		public DateOnly DateOfCheckup => DateOnly.FromDateTime(DateTime.Today);

		private ObservableCollection<TimeOfCheckup> _timesOfDay;

		public ObservableCollection<TimeOfCheckup> TimesOfDay
		{
			get
			{
				return _timesOfDay;
			}
			set
			{
				_timesOfDay = value;
				OnPropertyChanged(nameof(TimesOfDay));
			}
		}


		private TimeOfCheckup? _timeOfCheckup;
		public TimeOfCheckup? TimeOfCheckup
		{
			get
			{
				return _timeOfCheckup;
			}
			set
			{
				_timeOfCheckup = value;
				OnPropertyChanged(nameof(TimeOfCheckup));
			}
		}

		private int _systolicPressure;
		public int SystolicPressure
		{
			get
			{
				return _systolicPressure;
			}
			set
			{
				_systolicPressure = value;
				OnPropertyChanged(nameof(SystolicPressure));
			}
		}

		private int _diastolicPressure;
		public int DiastolicPressure
		{
			get
			{
				return _diastolicPressure;
			}
			set
			{
				_diastolicPressure = value;
				OnPropertyChanged(nameof(DiastolicPressure));
			}
		}

		private float _temperature;
		public float Temperature
		{
			get
			{
				return _temperature;
			}
			set
			{
				_temperature = value;
				OnPropertyChanged(nameof(Temperature));
			}
		}

		private string _observations;
		public string Observations
		{
			get
			{
				return _observations;
			}
			set
			{
				_observations = value;
				OnPropertyChanged(nameof(Observations));
			}
		}

		private readonly IPatientCheckupService _patientCheckupService;

		public CommandBase SubmitPatientCheckup { get; }

        public PatientCheckupFormViewModel(PatientAndRoomViewModel selectedPatient, IPatientCheckupService patientCheckupService)
        {
			SelectedPatient = selectedPatient;
			_patientCheckupService = patientCheckupService;
			_timesOfDay = GetAllTimesOfDay();
			SubmitPatientCheckup = new SubmitPatientCheckupCommand(this, _patientCheckupService);
            SubmitPatientCheckup.ExcecutionCompleted += ExecutionCompleted;
        }

		private ObservableCollection<TimeOfCheckup> GetAllTimesOfDay()
        {
            var allTimesOfDay = Enum.GetValues(typeof(TimeOfCheckup)).Cast<TimeOfCheckup>().ToList();
            return new ObservableCollection<TimeOfCheckup>(allTimesOfDay);

        }

    }
}
