using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;

namespace Library.ViewModel
{
    public class MedicalRecordViewModel : ViewModelBase
    {
        private MedicalRecord _medicalRecord { get; set; }

        public double Height => _medicalRecord.Height;
        public double Weight => _medicalRecord.Weight;

        public List<Disease> Diseases => _medicalRecord.Diseases; 
        public List<Alergy> Alergies => _medicalRecord.Alergies;

        public MedicalRecordViewModel(MedicalRecord medicalRecord)
        {
            _medicalRecord = medicalRecord;
        }
    }
}
