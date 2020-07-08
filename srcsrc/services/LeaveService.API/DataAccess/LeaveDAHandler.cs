using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using management.models;
using Dapper;
using Helper.Utils;

namespace LeaveService.API.DataAccess
{
    public class LeaveDAHandler : ILeaveDA
    {
        public int ApplyLeave(Leave newLeave)
        {
            string sql = (@"insert into tbl_leave_requests(reason,manager_id,employee_id,appliedDate,status_id)" +
                                       "VALUES(@Reason,@ManagerId,@EmployeeId,@Date,@StatusId)" +
                                       " SELECT CAST(SCOPE_IDENTITY() as int)");
            using (var connection = DBProvider.CreateDbConnection(LeaveHandlerSettings.ConnectionString))
            {
                var result = connection.ExecuteScalar(sql, new { Reason = newLeave.Reason,
                    ManagerId = newLeave.ManagerId,
                    EmployeeId = newLeave.EmployeeId,
                    @Date = newLeave.Date,
                    StatusId = LeaveStatus.Applied
                });

                return (int)result;
            }
        }

        public LeaveResponse ApproveLeave(Leave newLeave)
        {
            //TODO : Fetch from ENUM
            string sql = @"update tbl_leave_requests set status_id=3, comments=@Comments where request_Id=@RequestId;";
            using (var connection = DBProvider.CreateDbConnection(LeaveHandlerSettings.ConnectionString))
            {
                var result = connection.ExecuteScalar(sql,new { RequestId = newLeave.RequestId, Comments=newLeave.Comments });
                return new LeaveResponse(newLeave.RequestId,LeaveStatus.Approved);
            }
        }


        public List<Leave> GetLeaveListForEmployeeForManager(Manager manager)
        {
            string sql = @"SELECT comments, appliedDate as Date, request_id as RequestId,manager_id as ManagerId,employee_id as EmployeeId,status_id as Status FROM tbl_leave_requests where manager_Id=@ManagerId";
            using (var connection = DBProvider.CreateDbConnection(LeaveHandlerSettings.ConnectionString))
            {
               List<Leave> leaves = connection.Query<Leave>(sql, new { ManagerId = manager.EmployeeId }).ToList();
               return leaves;
            }
        }

        public List<Leave> GetLeaveListForEmployee(Employee employee)
        {
            string sql = @"SELECT comments, appliedDate as Date, request_id as RequestId,manager_id as ManagerId,employee_id as EmployeeId,status_id as Status FROM tbl_leave_requests where employee_id=@EmployeeId";
            using (var connection = DBProvider.CreateDbConnection(LeaveHandlerSettings.ConnectionString))
            {
                List<Leave> leaves = connection.Query<Leave>(sql, new { EmployeeId = employee.EmployeeId }).ToList();
                return leaves;
            }
        }

    }
}
