using Application;
using Application.DTOs;
using Application.Repositories;
using Application.Searches;
using BusinessLogic.Interfaces;
using BusinessLogic.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class GenreLogic : IGenreLogic
    {
        private readonly IGenreRepository _repository;
        private readonly AddGenreValidation _addValidation;
        private readonly UpdateGenreValidation _updateValidation;

        public GenreLogic(IGenreRepository repository, AddGenreValidation addValidation, UpdateGenreValidation updateValidation)
        {
            _repository = repository;
            _addValidation = addValidation;
            _updateValidation = updateValidation;
        }

        public IOperationResult Add(Genre genre)
        {
            try
            {
                _addValidation.ValidateAndThrow(genre);
                return _repository.Add(genre);
            }
            catch(ValidationException ex)
            {
                return new OperationResult
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }

        public IOperationResult Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IOperationResult GetAll()
        {
            return _repository.GetAll();
        }

        public IOperationResult Search(CommonSearch search)
        {
            return _repository.Search(search);
        }

        public IOperationResult GetGenre(int Id)
        {
            return _repository.GetGenre(Id);
        }

        public IOperationResult Update(Genre genre)
        {
            try
            {
                _updateValidation.ValidateAndThrow(genre);
                return _repository.Update(genre);
            }
            catch(Exception ex)
            {
                return new OperationResult
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }
    }
}
