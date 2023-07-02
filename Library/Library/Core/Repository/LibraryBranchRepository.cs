using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repository
{
    public class LibraryBranchRepository : ILibraryBranchRepository
    {
        private readonly ICRUDRepository<LibraryBranch> _repo;

        public LibraryBranchRepository(ICRUDRepository<LibraryBranch> repo)
        {
            _repo = repo;
        }

        public void Add(LibraryBranch libraryBranch)
        {
            _repo.Add(libraryBranch);
        }

        public void Update(LibraryBranch libraryBranch)
        {
            _repo.Update(libraryBranch);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public LibraryBranch Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, LibraryBranch> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
