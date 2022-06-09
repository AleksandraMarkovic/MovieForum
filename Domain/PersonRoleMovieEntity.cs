using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PersonRoleMovieEntity : Entity
    {
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public int MovieId { get; set; }
        public PersonEntity Person { get; set; }
        public RoleEntity Role { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
