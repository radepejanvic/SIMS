using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Service;
using Library.View;
using Library.Service.PersonService.Interface;

namespace Library.ViewModel
{
    public class AppointmentViewModel : ViewModelBase
    {
        public  Appointment Appointment;
        public Doctor Doctor;
        public Patient Patient;

        public string DoctorName => Doctor.FirstName + " " + Doctor.LastName;
        public string PatientName => Patient.FirstName + " " + Patient.LastName;
        public int DoctorId => Appointment.DoctorId;
        public int PatientId => Appointment.PatientId;
        public TimeSlot TimeSlot => Appointment.TimeSlot;
        public string IsOperation => Appointment.IsOperation ? "Operacija" : "Pregled";
        private string _fromDate;
        public string FromDate
        {
            get => Appointment.TimeSlot.From.ToString("dd/MM/yyyy hh:mm");
            set => _fromDate = value;
        }

        public string ToDate
        {
            get => Appointment.TimeSlot.To.ToString("dd/MM/yyyy hh:mm");
            set => _fromDate = value;
        }

        public string Duration => Appointment.TimeSlot.GetDuration().ToString();
        public string IsCanceled  => Appointment.IsCanceled ? "Otkazana" : "Zakazana";
        public ICommand OpenMedicalRecordCommand { get; }
        private IPatientService _patientService;
        public AppointmentViewModel(Appointment appointment, IPatientService patientService, IDoctorService doctorService) 
        {
            Appointment = appointment;
            Doctor = doctorService.Get(Appointment.DoctorId);
            Patient = patientService.Get(Appointment.PatientId);

            _patientService = patientService;
            OpenMedicalRecordCommand = new RelayCommand(OpenMedicalRecord, CanCreateRow);
        }

        public bool CanCreateRow()
        {
            return true;
        }

        public void OpenMedicalRecord()
        {
            var createAppointmentView = new MedicalRecordDoctorView(new PatientViewModel(Patient), _patientService);
            createAppointmentView.ShowDialog();
        }

        public int GetDuration()
        {
            return (int)(Appointment.TimeSlot.To - Appointment.TimeSlot.From).TotalMinutes;
        }
    }
}
