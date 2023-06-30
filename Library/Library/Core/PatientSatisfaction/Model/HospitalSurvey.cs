using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class HospitalSurvey : Survey
    {
        public int ServiceQualityRating { get; set; }
        public int HygieneRating { get; set; }
        public int GeneralRating { get; set; }
        public int RecommendationRating { get; set; }
        public int PatientId;
        public HospitalSurvey() { }
        public HospitalSurvey(int serviceQualityRating, int hygieneRating, int generalRating,int recommendationRating, string comment, int patientId) : base(comment)
        {
            ServiceQualityRating = serviceQualityRating;
            HygieneRating = hygieneRating;
            GeneralRating = generalRating;
            RecommendationRating = recommendationRating;
            PatientId = patientId;
        }
    }
}
