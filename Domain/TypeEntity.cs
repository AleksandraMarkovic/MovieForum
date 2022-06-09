using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TypeEntity : Entity
    {
        public string MovieType { get; set; }
        public ICollection<MovieEntity> Movies { get; set; } = new HashSet<MovieEntity>();
    }
}
