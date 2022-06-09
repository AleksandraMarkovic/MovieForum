using Application;
using Application.DTOs;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMovieLogic
    {
        IOperationResult GetMovie(int Id);
        IOperationResult GetAll();
        IQueryable<ShowMovie> GetMoviesBackground(DateTime date);
        IOperationResult Search(MovieSearch search);
        IOperationResult Add(Movie movie);
        IOperationResult Update(Movie movie);
        IOperationResult Delete(int id);
    }
}
