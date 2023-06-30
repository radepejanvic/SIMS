using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Refferal;
using Library.Repository.Interface;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.RefferalService.Interface;

namespace Library.Service.LeaveRequestService
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private ILeaveRequestRepository _crud;

        public LeaveRequestService(ILeaveRequestRepository crud)
        {
            _crud = crud;
        }

        public void Add(LeaveRequest leaveRequest)
        {
            _crud.Add(leaveRequest);
        }

        public LeaveRequest Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, LeaveRequest> GetAll()
        {
            return _crud.GetAll();
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }
        public void Update(LeaveRequest leaveRequest)
        {
            _crud.Update(leaveRequest);
        }
    }

}
