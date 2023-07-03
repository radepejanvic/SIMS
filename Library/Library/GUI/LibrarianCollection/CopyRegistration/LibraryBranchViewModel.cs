using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.CopyRegistration
{
    public class LibraryBranchViewModel : ViewModelBase
    {
        private readonly LibraryBranch _branch;

        public int Id => _branch.Id;
        public string Name => _branch.Name;


        public LibraryBranchViewModel(LibraryBranch branch)
        {
            _branch = branch;
        }
    }
}
