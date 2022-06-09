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
    public class CountryLogic : ICountryLogic
    {
        private readonly ICountryRepository _repository;
        private readonly AddCountryValidation _addValidation;
        private readonly UpdateCountryValidation _updateValidation;

        public CountryLogic(ICountryRepository repository, AddCountryValidation addValidation, UpdateCountryValidation updateValidation)
        {
            _repository = repository;
            _addValidation = addValidation;
            _updateValidation = updateValidation;
        }

        public IOperationResult Add(Country country)
        {
            try
            {
                _addValidation.ValidateAndThrow(country);
                return _repository.Add(country);
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

        public IOperationResult GetAll()
        {
            return _repository.GetAll();
        }

        public IOperationResult Update(Country country)
        {
            try
            {
                _updateValidation.ValidateAndThrow(country);
                return _repository.Update(country);
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
