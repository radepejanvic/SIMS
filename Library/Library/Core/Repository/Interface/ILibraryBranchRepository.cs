using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface ILibraryBranchRepository
    {
        void Add(LibraryBranch libraryBranch);
        LibraryBranch Get(int id);
        Dictionary<int, LibraryBranch> GetAll();
        void Remove(int id);
        void Update(LibraryBranch libraryBranch);
    }
}