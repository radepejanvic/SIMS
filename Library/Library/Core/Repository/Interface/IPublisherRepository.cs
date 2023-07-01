using Library.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repository.Interface
{
    public interface IPublisherRepository
    {
        void Add(Publisher publisher);
        Publisher Get(int id);
        Dictionary<int, Publisher> GetAll();
        void Remove(int id);
        void Update(Publisher publisher);
    }
}
