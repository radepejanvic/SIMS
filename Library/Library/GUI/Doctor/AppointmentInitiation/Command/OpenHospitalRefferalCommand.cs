using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.RefferalService.Interface;
using Library.View.Form;
using Library.View.Table;
using Library.ViewModel.Form;
using Library.ViewModel.Structure;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class OpenHospitalRefferalCommand: CommandBase
    {
        private IDrugService _drugService;
        private IDrugPerscribingService _drugPerscribingService;
        private IHospitalRefferalService _hospitalRefferalService;
        private Appointment _appointment;
        public OpenHospitalRefferalCommand(Appointment appointment, IDrugService drugService, 
            IDrugPerscribingService drugPerscribingService, IHospitalRefferalService hospitalRefferalService)
        {
            _appointment = appointment;

            _drugService = drugService;
            _drugPerscribingService = drugPerscribingService;
            _hospitalRefferalService = hospitalRefferalService;
        }
        public override bool CanExecute(object? parameter)
        {
            return true;
        }
        public override void Execute(object? parameter)
        {
            var hospitalRefferalView = new HospitalRefferalFormView();
            hospitalRefferalView.DataContext = new HospitalRefferalFormViewModel(_appointment, _drugService, _drugPerscribingService,
                _hospitalRefferalService);
            hospitalRefferalView.ShowDialog();
        }
    }
}
