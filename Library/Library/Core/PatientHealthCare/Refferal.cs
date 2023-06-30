using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model.Refferal
{
    public abstract class Refferal : ISerializable
    {
        public int Id { get; set; }
        public int PatientId;
        public bool IsValid;

        public Refferal()
        {

        }

        public Refferal(int patientId)
        {
            PatientId = patientId;
            IsValid = true;
        }

        public void UseRefferal()
        {
            IsValid = false;
        }
    }
}
