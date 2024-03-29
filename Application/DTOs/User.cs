﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public IFormFile Image { get; set; }
        public int RoleId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastEmail { get; set; }
        public bool MailingList { get; set; }
    }
}
