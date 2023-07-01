using Library.Core.Model;
using Library.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repository
{
    public class InventoryBookRepository : IInventoryBookRepository
    {
        private readonly ICRUDRepository<InventoryBook> _repo;

        public InventoryBookRepository(ICRUDRepository<InventoryBook> repo)
        {
            _repo = repo;
        }

        public void Add(InventoryBook inventoryBook)
        {
            _repo.Add(inventoryBook);
        }

        public void Update(InventoryBook inventoryBook)
        {
            _repo.Update(inventoryBook);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public InventoryBook Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, InventoryBook> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
