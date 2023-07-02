using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.BookLoaning.ViewModel
{
    public class PersonMembershipCardViewModel : ViewModelBase
    {
        private readonly PersonMembershipCardDTO _personMembership;

        public int MembershipCardId => _personMembership.MembershipCardId;
        public string Name => _personMembership.Name;
        public string Surname => _personMembership.Surname;
        public string JMBG => _personMembership.JMBG;

        public PersonMembershipCardViewModel(PersonMembershipCardDTO personMembership)
        {
            _personMembership = personMembership;
        }

        public bool Contains(string keyword)
        {
            return $"{MembershipCardId}--{Name}--{Surname}--{JMBG}".ToLower().Contains(keyword.ToLower());
        }
    }
}
