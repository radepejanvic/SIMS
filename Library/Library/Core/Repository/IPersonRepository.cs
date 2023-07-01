using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository
{
    public interface IPersonRepository
    {
        void Add(Person person);
        Person Get(int id);
        Dictionary<int, Person> GetAll();
        void Remove(int id);
        void Update(Person person);
    }
}