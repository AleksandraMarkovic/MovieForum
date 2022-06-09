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
    public class CommentLogic : ICommentLogic
    {
        private readonly ICommentRepository _repository;
        private readonly CommentValidation _validaiton;

        public CommentLogic(ICommentRepository repository, CommentValidation validaiton)
        {
            _repository = repository;
            _validaiton = validaiton;
        }

        public CommentLogic() { }


        public IOperationResult Add(Comment comment)
        {
            try
            {
                //_validaiton.ValidateAndThrow(comment);
                return _repository.Add(comment);
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

        public IOperationResult Update(Comment comment)
        {
            try
            {
                _validaiton.ValidateAndThrow(comment);
                return _repository.Update(comment);
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
