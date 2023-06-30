using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Service.LeaveRequestService.Interface
{
    public interface ILeaveRequestService
    {
        void Add(LeaveRequest leaveRequest);
        LeaveRequest Get(int id);
        Dictionary<int, LeaveRequest> GetAll();
        void Remove(int id);
        void Update(LeaveRequest leaveRequest);
    }
}
