using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Commands.Survey;
using Library.Model;
using Library.Service.PersonService.Interface;
using Library.Service.SurveyService;

namespace Library.ViewModel.Structure
{
    public class HospitalSurveyViewModel:ViewModelBase
    {
        private List<SurveryElement> _elementsOfHospitalSurvey;
        public List<SurveryElement> ElementsOfHospitalSurvey
        {
            get
            {
                return _elementsOfHospitalSurvey;
            }
            set
            {
                _elementsOfHospitalSurvey = value;
                OnPropertyChanged(nameof(ElementsOfHospitalSurvey));
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
        private string _hygieneAvg;
        public string HygieneAvg
        {
            get
            {
                return _hygieneAvg;
            }
            set
            {
                _hygieneAvg = value;
                OnPropertyChanged(nameof(HygieneAvg));
            }
        }
        private string _generalAvg;
        public string GeneralAvg
        {
            get
            {
                return _generalAvg;
            }
            set
            {
                _generalAvg = value;
                OnPropertyChanged(nameof(GeneralAvg));
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
        private List<HospitalSurvey> _hospitalSurveys;
        public List<HospitalSurvey> HospitalSurveys
        {
            get
            {
                return _hospitalSurveys;
            }
            set
            {
                _hospitalSurveys = value;
                OnPropertyChanged(nameof(HospitalSurveys));
            }
        }
        private HospitalSurvey _selected;
        public HospitalSurvey Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        public CommandBase ShowSurveyCommand { get; }

        public HospitalSurveyViewModel(IHospitalSurveyService hospitalSurveyService, IPatientService _patientService)
        {
            _elementsOfHospitalSurvey = hospitalSurveyService.GetSurveryElements();
			var dictionray = hospitalSurveyService.GetAvgSurveyElemnts();
			_serviceQualityAvg = "Srednja vrednost ServiceQuality je " + dictionray["ServiceQualityRating"];
            _hygieneAvg = "Srednja vrednost HygieneRating je " + dictionray["HygieneRating"];
            _generalAvg = "Srednja vrednost GeneralRating je " + dictionray["GeneralRating"];
            _recommendationAvg = "Srednja vrednost RecommendationRating je " + dictionray["RecommendationRating"];
            _comments = hospitalSurveyService.GetComments();
            _hospitalSurveys = hospitalSurveyService.GetAll().Values.ToList();
            ShowSurveyCommand = new ShowSurveyCommand(hospitalSurveyService,this,_patientService);
            ShowSurveyCommand.ExcecutionCompleted += ExecutionCompleted;
        }
    }


}
