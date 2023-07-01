using Library.Core.Model;
using Library.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ICRUDRepository<Person> _repo;

        public PersonRepository(ICRUDRepository<Person> repo)
        {
            _repo = repo;
        }

        public void Add(Person person)
        {
            _repo.Add(person);
        }

        public void Update(Person person)
        {
            _repo.Update(person);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Person Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Person> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
