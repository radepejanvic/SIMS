using System.Collections.Generic;
using Library.Model.Refferal;

namespace Library.Repository.Interface
{
    public interface IDoctorRefferalRepository
    {
        void Add(DoctorRefferal doctorRefferal);
        DoctorRefferal Get(int id);
        Dictionary<int, DoctorRefferal> GetAll();
        Dictionary<int, DoctorRefferal> GetAll(int patientId);
        void Remove(int id);
        void Update(DoctorRefferal doctorRefferal);
    }
}