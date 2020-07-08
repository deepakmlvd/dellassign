using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using management.models;

namespace EmailService.API.Business
{
    public class SMTPService : IEmail
    {
        public bool Send(EmailMessage message)
        {
            //TODO: Call SMTP service
            return true;
        }
    }
}
