using Email.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Interfaces
{
    public interface IEmailSender
    {
        void Send(EmailRegister email);
    }
}
