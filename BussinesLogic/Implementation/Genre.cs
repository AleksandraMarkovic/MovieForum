using Application;
using Application.DTOs;
using Application.Repositories;
using BussinesLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Implementation
{
    public class Genre : IGenre
    {
        private readonly IGenreRepository _repository;

        public Genre(IGenreRepository repository)
        {
            _repository = repository;
        }

        public IOperationResult Add(Application.DTOs.Genre genre)
        {
            throw new NotImplementedException();
        }

        public Application.DTOs.Genre Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IOperationResult GetAll()
        {
            return _repository.GetAll();
        }

        public Application.DTOs.Genre GetGenre(int Id)
        {
            throw new NotImplementedException();
        }

        public Application.DTOs.Genre Update(Application.DTOs.Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
