using System;
using System.Collections.Generic;
using Library.Model;

namespace Library.Service.FarmaceuticalService
{
    public interface IDrugOrderService
    {
        void Add(DrugOrder drug);
        DrugOrder Get(int id);
        Dictionary<int, DrugOrder> GetAll();
        Dictionary<int, DrugOrder> GetAllUnfinished(DateTime date);
        void Remove(int id);
        void Update(DrugOrder drug);
    }
}