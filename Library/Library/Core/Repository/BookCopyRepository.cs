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
    public class BookCopyRepository : IBookCopyRepository
    {
        private readonly ICRUDRepository<BookCopy> _repo;

        public BookCopyRepository(ICRUDRepository<BookCopy> repo)
        {
            _repo = repo;
        }

        public void Add(BookCopy bookCopy)
        {
            _repo.Add(bookCopy);
        }

        public void Update(BookCopy bookCopy)
        {
            _repo.Update(bookCopy);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public BookCopy Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, BookCopy> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
