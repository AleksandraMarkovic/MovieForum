using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public IFormFile Image { get; set; }
        public string PlaceOfBirth { get; set; }
        public IEnumerable<PersonRoleMovie> PersonRoleMovies { get; set; } = new List<PersonRoleMovie>();

        public class PersonRoleMovie
        {
            public int RoleId { get; set; }
            public int MovieId { get; set; }
            public string Role { get; set; }
        }
    }
}
