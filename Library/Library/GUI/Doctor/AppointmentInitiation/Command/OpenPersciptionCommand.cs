using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.FarmaceuticalService.Interface;
using Library.View.Form;
using Library.ViewModel.Form;

namespace Library.Commands
{
    public class OpenPersciptionCommand: CommandBase
    {
        private IDrugService _drugService;
        private IDrugPerscribingService _drugPerscribingService;
        private bool _isPersciption;
        private Appointment _appointment;
        public OpenPersciptionCommand(bool isPersciption, IDrugService drugService, IDrugPerscribingService drugPerscribingService, 
            Appointment appointment)
        {
            _drugService = drugService;
            _drugPerscribingService = drugPerscribingService;

            _isPersciption = isPersciption;

            _appointment = appointment;
        }
        public override bool CanExecute(object? parameter)
        {
            return true;
        }
        public override void Execute(object? parameter)
        {
            var drugInstructionFormView = new DrugInstructionFormView();
            drugInstructionFormView.DataContext = new DrugInstructionFormViewModel(_isPersciption, null, _drugService, 
                _drugPerscribingService, _appointment);
            drugInstructionFormView.ShowDialog();

        }

    }
}
