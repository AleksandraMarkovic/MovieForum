using Application;
using Application.DTOs;
using Application.Repositories;
using Application.Searches;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class MovieRepository : CommonImageRepository, IMovieRepository
    {
        private readonly MoviesContext _context;

        public MovieRepository(MoviesContext context)
        {
            _context = context;
        }

        public IOperationResult Add(Movie movie)
        {
            try
            {
                var newImage = MakeImage(movie.Poster.FileName);
                var newImageCover = MakeImage(movie.CoverImg.FileName);

                var newMovie = new MovieEntity
                {
                    Title = movie.Title,
                    Description = movie.Description,
                    Year = movie.Year,
                    Duration = movie.Duration,
                    Poster = newImage,
                    CoverImg = newImageCover,
                    Popularity = movie.Popularity,
                    CountryId = movie.CountryId,
                    TypeId = movie.TypeId,
                    MovieGenres = movie.MovieGenres.Select(x =>
                    {
                        return new MovieGenreEntity
                        {
                            GenreId = x.GenreId,
                            CreatedAt = DateTime.Now
                        };
                    }).ToList(),
                    Finances = movie.Finances.Select(x =>
                    {
                        return new FinanceEntity
                        {
                            Budget = x.Budget,
                            Earning = x.Earning
                        };
                    }).ToList()
                };

                _context.Movies.Add(newMovie);
                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Delete(int id)
        {
            try
            {
                var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

                if(movie == null)
                {
                    return OperationResult.Error("Movie not found.");
                }

                _context.Movies.Remove(movie);
                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult GetMovie(int Id)
        {
            try
            {
                var movie = _context.Movies.Select(x => new ShowMovie
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Duration = x.Duration,
                    Year = x.Year,
                    Poster = x.Poster,
                    CoverImg = x.CoverImg,
                    Popularity = x.Popularity,
                    Country = x.Country.CountryName,
                    CountryId = x.CountryId,
                    Type = x.Type.MovieType,
                    TypeId = x.TypeId,
                    Rating = x.Ratings.Count() > 0 ? Math.Round(x.Ratings.Average(x => x.RatingValue), 2) : 0,
                    Comments = x.Comments.Select(x => new ShowComment
                    {
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        CommentText = x.CommentText
                    }),
                    Finances = x.Finances.Select(x => new ShowFinance
                    {
                        Budget = x.Budget,
                        Earning = x.Earning
                    }),
                    MovieGenres = x.MovieGenres.Select(x => new ShowMovieGenre
                    {
                        Genre = x.Genre.Name
                    }),
                    People = x.PersonRoleMovies.Select(x => new ShowPeople
                    {
                        Id = x.Id,
                        FirstName = x.Person.FirstName,
                        LastName = x.Person.LastName,
                        RoleId = x.RoleId
                    })
                }).Where(x => x.Id == Id);

                var movie1 = movie;

                return new OperationResult()
                {
                    Result = true,
                    Data = movie
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult GetAll()
        {
            try
            {
                var query = _context.Movies.AsQueryable();
                var movies = query.Select(x => new ShowMovie
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Duration = x.Duration,
                    Year = x.Year,
                    Poster = x.Poster,
                    CoverImg = x.CoverImg,
                    Popularity = x.Popularity,
                    Country = x.Country.CountryName,
                    Type = x.Type.MovieType,
                    Rating = x.Ratings.Count() > 0 ? Math.Round(x.Ratings.Average(x => x.RatingValue), 2) : 0
                });
                return new OperationResult()
                {
                    Result = true,
                    Data = movies
                };
            }
            catch (Exception ex)
            {
                return new OperationResult(ex);
            }
        }


        public IQueryable<ShowMovie> GetMoviesBackground(DateTime date)
        {
            var movies = _context.Movies.Select(x => new ShowMovie
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Year = x.Year,
                Poster = x.Poster,
                CreatedAt = x.CreatedAt
            }).Where(x => x.CreatedAt >= date);

            return movies;
        }

        public IOperationResult Search(MovieSearch search)
        {
            try
            {
                var query = _context.Movies.Include(x => x.Type).Include(x => x.MovieGenres).ThenInclude(x => x.Genre)
                    .Include(x => x.PersonRoleMovies).ThenInclude(x => x.Person).AsQueryable();

                if (!string.IsNullOrEmpty(search.Keyword))
                {
                    search.Keyword = search.Keyword.ToLower();

                    query = query.Where(x => x.Title.ToLower().Contains(search.Keyword) || x.Description.ToLower().Contains(search.Keyword)
                    || x.MovieGenres.Any(y => y.Genre.Name.ToLower().Contains(search.Keyword)) ||
                    x.Type.MovieType.ToLower().Contains(search.Keyword) ||
                    x.PersonRoleMovies.Any(y => y.Person.FirstName.ToLower().Contains(search.Keyword) ||
                    y.Person.LastName.ToLower().Contains(search.Keyword)));
                }

                if (search.Year.HasValue)
                {
                    query = query.Where(x => x.Year == search.Year);
                }

                if (search.MinDuration.HasValue)
                {
                    query = query.Where(x => x.Duration >= search.MinDuration);
                }

                if (search.MaxDuration.HasValue)
                {
                    query = query.Where(x => x.Duration <= search.MaxDuration);
                }

                var movies = query.Select(x => new ShowMovie
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Duration = x.Duration,
                    Year = x.Year,
                    Poster = x.Poster,
                    CoverImg = x.CoverImg,
                    Popularity = x.Popularity,
                    Country = x.Country.CountryName,
                    Type = x.Type.MovieType,
                    Finances = x.Finances.Select(x => new ShowFinance
                    {
                        Budget = x.Budget,
                        Earning = x.Earning
                    }),
                    MovieGenres = x.MovieGenres.Select(x => new ShowMovieGenre
                    {
                        Genre = x.Genre.Name
                    })
                });

                return new OperationResult()
                {
                    Result = true,
                    Data = movies
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Update(Movie movie)
        {
            try
            {
                var movieUpdate = _context.Movies.FirstOrDefault(x => x.Id == movie.Id);

                if(movieUpdate == null)
                {
                    return OperationResult.Error("Movie not found.");
                }

                var genres = _context.MovieGenres.Where(x => x.MovieId == movie.Id).ToList();

                foreach(var g in genres)
                {
                    _context.MovieGenres.Remove(g);
                    _context.SaveChanges();
                }

                var finances = _context.Finances.Where(x => x.MovieId == movie.Id).ToList();

                foreach (var f in finances)
                {
                    _context.Finances.Remove(f);
                    _context.SaveChanges();
                }

                var newImage = MakeImage(movie.Poster.FileName);
                var newImageCover = MakeImage(movie.CoverImg.FileName);

                movieUpdate.Title = movie.Title;
                movieUpdate.Description = movie.Description;
                movieUpdate.Duration = movie.Duration;
                movieUpdate.Year = movie.Year;
                movieUpdate.Popularity = movie.Popularity;
                movieUpdate.Poster = newImage;
                movieUpdate.CoverImg = newImageCover;
                movieUpdate.TypeId = movie.TypeId;
                movieUpdate.CountryId = movie.CountryId;
                movieUpdate.MovieGenres = movie.MovieGenres.Select(x =>
                {
                    return new MovieGenreEntity
                    {
                        GenreId = x.GenreId
                    };
                }).ToList();
                movieUpdate.Finances = movie.Finances.Select(x =>
                {
                    return new FinanceEntity
                    {
                        Budget = x.Budget,
                        Earning = x.Earning
                    };
                }).ToList();
                movieUpdate.UpdatedAt = DateTime.Now;

                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }
    }
}
