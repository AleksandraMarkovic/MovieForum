using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ShowMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Poster { get; set; }
        public string CoverImg { get; set; }
        public int Popularity { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<ShowMovieGenre> MovieGenres { get; set; } = new List<ShowMovieGenre>();
        public IEnumerable<ShowFinance> Finances { get; set; } = new List<ShowFinance>();
        public IEnumerable<ShowPeople> People { get; set; } = new List<ShowPeople>();
        public IEnumerable<ShowComment> Comments { get; set; } = new List<ShowComment>();
    }

    public class ShowMovieGenre
    {
        public string Genre { get; set; }
    }

    public class ShowFinance
    {
        public decimal Budget { get; set; }
        public decimal? Earning { get; set; }
    }

    public class ShowComment
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CommentText { get; set; }
    }
}
