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
    public class BookTitleRepository : IBookTitleRepository
    {
        private readonly ICRUDRepository<BookTitle> _repo;

        public BookTitleRepository(ICRUDRepository<BookTitle> repo)
        {
            _repo = repo;
        }

        public void Add(BookTitle bookTitle)
        {
            _repo.Add(bookTitle);
        }

        public void Update(BookTitle bookTitle)
        {
            _repo.Update(bookTitle);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public BookTitle Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, BookTitle> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
