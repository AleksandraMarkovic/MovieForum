using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GenreEntity : Entity
    {
        public string Name { get; set; }
        public ICollection<MovieGenreEntity> GenreMovies { get; set; } = new HashSet<MovieGenreEntity>();
    }
}
