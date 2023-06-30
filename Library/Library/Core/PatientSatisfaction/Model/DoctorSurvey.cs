using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class DoctorSurvey : Survey
    {
        public int ServiceQualityRating { get; set; }
        public int RecommendationRating { get; set; }
        public int AppointmentId;
        public DoctorSurvey() {}
        public DoctorSurvey(int serviceQualityRating, int recommendationRating,int appointmentId, string comment) : base(comment) 
        { 
            ServiceQualityRating = serviceQualityRating;
            RecommendationRating = recommendationRating;
            AppointmentId = appointmentId;
        }
    }
}
