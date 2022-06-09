using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public IFormFile Poster { get; set; }
        public IFormFile CoverImg { get; set; }
        public int Popularity { get; set; }
        public int CountryId { get; set; }
        public int TypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public IEnumerable<Finance> Finances { get; set; } = new List<Finance>();
    }

    public class MovieGenre
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
    }

    public class Finance
    {
        public decimal Budget { get; set; }
        public decimal? Earning { get; set; }
        public int MovieId { get; set; }
    }
}
