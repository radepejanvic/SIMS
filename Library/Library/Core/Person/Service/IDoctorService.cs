using System.Collections.Generic;
using Library.Model;
using Library.Model.Enum;

namespace Library.Service.PersonService.Interface
{
    public interface IDoctorService
    {
        void Add(Doctor doctor);
        Doctor Get(int id);
        Dictionary<int, Doctor> GetAll();
        Dictionary<int, Doctor> GetAll(Specialization specialization);
        void Remove(int id);
    }
}