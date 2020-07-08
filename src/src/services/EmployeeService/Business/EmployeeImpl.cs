using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.API.DataAccess;
using management.models;

namespace EmployeeService.API.Business
{
    public class EmployeeImpl : IEmployee
    {

        IEmployeeDA _employeeDA;
        public EmployeeImpl(IEmployeeDA employee)
        {
            _employeeDA = employee;
        }
        public List<Employee> GetEmployeeInformationById(int[] employeeIds)
        {
            return _employeeDA.GetEmployeeInformationById(employeeIds);
        }
    }
}
