using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CustomException;
using LeaveService.API.Business;
using management.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LeaveService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        ILeave _leave = null;
        public LeaveController(ILeave leave)
        {
            _leave = leave;
        }
        //TODO: employee can be removed, only added to support harcoding of employeeId=1;
        [HttpPost("apply")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<LeaveResponse> ApplyLeave([FromBody]Leave NewLeave)
        {
            LeaveResponse newResp = null;
            try
            {
                newResp=_leave.ApplyLeave(NewLeave);
            }
            catch (Exception lex)
            {
                return BadRequest(lex.ToString());
            }
            return Ok(newResp);
        }

        [HttpPost("approve")]
        public ActionResult<LeaveResponse> ApproveLeave([FromBody] Leave NewLeave)
        {
            return Ok(_leave.ApproveLeave(NewLeave));
        }


        [HttpPost("employee/list")]
        public ActionResult<List<Leave>> GetLeaveListForEmployee([FromHeader]String authentication)
        {
            var employee = JsonConvert.DeserializeObject<Employee>(authentication);
            return Ok(_leave.GetLeaveListForEmployee(employee));
        }

        [HttpPost("manager/list")]
        public async Task<ActionResult<List<Leave>>> GetLeaveListForEmployeeForManager([FromHeader]String authentication)
        {
            var manager = JsonConvert.DeserializeObject<Manager>(authentication);
            var leaves=await _leave.GetLeaveListForEmployeeForManager(manager);
            return Ok(leaves);
        }

    }
}