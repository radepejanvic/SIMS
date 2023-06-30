using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.PhysicalAssetService.Interface;
using Library.ViewModel.Structure;

namespace Library.Repository
{
    public class DynamicalEquipmentRequestRepository : IDynamicalEquipmentRequestRepository
    {
        private ICRUDRepository<DynamicalEquipmentRequest> _repo;

        public DynamicalEquipmentRequestRepository(ICRUDRepository<DynamicalEquipmentRequest> repo)
        {
            _repo = repo;
        }

        public void Add(DynamicalEquipmentRequest dynamicalEquipmentRequest)
        {
            _repo.Add(dynamicalEquipmentRequest);
        }
        public DynamicalEquipmentRequest Get(int id)
        {
            return _repo.Get(id);
        }

        public List<DynamicalEquipmentRequest> GetUnfinishedDynamicalEquipmentRequests()
        {
            return _repo.GetAll().Values.Where(r => !r.IsRequestCompleted() && r.IsTimeLessThanNow()).ToList();
        }
        public void Update(DynamicalEquipmentRequest dynamicalEquipmentRequest)
        {
            _repo.Update(dynamicalEquipmentRequest);
        }

    }
}

