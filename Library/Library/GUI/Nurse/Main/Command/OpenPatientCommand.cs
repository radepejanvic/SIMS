using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Service.PersonService.Interface;
using Library.View;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class OpenPatientCommand : CommandBase
    {
        private PatientTableViewModel _patientTableViewModel;
        private IPatientService _patientService;
        public OpenPatientCommand(PatientTableViewModel patientTableViewModel, IPatientService patientService)
        {
            _patientService = patientService;
            _patientTableViewModel = patientTableViewModel;
        }

        public override void Execute(object? parameter)
        {
            var popup = new PatientFormView(_patientTableViewModel, _patientService);
            popup.ShowDialog();
        }
    }
}
