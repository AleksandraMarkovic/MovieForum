using Application;
using Application.DTOs;
using Application.Interfaces;
using Application.Repositories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly MoviesContext _context;
        private readonly IApplicationActor _actor;

        public RateRepository(MoviesContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public IOperationResult Add(Rating rating)
        {
            try
            {
                var newRating = new RatingEntity
                {
                    MovieId = rating.MovieId,
                    UserId = _actor.Id,
                    RatingValue = rating.RatingValue,
                    CreatedAt = DateTime.Now
                };

                _context.Ratings.Add(newRating);
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
                var rating = _context.Ratings.FirstOrDefault(x => x.Id == id);

                if(rating == null)
                {
                    return OperationResult.Error("Rating not found.");
                }

                _context.Ratings.Remove(rating);
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

        public IOperationResult Update(Rating rating)
        {
            try
            {
                var ratingUpdate = _context.Ratings.FirstOrDefault(x => x.Id == rating.Id);

                if(ratingUpdate == null)
                {
                    return OperationResult.Error("Rating not found.");
                }

                ratingUpdate.RatingValue = rating.RatingValue;
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
    }
}
