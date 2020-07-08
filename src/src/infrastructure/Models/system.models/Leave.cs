using Helper.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace management.models
{
    public class Leave
    {
        //TODO: Remove set where not required and create constructer

        public DateTime Date { get; set; }
        public int RequestId { get; set; }
        
        public string Reason { get; set; }

        public int ManagerId { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public LeaveStatus Status { get; set; }

        //Example of client side validation to check XSS and other types of validation
        [CustomValidator(ErrorMessage = "Special Characters are not allowed in first position")]
        public string Comments { get; set; }
    }

    public class LeaveResponse
    {
        public LeaveResponse(int requestId, LeaveStatus status)
        {
            RequestId = requestId;
            Status = status;
        }
        public int RequestId { get;}

        public LeaveStatus Status { get; set; }
    }

    public enum LeaveStatus
    {
        None=0,
        Applied=1,
        Cancelled=2,
        Rejected=4,
        Approved=3
    }
}
