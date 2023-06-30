using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.SurveyService;
using Library.ViewModel.Structure;

namespace Library.ViewModel
{
    public class DoctorSurveyModelView :ViewModelBase
    {
        private ObservableCollection<SurveyElementViewModel> _elementsOfDoctorSurvey;
        public ObservableCollection<SurveyElementViewModel> ElementsOfDoctorSurvey
        {
            get
            {
                return _elementsOfDoctorSurvey;
            }
            set
            {
                _elementsOfDoctorSurvey = value;
                OnPropertyChanged(nameof(ElementsOfDoctorSurvey));
            }
        }
        private List<string> _comments;
        public List<string> Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }
        private string _serviceQualityAvg;
        public string ServiceQualityAvg
        {
            get
            {
                return _serviceQualityAvg;
            }
            set
            {
                _serviceQualityAvg = value;
                OnPropertyChanged(nameof(ServiceQualityAvg));
            }
        }

        private string _recommendationAvg;
        public string RecommendationAvg
        {
            get
            {
                return _recommendationAvg;
            }
            set
            {
                _recommendationAvg = value;
                OnPropertyChanged(nameof(RecommendationAvg));
            }
        }



        public DoctorSurveyModelView(DoctorViewModel selectedDoctor, IDoctorSurveyService doctorSurveyService , IAppointmentService _appointmentService)
        {
            _elementsOfDoctorSurvey = new ObservableCollection<SurveyElementViewModel>(doctorSurveyService.GetAllbyId(selectedDoctor.Id, _appointmentService).Select(o => new SurveyElementViewModel(o)));
            _serviceQualityAvg = "Srednja vrednost ServiceQuality je " + _elementsOfDoctorSurvey.Where(o => o.Name == "ServiceQualityRating").First().SurveryElement.GetAvg().ToString();
            _recommendationAvg = "Srednja vrednost RecommendationRating je " + _elementsOfDoctorSurvey.Where(o => o.Name == "RecommendationRating").First().SurveryElement.GetAvg();
            _comments = doctorSurveyService.GetComments();
        }
    }
}