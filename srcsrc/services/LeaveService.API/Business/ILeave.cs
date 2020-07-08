using management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveService.API.Business
{
    public interface ILeave
    {
        LeaveResponse ApplyLeave(Leave newLeave);

        LeaveResponse ApproveLeave(Leave newLeave);

        Task<List<Leave>> GetLeaveListForEmployeeForManager(Manager manager);

        List<Leave> GetLeaveListForEmployee(Employee employee);
    }
}
