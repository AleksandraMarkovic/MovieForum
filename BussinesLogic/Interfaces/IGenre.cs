using Application;
using Application.DTOs;
using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Interfaces
{
    public interface IGenre
    {
        Genre GetGenre(int Id);
        IOperationResult GetAll();
        IOperationResult Add(Genre genre);
        Genre Update(Genre genre);
        Genre Delete(int id);
    }
}
