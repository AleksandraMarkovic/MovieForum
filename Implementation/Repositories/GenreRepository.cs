using Application;
using Application.DTOs;
using Application.Repositories;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MoviesContext _context;

        public GenreRepository(MoviesContext context)
        {
            _context = context;
        }

        public IOperationResult Add(Genre genre)
        {
            try
            {
                var newGenre = new GenreEntity
                {
                    Name = genre.Name
                };
                _context.Genres.Add(newGenre);
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
                GenreEntity genre = _context.Genres.FirstOrDefault(x => x.Id == id);

                if (genre == null)
                {
                    return OperationResult.Error("Genre not found");
                }

                _context.Genres.Remove(genre);
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

        public IOperationResult GetAll()
        {
            try
            {
                var query = _context.Genres.AsQueryable();
                var genres = query.Select(x => new Genre
                {
                    Id = x.Id,
                    Name = x.Name
                });
                return new OperationResult()
                {
                    Result = true,
                    Data = genres
                };
            }
            catch (Exception ex)
            {
                return new OperationResult(ex);
            }

        }

        public IOperationResult GetGenre(int Id)
        {
            try
            {
                var genre = _context.Genres.Select(x => new Genre
                {
                    Id = x.Id,
                    Name = x.Name
                }).Where(x => x.Id == Id);

                return new OperationResult()
                {
                    Result = true,
                    Data = genre
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Search(CommonSearch search)
        {
            try
            {
                var query = _context.Genres.AsQueryable();

                if (!string.IsNullOrEmpty(search.Keyword))
                {
                    search.Keyword = search.Keyword.ToLower();

                    query = query.Where(x => x.Name.ToLower().Contains(search.Keyword));
                }

                var genres = query.Select(x => new Genre
                {
                    Id = x.Id,
                    Name = x.Name
                });

                return new OperationResult()
                {
                    Result = true,
                    Data = genres
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Update(Genre genre)
        {
            try
            {
                GenreEntity genreUpdate = _context.Genres.FirstOrDefault(x => x.Id == genre.Id);

                if (genreUpdate == null)
                {
                    return OperationResult.Error("Genre not found");
                }

                genreUpdate.Name = genre.Name;
                genreUpdate.UpdatedAt = DateTime.Now;
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
