using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Service.FarmaceuticalService.Interface;
using Library.View.Form;
using Library.ViewModel.Form;
using Library.ViewModel.Structure.Farmacy;

namespace Library.Commands
{
    public class CreatePerscriptionCommand: CommandBase
    {
        private IDrugPerscribingService _drugPerscribingService;
        private DrugInstructionFormViewModel _drugInstructionFormViewModel;
        private Appointment _appointment;

        public CreatePerscriptionCommand(DrugInstructionFormViewModel drugInstructionFormViewModel, 
            IDrugPerscribingService drugPerscribingService, Appointment appointment)
        {
            _drugPerscribingService = drugPerscribingService;
            _appointment = appointment;

            _drugInstructionFormViewModel = drugInstructionFormViewModel;
            _drugInstructionFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return _drugInstructionFormViewModel.SelectedDrug is not null &&
                _drugInstructionFormViewModel.MedicationIntakeTimes is not null &&
                _drugInstructionFormViewModel.AmountPerDose is not null &&
                _drugInstructionFormViewModel.TherapyDuration is not null &&
                _drugInstructionFormViewModel.TimesPerDay is not null;
        }
        public override void Execute(object? parameter)
        {
            _drugPerscribingService.PerscribeTherapy(_appointment.Id, _appointment.PatientId,
                _drugInstructionFormViewModel.SelectedDrug.Id, GetInstruction());
            MessageBox.Show("Uspešno ste prepisali recept za lek", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_drugInstructionFormViewModel.SelectedDrug) ||
                e.PropertyName == nameof(_drugInstructionFormViewModel.MedicationIntakeTimes) ||
                e.PropertyName == nameof(_drugInstructionFormViewModel.AmountPerDose) ||
                e.PropertyName == nameof(_drugInstructionFormViewModel.TherapyDuration) ||
                e.PropertyName == nameof(_drugInstructionFormViewModel.TimesPerDay))
            {
                OnCanExecutedChanged();
            }
        }

        private Instruction GetInstruction()
        {
            return new Instruction(int.Parse(_drugInstructionFormViewModel.TimesPerDay), 
                int.Parse(_drugInstructionFormViewModel.AmountPerDose), _drugInstructionFormViewModel.AdditionalComments, 
                _drugInstructionFormViewModel.SelectedMedicationIntakeTime);
        }
    }
}
