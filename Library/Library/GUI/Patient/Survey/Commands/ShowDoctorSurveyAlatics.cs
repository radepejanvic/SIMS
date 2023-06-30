using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.SurveyService;
using Library.View;
using Library.ViewModel;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands.Survey
{
    internal class ShowDoctorSurveyAlatics : CommandBase
    {
        private DoctorSurveyTableViewModel doctorSurveyTableViewModel;
        private IDoctorSurveyService doctorSurveyService;
        private IAppointmentService _appointmentService;

        public ShowDoctorSurveyAlatics(DoctorSurveyTableViewModel doctorSurveyTableViewModel, IDoctorSurveyService doctorSurveyService , IAppointmentService _appointmentService)
        {
            this.doctorSurveyTableViewModel = doctorSurveyTableViewModel;
            this.doctorSurveyService = doctorSurveyService;
            this._appointmentService = _appointmentService;
            doctorSurveyTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return (doctorSurveyTableViewModel.SelectedDoctor is not null);
        }

        public override void Execute(object? parameter)
        {
            var doctorSurveyView = new DoctorSurveyView();
            doctorSurveyView.DataContext = new DoctorSurveyModelView(doctorSurveyTableViewModel.SelectedDoctor,doctorSurveyService,_appointmentService);
            doctorSurveyView.Show();
        
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(doctorSurveyTableViewModel.SelectedDoctor))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
