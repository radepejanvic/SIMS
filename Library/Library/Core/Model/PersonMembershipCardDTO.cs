using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class PersonMembershipCardDTO
    {
        public int MembershipCardId;
        public string Name;
        public string Surname;
        public string JMBG;

        public PersonMembershipCardDTO(MembershipCard memberhipCard, Person person)
        {
            MembershipCardId = memberhipCard.Id;
            Name = person.Name;
            Surname = person.Surname;
            JMBG = person.JMBG;
        }
    }
}
