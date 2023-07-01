using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IPersonRepository
    {
        void Add(Person person);
        Person Get(int id);
        Person? Get(string JMBG);
        Dictionary<int, Person> GetAll();
        void Remove(int id);
        void Update(Person person);
    }
}