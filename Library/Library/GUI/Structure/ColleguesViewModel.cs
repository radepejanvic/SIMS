using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel.Structure
{
    public class ColleguesViewModel : ViewModelBase
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }

        public ColleguesViewModel(string firstName, string lastName, string username, string type)
        {
            FullName = firstName + " " + lastName;
            Username = username;
            Type = type;
        }
    }
}
