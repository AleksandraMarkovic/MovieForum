using Application;
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
    public class TypeLogic : ITypeLogic
    {
        private readonly ITypeRepository _repository;
        private readonly AddTypeValidation _addValidation;
        private readonly UpdateTypeValidation _updateValidation;

        public TypeLogic(ITypeRepository repository, AddTypeValidation addValidation, UpdateTypeValidation updateValidation)
        {
            _repository = repository;
            _addValidation = addValidation;
            _updateValidation = updateValidation;
        }

        public IOperationResult Add(Application.DTOs.Type type)
        {
            try
            {
                _addValidation.ValidateAndThrow(type);
                return _repository.Add(type);
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

        public IOperationResult Update(Application.DTOs.Type type)
        {
            try
            {
                _updateValidation.ValidateAndThrow(type);
                return _repository.Update(type);
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
