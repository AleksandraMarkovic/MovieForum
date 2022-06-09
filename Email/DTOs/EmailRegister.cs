using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.DTOs
{
    public class EmailRegister
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
