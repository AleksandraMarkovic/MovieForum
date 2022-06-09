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
    public interface IGenreLogic
    {
        IOperationResult GetGenre(int Id);
        IOperationResult GetAll();
        IOperationResult Search(CommonSearch search);
        IOperationResult Add(Genre genre);
        IOperationResult Update(Genre genre);
        IOperationResult Delete(int id);
    }
}
