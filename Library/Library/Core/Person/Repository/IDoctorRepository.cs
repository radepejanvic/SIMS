using System.Collections.Generic;
using Library.Model;
using Library.Model.Enum;

namespace Library.Repository.Interface
{
    public interface IDoctorRepository
    {
        void Add(Doctor doctor);
        Doctor Get(int id);
        Dictionary<int, Doctor> GetAll();
        Dictionary<int, Doctor> GetAll(Specialization specialization);
        void Remove(int id);
    }
}