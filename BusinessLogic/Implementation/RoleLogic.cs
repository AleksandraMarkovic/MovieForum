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
    public class RoleLogic : IRoleLogic
    {
        private readonly IRoleRepository _repository;
        private readonly AddRoleValidation _addValidation;
        private readonly UpdateRoleValidation _updateValidation;

        public RoleLogic(IRoleRepository repository, AddRoleValidation addValidation, UpdateRoleValidation updateValidation)
        {
            _repository = repository;
            _addValidation = addValidation;
            _updateValidation = updateValidation;
        }

        public IOperationResult Add(Role role)
        {
            try
            {
                _addValidation.ValidateAndThrow(role);
                return _repository.Add(role);
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

        public IOperationResult GetAll()
        {
            return _repository.GetAll();
        }
        public IOperationResult Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IOperationResult Update(Role role)
        {
            try
            {
                _updateValidation.ValidateAndThrow(role);
                return _repository.Update(role);
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
