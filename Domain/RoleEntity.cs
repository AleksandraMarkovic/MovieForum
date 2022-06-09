using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RoleEntity : Entity
    {
        public string Name { get; set; }
        public ICollection<PersonRoleMovieEntity> PersonRoleMovies { get; set; } = new HashSet<PersonRoleMovieEntity>();
    }
}
