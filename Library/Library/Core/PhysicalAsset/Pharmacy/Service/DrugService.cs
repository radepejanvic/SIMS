using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Refferal;
using Library.Repository.Interface;
using Library.Service.FarmaceuticalService.Interface;

namespace Library.Service.FarmaceuticalService
{
    public class DrugService : IDrugService
    {
        private IDrugRepository _crud;

        public DrugService(IDrugRepository crud)
        {
            _crud = crud;
        }

        public void Add(Drug drug)
        {
            _crud.Add(drug);
        }

        public void Update(Drug drug)
        {
            _crud.Update(drug);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public Drug Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, Drug> GetAll()
        {
            return _crud.GetAll();
        }

        public Dictionary<int, Drug> GetAllUnder(int quantity)
        {
            return _crud.GetAllUnder(quantity);
        }

        public bool IsAvaliable(int id)
        {
            return _crud.IsAvaliable(id);
        }
    }
}
