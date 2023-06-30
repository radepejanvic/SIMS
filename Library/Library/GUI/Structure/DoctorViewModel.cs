using System.Windows;
using Library.Model;
using Library.Model.Enum;

namespace Library.ViewModel
{
    public  class DoctorViewModel : ViewModelBase
    {
        public  Doctor Doctor; 
        public string FullName => Doctor.FirstName + " " +Doctor.LastName;
        public Specialization Specialization => Doctor.Specialization;
        public int Id => Doctor.Id;
        public double AverageReview { get; }
        public DoctorViewModel(Doctor doctor)
        {
            Doctor = doctor;
        }
    }
}