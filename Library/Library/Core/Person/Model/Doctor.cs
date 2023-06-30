using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Serializer;

namespace Library.Model
{
    public class Doctor : Person, ISerializable
    {
        [JsonProperty("Specialization")]
        public Specialization Specialization;

        public Doctor()
        {

        }
        public Doctor(int id, string username, string firstName, string lastName, string password, Specialization specialization) : base(id, username, firstName, lastName, password)
        {
            Specialization = specialization;
        }
    }
}
