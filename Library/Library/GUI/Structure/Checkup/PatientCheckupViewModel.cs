using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Checkup;
using Library.Model.Enum;

namespace Library.ViewModel.Structure.Checkup
{
    public class PatientCheckupViewModel : ViewModelBase
    {
        private PatientCheckup _patientCheckup;

        public int Id => _patientCheckup.Id;
        public int PatientId => _patientCheckup.PatientId;
        public DateOnly DateOfCheckup => _patientCheckup.DateOfCheckup;
        public TimeOfCheckup TimeOfCheckup => _patientCheckup.TimeOfCheckup;
        public int SystolicPressure => _patientCheckup.SystolicPressure;
        public int DiastolicPressure => _patientCheckup.DiastolicPressure;
        public float Temperature => _patientCheckup.Temperature;
        public string Observations => _patientCheckup.Observations;

        public PatientCheckupViewModel(PatientCheckup patientCheckup)
        {
            _patientCheckup = patientCheckup;
        }
    }
}
