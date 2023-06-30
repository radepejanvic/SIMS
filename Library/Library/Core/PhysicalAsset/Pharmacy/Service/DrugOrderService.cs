using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Service.FarmaceuticalService
{
    public class DrugOrderService : IDrugOrderService
    {
        private IDrugOrderRepository _crud;

        public DrugOrderService(IDrugOrderRepository crud)
        {
            _crud = crud;
        }

        public void Add(DrugOrder drug)
        {
            _crud.Add(drug);
        }

        public void Update(DrugOrder drug)
        {
            _crud.Update(drug);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public DrugOrder Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, DrugOrder> GetAll()
        {
            return _crud.GetAll();
        }

        public Dictionary<int, DrugOrder> GetAllUnfinished(DateTime date)
        {
            return _crud.GetAllUnfinished(date);
        }
    }
}
