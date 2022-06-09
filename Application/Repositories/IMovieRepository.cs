using Application.DTOs;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IMovieRepository
    {
        IOperationResult GetMovie(int Id);
        IOperationResult Search(MovieSearch search);
        IOperationResult GetAll();
        IQueryable<ShowMovie> GetMoviesBackground(DateTime date);
        IOperationResult Add(Movie movie);
        IOperationResult Update(Movie movie);
        IOperationResult Delete(int id);
    }
}
