using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blingOn.Api.Core
{
    public class UnregisteredUser : IApplicationActor
    {
        public int Id => 0;
        public string Username => "Unregistered user";
        public string Role => "Unregistered";
    }
}
