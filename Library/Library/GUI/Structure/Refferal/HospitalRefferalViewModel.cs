using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Refferal;

namespace Library.ViewModel.Structure.Refferal
{
    public class HospitalRefferalViewModel
    {
        private readonly HospitalRefferal _hospitalRefferal;

        public int Id => _hospitalRefferal.Id;
        public int PatientId => _hospitalRefferal.PatientId;
        public int Duration => _hospitalRefferal.Duration;
        public string AdditionalAnalysis => _hospitalRefferal.AdditionalAnalysis ? "Potrebna dalja ispitivanja" : "/";

        public HospitalRefferalViewModel(HospitalRefferal hospitalRefferal)
        {
            _hospitalRefferal = hospitalRefferal;
        }
    }
}
