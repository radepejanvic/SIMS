using System.Runtime.CompilerServices;
using System.Windows.Input;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.SurveyService;
using Library.View;
using Library.View.Table.Survey;
using Library.ViewModel.Structure;
using Library.ViewModel.Table;

namespace Library.Commands.Survey
{
    public class ShowDoctorSurveyTableCommand : CommandBase
    {
        private IDoctorSurveyService _doctorSurveyService;
        private IDoctorService _doctorService;
        private IAppointmentService _appointmentService;
        

        public ShowDoctorSurveyTableCommand(IDoctorSurveyService doctorSurveyService, IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _doctorSurveyService = doctorSurveyService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }

        public override void Execute(object? parameter)
        {
            var doctorSurveyView = new DoctorSurveyTableView();
            doctorSurveyView.DataContext = new DoctorSurveyTableViewModel(_doctorSurveyService,_doctorService,_appointmentService);
            doctorSurveyView.Show();
        }
    }
}