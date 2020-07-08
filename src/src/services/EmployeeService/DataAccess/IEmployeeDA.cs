using management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.API.DataAccess
{
    public interface IEmployeeDA
    {
        List<Employee> GetEmployeeInformationById(int[] employeeIds);
    }
}
