using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.PersonService.Interface;

namespace Library.Service.PersonService
{
    public class NurseService : INurseService
    {
        private INurseRepository _crud;

        public NurseService(INurseRepository crud)
        {
            _crud = crud;
        }

        public void Add(Nurse nurse)
        {
            _crud.Add(nurse);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public void Update(Nurse nurse)
        {
            _crud.Update(nurse);
        }

        public Nurse Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, Nurse> GetAll()
        {
            return _crud.GetAll();
        }

        public Dictionary<int, Nurse> GetAll(List<int> ids)
        {
            return _crud.GetAll(ids);
        }
    }
}
