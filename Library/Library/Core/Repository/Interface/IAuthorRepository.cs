using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        Author Get(int id);
        Dictionary<int, Author> GetAll();
        void Remove(int id);
        void Update(Author author);
    }
}