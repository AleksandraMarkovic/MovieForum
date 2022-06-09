using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MovieGenreEntity : Entity
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public MovieEntity Movie { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
