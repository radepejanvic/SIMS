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
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ICRUDRepository<Publisher> _repo;

        public PublisherRepository(ICRUDRepository<Publisher> repo)
        {
            _repo = repo;
        }

        public void Add(Publisher publisher)
        {
            _repo.Add(publisher);
        }

        public void Update(Publisher publisher)
        {
            _repo.Update(publisher);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Publisher Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Publisher> GetAll()
        {
            return _repo.GetAll();
        }

    }
    
}
