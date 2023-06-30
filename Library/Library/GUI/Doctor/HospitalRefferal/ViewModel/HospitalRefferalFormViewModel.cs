using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Model.Enum;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.RefferalService.Interface;
using Library.ViewModel.Structure.Farmacy;

namespace Library.ViewModel.Form
{
    public class HospitalRefferalFormViewModel: ViewModelBase
    {
        public ObservableCollection<DrugViewModel> SelectedDrugs { get; set; }
        public ObservableCollection<DrugViewModel> AvaliableDrugs{ get; set; }

        private DrugViewModel _selectedDrug;
        public DrugViewModel SelectedDrug
        {
            get { return _selectedDrug; }
            set
            {
                _selectedDrug = value;
                OnPropertyChanged(nameof(SelectedDrug));
            }
        }

        private string _duration;
        public string Duration
        {
            get
            {
                return _duration;

            }
            set
            {
                if (Regex.IsMatch(value, "^[0-9]+$"))
                {
                    _duration = value;
                    OnPropertyChanged(nameof(Duration));
                }
            }
        }

        private bool _additionalAnalysis;
        public bool AdditionalAnalysis
        {
            get { return _additionalAnalysis; }
            set
            {
                if (_additionalAnalysis != value)
                {
                    _additionalAnalysis = value;
                    OnPropertyChanged(nameof(AdditionalAnalysis));
                }
            }
        }
        public Appointment Appointment { get; set; }
        public ICommand AddDrug { get; }
        public ICommand CreateHospitalRefferal { get; }

        private IDrugService _drugService;
        private IDrugPerscribingService _drugPerscribingService;

        public HospitalRefferalFormViewModel(Appointment appointment, IDrugService drugService, IDrugPerscribingService drugPerscribingService, IHospitalRefferalService hospitalRefferalService)
        {
            _drugService = drugService;
            _drugPerscribingService = drugPerscribingService;

            AvaliableDrugs = GetAvaliableDrugs();
            SelectedDrugs = new ObservableCollection<DrugViewModel>();
            Appointment = appointment;

            AddDrug = new AddDrugCommand(this, false, drugService, drugPerscribingService, Appointment);
            CreateHospitalRefferal = new CreateHospitalRefferalCommand(this, hospitalRefferalService);
        }

        private ObservableCollection<DrugViewModel> GetAvaliableDrugs()
        {
            var allDrugs = GetDrugs();
            if (AvaliableDrugs != null)
            {
                foreach (var drug in AvaliableDrugs)
                {
                    allDrugs.Remove(drug);
                }
            }
            return new ObservableCollection<DrugViewModel>(allDrugs);
        }
        
        private ObservableCollection<DrugViewModel> GetDrugs()
        {
            var allDrugs = new ObservableCollection<DrugViewModel>();
            foreach (var drug in _drugService.GetAll().Values)
            {
                allDrugs.Add(new DrugViewModel(drug));
            }

            return allDrugs;
        }
    }
}
