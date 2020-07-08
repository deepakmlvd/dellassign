using management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.API.Business
{
    public interface IEmployee
    {
        List<Employee> GetEmployeeInformationById(int[] employeeIds);
    }
}
