using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Model.Refferal;

namespace Library.ViewModel.Structure.Refferal
{
    public class DoctorRefferalViewModel
    {
        private readonly DoctorRefferal _doctorRefferal;

        public int Id => _doctorRefferal.Id;
        public int Duration => _doctorRefferal.Duration;
        public int DoctorId => _doctorRefferal.DoctorId;
        public Specialization? Specialization => _doctorRefferal.Specialization;
        public string IsOperation => _doctorRefferal.IsOperation ? "Operacija" : "Pregled";

        public DoctorRefferalViewModel(DoctorRefferal doctorRefferal)
        {
            _doctorRefferal = doctorRefferal;
        }

        public DoctorRefferal GetDoctorRefferal()
        {
            return _doctorRefferal;
        }
    }
}
