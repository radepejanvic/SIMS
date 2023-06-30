using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Model.Enum;
using Library.Service.FarmaceuticalService.Interface;
using Library.ViewModel.Structure.Farmacy;

namespace Library.ViewModel.Form
{
    public class DrugInstructionFormViewModel: ViewModelBase
    {
        public ObservableCollection<DrugViewModel> Drugs { get; set; }
        public ObservableCollection<MedicationIntakeTime> MedicationIntakeTimes { get; set; }

        private MedicationIntakeTime _selectedMedicationIntakeTime;
        public MedicationIntakeTime SelectedMedicationIntakeTime
        {
            get { return _selectedMedicationIntakeTime; }
            set
            {
                _selectedMedicationIntakeTime = value;
                OnPropertyChanged(nameof(SelectedMedicationIntakeTime));
            }
        }

        private DrugViewModel _selectedDrug;
        public DrugViewModel SelectedDrug
        {
            get { return _selectedDrug; }
            set
            {
                _selectedDrug = value;
                CheckAlergen();
                OnPropertyChanged(nameof(SelectedDrug));
            }
        }

        private string _timesPerDay;
        public string TimesPerDay
        {
            get
            {
                return _timesPerDay;

            }
            set
            {
                if (Regex.IsMatch(value, "^[0-9]+$"))
                {
                    _timesPerDay = value;
                    OnPropertyChanged(nameof(TimesPerDay));
                }
            }
        }

        private string _amountPerDose;
        public string AmountPerDose
        {
            get
            {
                return _amountPerDose;

            }
            set
            {
                if (Regex.IsMatch(value, "^[0-9]+$"))
                {
                    _amountPerDose = value;
                    OnPropertyChanged(nameof(AmountPerDose));
                }
            }
        }

        private string _therapyDuration;
        public string TherapyDuration
        {
            get
            {
                return _therapyDuration;

            }
            set
            {
                if (Regex.IsMatch(value, "^[0-9]+$"))
                {
                    _therapyDuration = value;
                    OnPropertyChanged(nameof(TherapyDuration));
                }
            }
        }

        private string _additionalComments;
        public string AdditionalComments
        {
            get
            {
                return _additionalComments;

            }
            set
            {
                _additionalComments = value;
                OnPropertyChanged(nameof(AdditionalComments));
            }
        }

        private bool _isPersciption;
        public bool IsPersciption
        {
            get { return _isPersciption; }
            set
            {
                if (_isPersciption != value)
                {
                    _isPersciption = value;
                    OnPropertyChanged(nameof(IsPersciption));
                }
            }
        }

        public ICommand CreatePerscription { get; }

        private IDrugService _drugService;
        private IDrugPerscribingService _drugPerscribingService;
        public Appointment Appointment;

        public DrugInstructionFormViewModel(bool isPersciption, DrugViewModel selectedDrug, IDrugService drugService, 
            IDrugPerscribingService drugPerscribingService, Appointment appointment)
        {
            _drugService = drugService;
            _drugPerscribingService = drugPerscribingService;

            IsPersciption = isPersciption;
            Appointment = appointment;
            SelectedDrug = selectedDrug;

            GetDrugs();
            GetMedicationIntakeTimes();

            CreatePerscription = new CreatePerscriptionCommand(this, drugPerscribingService, appointment);
        }

        private void GetMedicationIntakeTimes()
        {
            var allMedicationIntakeTimes = Enum.GetValues(typeof(MedicationIntakeTime)).Cast<MedicationIntakeTime>().ToList();
            MedicationIntakeTimes = new ObservableCollection<MedicationIntakeTime>(allMedicationIntakeTimes);
        }

        private void GetDrugs()
        {
            Drugs = new ObservableCollection<DrugViewModel>();
            foreach (var drug in _drugService.GetAll().Values)
            {
                Drugs.Add(new DrugViewModel(drug));
            }
        }

        private void CheckAlergen()
        {
            if (SelectedDrug != null && _drugPerscribingService.IsPatientAlergic(SelectedDrug.Id, Appointment.PatientId))
            {
                MessageBox.Show("Dati lek sadrzi alergen na koji je pacijent alergican", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
