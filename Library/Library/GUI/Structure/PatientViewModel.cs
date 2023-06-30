using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Model.Enum;
using Library.View;
using Library.View.Form;
using Library.ViewModel.Form;

namespace Library.ViewModel
{
    public class PatientViewModel : ViewModelBase  
    {
        private Patient _patient;
        public Patient Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        public int Id => _patient.Id;
        public string Name => _patient.FirstName + " " + _patient.LastName;
        public string Username => _patient.Username;
        public string FirstName => _patient.FirstName;
        public string LastName => _patient.LastName;
        public string Password => _patient.Password;
        public string HasMedicalRecord => (MedicalRecord.Height == 0) ? "Nema zdravstveni karton" : "";

        public MedicalRecordViewModel MedicalRecord { get; set; }
        public PatientViewModel(Patient patient)
        {
            _patient = patient;
            MedicalRecord = new MedicalRecordViewModel(_patient.MedicalRecord);
        }
    }
}
