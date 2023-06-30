using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.View.Form;
using Library.View.Table;
using Library.ViewModel.Form;
using Library.ViewModel.Structure;
using Library.ViewModel.Structure.Farmacy;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class AddDrugCommand: CommandBase
    {
        private IDrugService _drugService;
        private IDrugPerscribingService _drugPerscribingService;
        private HospitalRefferalFormViewModel _hospitalRefferalFormViewModel;
        private bool _isPersciption;
        private Appointment _appointment;
        public AddDrugCommand(HospitalRefferalFormViewModel hospitalRefferalFormViewModel, bool isPersciption, IDrugService drugService, IDrugPerscribingService drugPerscribingService, Appointment appointment)
        {
            _drugService = drugService;
            _drugPerscribingService = drugPerscribingService;

            _hospitalRefferalFormViewModel = hospitalRefferalFormViewModel;
            _isPersciption = isPersciption;

            _appointment = appointment;
            _hospitalRefferalFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return _hospitalRefferalFormViewModel.SelectedDrug is not null;
        }
        public override void Execute(object? parameter)
        {
            var drugInstructionFormView = new DrugInstructionFormView();
            drugInstructionFormView.DataContext = new DrugInstructionFormViewModel(_isPersciption, _hospitalRefferalFormViewModel.SelectedDrug, _drugService, _drugPerscribingService, _appointment);
            drugInstructionFormView.ShowDialog();
            _hospitalRefferalFormViewModel.SelectedDrugs.Add(_hospitalRefferalFormViewModel.SelectedDrug);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_hospitalRefferalFormViewModel.SelectedDrug) ||
                e.PropertyName == nameof(_hospitalRefferalFormViewModel.SelectedDrugs))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
