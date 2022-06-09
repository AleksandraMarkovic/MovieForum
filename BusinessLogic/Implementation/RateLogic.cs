using Application;
using Application.DTOs;
using Application.Repositories;
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
    public class RateLogic : IRateLogic
    {
        private readonly IRateRepository _repository;
        private readonly RatingValidation _validation;

        public RateLogic(IRateRepository repository, RatingValidation validation)
        {
            _repository = repository;
            _validation = validation;
        }

        public IOperationResult Add(Rating rating)
        {
            try
            {
                _validation.ValidateAndThrow(rating);
                return _repository.Add(rating);
            }
            catch (Exception ex)
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

        public IOperationResult Update(Rating rating)
        {
            try
            {
                _validation.ValidateAndThrow(rating);
                return _repository.Update(rating);
            }
            catch (Exception ex)
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
