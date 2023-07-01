using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IBookAndAuthorRepository
    {
        void Add(BookAndAuthor bookAndAuthor);
        BookAndAuthor Get(int id);
        Dictionary<int, BookAndAuthor> GetAll();
        void Remove(int id);
        void Update(BookAndAuthor bookAndAuthor);
    }
}