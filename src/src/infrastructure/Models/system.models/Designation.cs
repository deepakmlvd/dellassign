using System;
using System.Collections.Generic;
using System.Text;

namespace management.models
{
    public class Designation
    {
        //TODO: Remove set where not required and create constructer
        public int DesignationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
