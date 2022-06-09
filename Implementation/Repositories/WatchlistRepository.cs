using Application;
using Application.DTOs;
using Application.Interfaces;
using Application.Repositories;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly MoviesContext _context;
        private readonly IApplicationActor _actor;

        public WatchlistRepository(MoviesContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public IOperationResult Add(Watchlist watchlist)
        {
            try
            {
                var newWatchlist = new WatchlistEntity
                {
                    MovieId = watchlist.MovieId,
                    UserId = _actor.Id,
                    CreatedAt = DateTime.Now
                };

                _context.Watchlists.Add(newWatchlist);
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
                var watchlist = _context.Watchlists.FirstOrDefault(x => x.Id == id);

                if(watchlist == null)
                {
                    return OperationResult.Error("Watchlist not found.");
                }

                _context.Watchlists.Remove(watchlist);
                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Get()
        {
            try
            {
                var watchlist = _context.Watchlists.Select(x => new ShowWatchlist
                {
                    Id = x.Id,
                    MovieId = x.MovieId,
                    UserId = x.UserId,
                    Title = x.Movie.Title,
                    Description = x.Movie.Description,
                    Year = x.Movie.Year,
                    Poster = x.Movie.Poster
                }).Where(x => x.UserId == 1);

                return new OperationResult
                {
                    Result = true,
                    Data = watchlist
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }
    }
}
