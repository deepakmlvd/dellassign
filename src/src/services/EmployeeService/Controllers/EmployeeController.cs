using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.API.Business;
using management.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpPost("information/list")]
        public ActionResult<List<Employee>> GetEmployeeInformationById([FromBody]int[] employeeIds)
        {
            return _employee.GetEmployeeInformationById(employeeIds);
        }
    }
}