using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;
using Library.Repository.Interface;
using Library.Service.PersonService.Interface;

namespace Library.Service.PersonService
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _crud;

        public DoctorService(IDoctorRepository crud)
        {
            _crud = crud;
        }

        public void Add(Doctor doctor)
        {
            _crud.Add(doctor);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public Doctor Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, Doctor> GetAll()
        {
            return _crud.GetAll();
        }

        public Dictionary<int, Doctor> GetAll(Specialization specialization)
        {
            return _crud.GetAll(specialization);
        }

    }
}
