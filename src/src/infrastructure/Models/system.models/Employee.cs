using System;

namespace management.models
{
    public class Employee
    {
        //TODO: Remove set where not required and create constructer
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public Designation Designation { get; set; }

        public Manager ReportingManager { get; set; }

        public bool isActive { get; set; }
    }
}
