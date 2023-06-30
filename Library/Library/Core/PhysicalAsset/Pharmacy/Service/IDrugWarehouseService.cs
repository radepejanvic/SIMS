using System.Collections.Generic;
using Library.Model;

namespace Library.Service.FarmaceuticalService
{
    public interface IDrugWarehouseService
    {
        void CreateDrugOrder(KeyValuePair<int, int> order);
        void Restock(DrugOrder drugOrder);
        void RestockAll();
    }
}