using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Commands;
using Library.Commands.HospitalTreatment;
using Library.Model;
using Library.Model.Checkup;
using Library.Model.Refferal;
using Library.Service.HospitalTreatmentService;
using Library.Service.HospitalTreatmentService.Interface;
using Library.ViewModel.Structure.Checkup;
using Library.ViewModel.Structure.Refferal;

namespace Library.ViewModel.Table.Checkup
{
    public class HospitalTreatmentPatientTableViewModel : ViewModelBase
    {
		private ObservableCollection<PatientAndRoomViewModel> _patients;
		public ObservableCollection<PatientAndRoomViewModel> Patients
		{
			get
			{
				return _patients;
			}
			set
			{
                _patients = value;
				OnPropertyChanged(nameof(Patients));
			}
		}

		private PatientAndRoomViewModel _selectedPatient;
		public PatientAndRoomViewModel SelectedPatient
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

		private string _search;
		public string Search
		{
			get
			{
				return _search;
			}
			set
			{
				_search = value;
				OnPropertyChanged(nameof(Search));
			}
		}

		private readonly IHospitalTreatmentService _hospitalTreatmentService;

		public CommandBase OpenPatientCheckup { get; }

        public HospitalTreatmentPatientTableViewModel(IHospitalTreatmentService hospitalTreatmentService, IPatientCheckupService patientCheckupService)
        {
			_hospitalTreatmentService = hospitalTreatmentService;
			_patients = new ObservableCollection<PatientAndRoomViewModel>();
			OpenPatientCheckup = new OpenPatientCheckupFormCommand(this, patientCheckupService);

			PropertyChanged += OnPropertyChanged;
            LoadAllPatients();
        }

        private void LoadAllPatients()
		{
			_patients.Clear();
            foreach (PatientAndRoom patientAndRoom in _hospitalTreatmentService.GetAllPatientsOnHospitalTreatment().Values)
            {
                _patients.Add(new PatientAndRoomViewModel(patientAndRoom));
            }
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Search) && !string.IsNullOrEmpty(Search))
            {
				var filtered = _patients.Where(patient => patient.Contains(Search)).ToList();
				CopyFiltered(filtered);
            } else if (e.PropertyName == nameof(Search))
			{
				LoadAllPatients();
			}
        }

		private void CopyFiltered(List<PatientAndRoomViewModel> filtered)
		{
			_patients.Clear();
            foreach (PatientAndRoomViewModel patient in filtered)
            {
                _patients.Add(patient);
            }
        }

    }
}
