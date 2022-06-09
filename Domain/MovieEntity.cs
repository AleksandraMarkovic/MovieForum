using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MovieEntity : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Poster { get; set; }
        public string CoverImg { get; set; }
        public int Popularity { get; set; }
        public int CountryId { get; set; }
        public int TypeId { get; set; }
        public CountryEntity Country { get; set; }
        public Domain.TypeEntity Type { get; set; }
        public ICollection<MovieGenreEntity> MovieGenres { get; set; } = new HashSet<MovieGenreEntity>();
        public ICollection<FinanceEntity> Finances { get; set; } = new HashSet<FinanceEntity>();
        public ICollection<PersonRoleMovieEntity> PersonRoleMovies { get; set; } = new HashSet<PersonRoleMovieEntity>();
        public ICollection<RatingEntity> Ratings { get; set; } = new HashSet<RatingEntity>();
        public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>(); 
        public ICollection<WatchlistEntity> Watchlists { get; set; } = new HashSet<WatchlistEntity>();
    }
}
