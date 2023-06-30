using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.FarmaceuticalService.Interface;

namespace Library.Service.FarmaceuticalService
{
    public class PerscriptionService : IPerscriptionService
    {
        private IPrescriptionRepository _crud;

        public PerscriptionService(IPrescriptionRepository crud)
        {
            _crud = crud;
        }

        public void Add(Perscription drug)
        {
            _crud.Add(drug);
        }

        public void Update(Perscription drug)
        {
            _crud.Update(drug);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public Perscription Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, Perscription> GetAll()
        {
            return _crud.GetAll();
        }

        public Dictionary<int, Perscription> GetAll(int patientId)
        {
            return _crud.GetAll(patientId);
        }
    }
}
