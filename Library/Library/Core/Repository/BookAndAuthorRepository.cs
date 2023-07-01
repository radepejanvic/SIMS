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
    public class BookAndAuthorRepository : IBookAndAuthorRepository
    {
        private readonly ICRUDRepository<BookAndAuthor> _repo;

        public BookAndAuthorRepository(ICRUDRepository<BookAndAuthor> repo)
        {
            _repo = repo;
        }

        public void Add(BookAndAuthor bookAndAuthor)
        {
            _repo.Add(bookAndAuthor);
        }

        public void Update(BookAndAuthor bookAndAuthor)
        {
            _repo.Update(bookAndAuthor);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public BookAndAuthor Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, BookAndAuthor> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
