using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class JwtUser : IApplicationActor
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }
    }
}
