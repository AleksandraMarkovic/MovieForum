using Application;
using Application.DTOs;
using Application.Repositories;
using BusinessLogic.Interfaces;
using BusinessLogic.Validation;
using DataAccess;
using Email.DTOs;
using Email.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _repository;
        private readonly AddUserValidation _addValidation;
        private readonly UpdateUserValidation _updateValidation;
        private readonly IEmailSender _sender;
        private readonly MoviesContext _context;

        public UserLogic(IUserRepository repository, AddUserValidation addValidation, UpdateUserValidation updateValidation, IEmailSender sender,
            MoviesContext context)
        {
            _repository = repository;
            _addValidation = addValidation;
            _updateValidation = updateValidation;
            _sender = sender;
            _context = context;
        }

        public IOperationResult Add(User user)
        {
            try
            {
                _addValidation.ValidateAndThrow(user);

                Thread tSendEmail = new Thread(() => SendEmail(user));
                tSendEmail.Start();

                Thread tImage = new Thread(() => Image(user));
                tImage.Start();

                return _repository.Add(user);
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

        private void Image(User user)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(user.Image.FileName);
            var newImage = guid + extension;
            var path = Path.Combine("wwwroot", "images", newImage);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                user.Image.CopyTo(fileStream);
            }
        }

        private void SendEmail(User user)
        {
            var users = _repository.Users();
            var lastId = users.FirstOrDefault();

            _sender.Send(new EmailRegister
            {
                Content = $"Confirm your registration by clicking on this link : <a href='http://localhost:4200/confirmRegistration/{lastId + 1}'>Click here</a>",
                SendTo = user.Email,
                Subject = "Email confirmation"
            });
        }

        public IOperationResult Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IQueryable<User> GetUsersBackground()
        {
            return _repository.GetUsersBackground();
        }

        public IOperationResult Update(User user)
        {
            try
            {
                _updateValidation.ValidateAndThrow(user);

                Thread tImage = new Thread(() => Image(user));
                tImage.Start();

                return _repository.Update(user);
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

        public IOperationResult ConfirmRegistration(User user)
        {
            try
            {
                return _repository.ConfirmRegistration(user);
            }
            catch (Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult MailingList(User user)
        {
            return _repository.MailingList(user);
        }

    }
}
