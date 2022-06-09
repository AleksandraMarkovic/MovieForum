using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PersonEntity : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string PlaceOfBirth { get; set; }
        public ICollection<PersonRoleMovieEntity> PersonRoleMovies { get; set; } = new HashSet<PersonRoleMovieEntity>();
    }
}
