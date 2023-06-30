using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model.Refferal;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.RefferalService;
using Library.Service.RefferalService.Interface;
using Library.ViewModel.Form;

namespace Library.Commands
{
    public class CreateHospitalRefferalCommand: CommandBase
    {
        private IHospitalRefferalService _hospitalRefferalService;
        private HospitalRefferalFormViewModel _hospitalRefferalFormViewModel;

        public CreateHospitalRefferalCommand(HospitalRefferalFormViewModel hospitalRefferalFormViewModel, IHospitalRefferalService hospitalRefferalService)
        {
            _hospitalRefferalService = hospitalRefferalService;

            _hospitalRefferalFormViewModel = hospitalRefferalFormViewModel;
            _hospitalRefferalFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return _hospitalRefferalFormViewModel.Duration is not null;
        }
        public override void Execute(object? parameter)
        {
            var hospitalRefferal = new HospitalRefferal(_hospitalRefferalFormViewModel.Appointment.PatientId,
                int.Parse(_hospitalRefferalFormViewModel.Duration), _hospitalRefferalFormViewModel.Appointment.Id, 
                _hospitalRefferalFormViewModel.AdditionalAnalysis);
            _hospitalRefferalService.Add(hospitalRefferal);
            MessageBox.Show("Uspešno ste dodali bolnicko lecenje", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_hospitalRefferalFormViewModel.SelectedDrug) ||
                e.PropertyName == nameof(_hospitalRefferalFormViewModel.Duration) ||
                e.PropertyName == nameof(_hospitalRefferalFormViewModel.AdditionalAnalysis))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
