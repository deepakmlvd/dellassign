using management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.API.Business
{
    interface IEmail
    {
        bool Send(EmailMessage message);
    }
}
