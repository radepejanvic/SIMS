using System.Collections.Generic;
using Library.Model.Refferal;
using Library.Repository.Interface;
using Library.Service.RefferalService.Interface;

namespace Library.Service.RefferalService;

public class HospitalRefferalService : IHospitalRefferalService
{
    private readonly IHospitalRefferalRepository _crud;

    public HospitalRefferalService(IHospitalRefferalRepository crud)
    {
        _crud = crud;
    }

    public void Add(HospitalRefferal hospitalRefferal)
    {
        _crud.Add(hospitalRefferal);
    }

    public void Update(HospitalRefferal hospitalRefferal)
    {
        _crud.Update(hospitalRefferal);
    }

    public void Remove(int id)
    {
        _crud.Remove(id);
    }

    public HospitalRefferal Get(int id)
    {
        return _crud.Get(id);
    }

    public Dictionary<int, HospitalRefferal> GetAll()
    {
        return _crud.GetAll();
    }

    public Dictionary<int, HospitalRefferal> GetAll(int patientId)
    {
        return _crud.GetAll(patientId);
    }
}