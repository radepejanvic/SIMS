using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Commands;
using Library.Commands.Survey;
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.SurveyService;

namespace Library.ViewModel.Table
{
    public class DoctorSurveyTableViewModel : ViewModelBase
    {
        private ObservableCollection<DoctorViewModel> _doctors;
        public ObservableCollection<DoctorViewModel> Doctors
        {
            get
            {
                return _doctors;
            }
            set
            {
                _doctors = value;
                OnPropertyChanged(nameof(Doctors));
            }
        }
        private ObservableCollection<DoctorSurvey> _doctorSurveys;
        public ObservableCollection<DoctorSurvey> DoctorSurveys
        {
            get
            {
                return _doctorSurveys;
            }
            set
            {
                _doctorSurveys = value;
                OnPropertyChanged(nameof(DoctorSurveys));
            }
        }
        private DoctorViewModel _selectedDoctor;
        public DoctorViewModel SelectedDoctor
        {
            get
            {
                return _selectedDoctor;
            }
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged(nameof(SelectedDoctor));
            }
        }
        private DoctorSurvey _selectedDoctorSurvey;
        public DoctorSurvey SelectedDoctorSurvey
        {
            get
            {
                return _selectedDoctorSurvey;
            }
            set
            {
                _selectedDoctorSurvey = value;
                OnPropertyChanged(nameof(SelectedDoctorSurvey));
            }
        }
         public CommandBase ShowDoctorSurvey { get; }
        public CommandBase ShowDoctorSurveyAlalitics { get; }
        public DoctorSurveyTableViewModel(IDoctorSurveyService doctorSurveyService, IDoctorService _doctorService, IAppointmentService _appointmentService)
        {
            _doctorSurveys =new ObservableCollection<DoctorSurvey>( doctorSurveyService.GetAll().Values.ToList());
            _doctors = new ObservableCollection<DoctorViewModel>(_doctorService.GetAll().Values.Select(o=>new DoctorViewModel(o)).ToList());
            ShowDoctorSurvey = new ShowDoctorSurvey(this,_doctorService,_appointmentService);
            ShowDoctorSurvey.ExcecutionCompleted += ExecutionCompleted;
            ShowDoctorSurveyAlalitics = new ShowDoctorSurveyAlatics(this,doctorSurveyService,_appointmentService);
        }
    }
}
