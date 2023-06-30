using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.PersonService.Interface;
using Library.Service.SurveyService;
using Library.View;
using Library.View.Form;
using Library.ViewModel.Form;
using Library.ViewModel.Structure;

namespace Library.Commands.Survey
{
    public class ShowHospitalSurveyCommand : CommandBase
    {

        protected IHospitalSurveyService _hospitalSurveyService;
        private IPatientService _patientService;
        public ShowHospitalSurveyCommand(IHospitalSurveyService hospitalSurveyService, IPatientService patientService)
        {
            _hospitalSurveyService = hospitalSurveyService;
            _patientService = patientService;
        }

        public override void Execute(object? parameter)
        {
            var hospitalSurveyView = new HospitalSurveyView();
            hospitalSurveyView.DataContext = new HospitalSurveyViewModel(_hospitalSurveyService,_patientService);
            hospitalSurveyView.Show();
        }

    }
}
