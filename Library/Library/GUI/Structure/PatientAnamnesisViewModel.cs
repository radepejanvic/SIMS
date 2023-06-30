using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Model.Enum;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.View;

namespace Library.ViewModel.Structure
{
    public class PatientAnamnesisViewModel : ViewModelBase
    {
        private Doctor _doctor;
        public Anamnesis Anamnesis;
        public string DoctorName => $"{_doctor.FirstName} {_doctor.LastName}";
        public string Specialization => _doctor.Specialization.ToString();
        public string AnamnesisDescription => $"{Anamnesis?.Sympthoms ?? " "} {Anamnesis?.Observations ?? " "} {Anamnesis?.Conclusions ?? " "}";
        public PatientAnamnesisViewModel(Anamnesis anamnesis, IDoctorService doctorService, IAppointmentService appointmentService)
        {
            Anamnesis = anamnesis;
            _doctor = doctorService.Get(appointmentService.Get(anamnesis.AppointmentId).DoctorId);
        }

        
    }
}
