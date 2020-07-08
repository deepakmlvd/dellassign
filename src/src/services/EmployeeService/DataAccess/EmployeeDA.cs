using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Utils;
using management.models;
using Dapper;

namespace EmployeeService.API.DataAccess
{
    public class EmployeeDA : IEmployeeDA
    {
        public List<Employee> GetEmployeeInformationById(int[] employeeIds)
        {
            string sql = @"SELECT employee_id as EmployeeId, pName as Name from tbl_employee where employee_id in @employeeIds";
            using (var connection = DBProvider.CreateDbConnection(EmployeeHandlerSettings.ConnectionString))
            {
                List<Employee> employees = connection.Query<Employee>(sql, new { employeeIds = employeeIds }).ToList();
                return employees;
            }
        }
    }
}
