using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRoleEntity : Entity
    {
        public string Name { get; set; }
        public ICollection<UserEntity> Users { get; set; } = new HashSet<UserEntity>();
    }
}
