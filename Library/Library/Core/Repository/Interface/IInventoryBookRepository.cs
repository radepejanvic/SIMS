using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IInventoryBookRepository
    {
        void Add(InventoryBook inventoryBook);
        InventoryBook Get(int id);
        Dictionary<int, InventoryBook> GetAll();
        void Remove(int id);
        void Update(InventoryBook inventoryBook);
    }
}