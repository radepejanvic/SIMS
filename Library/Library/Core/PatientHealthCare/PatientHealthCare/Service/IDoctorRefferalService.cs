using System.Collections.Generic;
using Library.Model.Refferal;

namespace Library.Service.RefferalService.Interface
{
    public interface IDoctorRefferalService
    {
        void Add(DoctorRefferal doctorRefferal);
        void Update(DoctorRefferal doctorRefferal);
        void Remove(int id);
        DoctorRefferal Get(int id);
        Dictionary<int, DoctorRefferal> GetAll();
        Dictionary<int, DoctorRefferal> GetAll(int patientId);

    }
}