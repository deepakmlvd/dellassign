using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LeaveService.API.DataAccess;
using management.models;
using Newtonsoft.Json;

namespace LeaveService.API.Business
{
    public class LeaveHandler : ILeave
    {
        private ILeaveDA _leaveDA;
        public LeaveHandler(ILeaveDA leaveDA)
        {
            _leaveDA = leaveDA;
        }
        public LeaveResponse ApplyLeave(Leave newLeave)
        {
            int reqId = _leaveDA.ApplyLeave(newLeave);
            var leaveResponse = new LeaveResponse(reqId,LeaveStatus.Applied);
            return leaveResponse;
        }

        public LeaveResponse ApproveLeave(Leave newLeave)
        {
            return  _leaveDA.ApproveLeave(newLeave);
        }

        public List<Leave> GetLeaveListForEmployee(Employee employee)
        {
            return _leaveDA.GetLeaveListForEmployee(employee);
        }

        public async Task<List<Leave>> GetLeaveListForEmployeeForManager(Manager manager)
        {

            var leaves= _leaveDA.GetLeaveListForEmployeeForManager(manager);
            //TODO: get from system variable and not hard code
            var employeeListByIdApi = "http://localhost:7012/api/v1/employee/information/list";
            var employeeIds = (from leave in leaves
                               select leave.EmployeeId).ToArray();
            string content = JsonConvert.SerializeObject(employeeIds);
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(10);
            HttpContent inputContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(employeeListByIdApi, inputContent);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                var emplList = JsonConvert.DeserializeObject<List<Employee>>(res);
                foreach (var leave in leaves)
                {
                    leave.Employee = emplList.FirstOrDefault(e => e.EmployeeId == leave.EmployeeId);
                }
            }
            return leaves;
        }
    }
}
