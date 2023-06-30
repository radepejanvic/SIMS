using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class DrugRepository : IDrugRepository
    {
        private ICRUDRepository<Drug> _repo;

        public DrugRepository(ICRUDRepository<Drug> repo)
        {
            _repo = repo;
        }

        public void Add(Drug drug)
        {
            _repo.Add(drug);
        }

        public void Update(Drug drug)
        {
            _repo.Update(drug);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Drug Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Drug> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, Drug> GetAllUnder(int quantity)
        {
            return _repo.GetAll().Values
                .Where(drug => drug.Quantity < quantity)
                .ToDictionary(drug => drug.Id, drug => drug);
        }
        public bool IsAvaliable(int id)
        {
            return _repo.Get(id).Quantity != 0;
        }
    }
}
