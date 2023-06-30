using System.Collections.Generic;
using System.Linq;
using Library.Model.Refferal;
using Library.Repository.Interface;

namespace Library.Repository;

public class HospitalRefferalRepository : IHospitalRefferalRepository
{
    private readonly ICRUDRepository<HospitalRefferal> _repo;

    public HospitalRefferalRepository(ICRUDRepository<HospitalRefferal> repo)
    {
        _repo = repo;
    }

    public void Add(HospitalRefferal hospitalRefferal)
    {
        _repo.Add(hospitalRefferal);
    }

    public void Update(HospitalRefferal hospitalRefferal)
    {
        _repo.Update(hospitalRefferal);
    }

    public void Remove(int id)
    {
        _repo.Remove(id);
    }

    public HospitalRefferal Get(int id)
    {
        return _repo.Get(id);
    }

    public Dictionary<int, HospitalRefferal> GetAll()
    {
        return _repo.GetAll();
    }

    public Dictionary<int, HospitalRefferal> GetAll(int patientId)
    {
        return _repo.GetAll().Values
            .Where(hospitalRefferal => hospitalRefferal.PatientId == patientId && hospitalRefferal.IsValid is true)
            .ToDictionary(hospitalRefferal => hospitalRefferal.Id, hospitalRefferal => hospitalRefferal);
    }
}