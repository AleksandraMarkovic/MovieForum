using Application;
using Application.DTOs;
using Application.Repositories;
using Application.Searches;
using BusinessLogic.Interfaces;
using BusinessLogic.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class PersonLogic : IPersonLogic
    {
        private readonly IPersonRepository _repository;
        private readonly PersonValidation _validation;

        public PersonLogic(IPersonRepository repository, PersonValidation validation)
        {
            _repository = repository;
            _validation = validation;
        }

        public IOperationResult Add(Person person)
        {
            try
            {
                _validation.ValidateAndThrow(person);

                Thread tImage = new Thread(() => Image(person));

                return _repository.Add(person);
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

        public void Image(Person person)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(person.Image.FileName);
            var newImage = guid + extension;
            var path = Path.Combine("wwwroot", "images", newImage);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                person.Image.CopyTo(fileStream);
            }
        }

        public IOperationResult Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IOperationResult Search(CommonSearch search)
        {
            return _repository.Search(search);
        }

        public IOperationResult Update(Person person)
        {
            try
            {
                _validation.ValidateAndThrow(person);

                Thread tImage = new Thread(() => Image(person));

                return _repository.Update(person);
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
