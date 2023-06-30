using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.View.Table;
using Library.ViewModel.Table;

namespace Library.Commands.Farmacy
{
    public class ExtendTherapyCommand : CommandBase
    {
        private readonly PatientPerscriptionTableViewModel _patientPerscriptionTableViewModel;
        private readonly IDrugPerscribingService _drugPerscribingService;
        private readonly IDrugService _drugService;

        public ExtendTherapyCommand(PatientPerscriptionTableViewModel patientPerscriptionTableViewModel, IDrugPerscribingService drugPerscribingService, IDrugService drugService)
        {
            _patientPerscriptionTableViewModel = patientPerscriptionTableViewModel;
            _drugPerscribingService = drugPerscribingService;
            _drugService = drugService;
            _patientPerscriptionTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_patientPerscriptionTableViewModel.SelectedPerscription is not null) && 
                    _drugPerscribingService.IsExtendable(_patientPerscriptionTableViewModel.SelectedPerscription.Id) && 
                    _drugService.IsAvaliable(_patientPerscriptionTableViewModel.SelectedPerscription.DrugId);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _drugPerscribingService.ExtendPerscription(_patientPerscriptionTableViewModel.SelectedPerscription.Id);
                OnExecutionCompleted(true, "Terapija je uspešno produžena.");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom produžavanja terapije.");
            }
            
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientPerscriptionTableViewModel.SelectedPerscription))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
