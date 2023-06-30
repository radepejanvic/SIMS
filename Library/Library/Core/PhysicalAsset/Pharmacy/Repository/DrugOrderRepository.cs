using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class DrugOrderRepository : IDrugOrderRepository
    {
        private ICRUDRepository<DrugOrder> _repo;

        public DrugOrderRepository(ICRUDRepository<DrugOrder> repo)
        {
            _repo = repo;
        }

        public void Add(DrugOrder drug)
        {
            _repo.Add(drug);
        }

        public void Update(DrugOrder drug)
        {
            _repo.Update(drug);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public DrugOrder Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, DrugOrder> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, DrugOrder> GetAllUnfinished(DateTime date)
        {
            return _repo.GetAll().Values
                .Where(drugOrder => drugOrder.RestockingDate.Date <= date && drugOrder.IsFinished is false)
                .ToDictionary(drugOrder => drugOrder.Id, drugOrder => drugOrder);
        }
    }
}
