using System.Collections.Generic;
using Library.Model.Refferal;

namespace Library.Service.RefferalService.Interface;

public interface IHospitalRefferalService
{
    void Add(HospitalRefferal hospitalRefferal);
    HospitalRefferal Get(int id);
    Dictionary<int, HospitalRefferal> GetAll();
    Dictionary<int, HospitalRefferal> GetAll(int patientId);
    void Remove(int id);
    void Update(HospitalRefferal hospitalRefferal);
}