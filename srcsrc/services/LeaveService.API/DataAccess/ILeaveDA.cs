using management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveService.API.DataAccess
{
    public interface ILeaveDA 
    {
        int ApplyLeave(Leave newLeave);
        LeaveResponse ApproveLeave(Leave newLeave);
        List<Leave> GetLeaveListForEmployeeForManager(Manager manager);

        List<Leave> GetLeaveListForEmployee(Employee employee);
    }
}
