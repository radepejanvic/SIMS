using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private ICRUDRepository<LeaveRequest> _repo;

        public LeaveRequestRepository(ICRUDRepository<LeaveRequest> repo)
        {
            _repo = repo;
        }

        public void Add(LeaveRequest leaveRequest)
        {
            _repo.Add(leaveRequest);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public void Update(LeaveRequest leaveRequest)
        {
            _repo.Update(leaveRequest);
        }

        public LeaveRequest Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, LeaveRequest> GetAll()
        {
            return _repo.GetAll();
        }


    }
}
