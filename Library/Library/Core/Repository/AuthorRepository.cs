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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ICRUDRepository<Author> _repo;

        public AuthorRepository(ICRUDRepository<Author> repo)
        {
            _repo = repo;
        }

        public void Add(Author author)
        {
            _repo.Add(author);
        }

        public void Update(Author author)
        {
            _repo.Update(author);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Author Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Author> GetAll()
        {
            return _repo.GetAll();
        }

    }
}
