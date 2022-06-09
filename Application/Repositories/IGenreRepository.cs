using Application.DTOs;
using Application.Searches;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IGenreRepository
    {
        IOperationResult GetGenre(int Id);
        IOperationResult GetAll();
        IOperationResult Search(CommonSearch search);
        IOperationResult Add(Genre genre);
        IOperationResult Update(Genre genre);
        IOperationResult Delete(int id);
    }
}
