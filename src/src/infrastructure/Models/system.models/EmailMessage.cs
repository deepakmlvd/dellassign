using System;
using System.Collections.Generic;
using System.Text;

namespace management.models
{
    public class EmailMessage
    {
        //TODO : Remove set where not necessary and create constructor
        public string Body { get; set; }
        
        public string From { get; set; }

        public string To { get; set; }

    }
}
