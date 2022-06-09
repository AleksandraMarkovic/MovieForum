using Application;
using Application.DTOs;
using Application.Repositories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class UserRepository : CommonImageRepository, IUserRepository
    {
        private readonly MoviesContext _context;

        public UserRepository(MoviesContext context)
        {
            _context = context;
        }

        public IOperationResult Add(User user)
        {
            try
            {
                var role = _context.UserRoles.FirstOrDefault(x => x.Name == "User");

                var newImage = MakeImage(user.Image.FileName);

                var newUser = new UserEntity
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Birthday = user.Birthday,
                    Email = user.Email,
                    Username = user.Username,
                    Password = user.Password,
                    Image = newImage,
                    RoleId = role.Id,
                    IsActive = false
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Delete(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);

                if(user == null)
                {
                    return OperationResult.Error("User not found.");
                }

                _context.Users.Remove(user);
                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IQueryable<User> GetUsersBackground()
        {
            var users = _context.Users.Select(x => new User
            {
                Email = x.Email,
                LastLogin = x.LastLogin,
                LastEmail = x.LastEmail
            }).Where(x => x.MailingList == true);

            List<User> usersList = new List<User>();

            // Users that didn't login and didn't receive an email in the last 7 days
            foreach (User user in users)
            {
                if(DateTime.Now.Subtract((DateTime)user.LastLogin).TotalDays >= 7 && DateTime.Now.Subtract((DateTime)user.LastEmail).TotalDays >= 7)
                {
                    usersList.Add(user);
                }
            }

            return usersList.AsQueryable();
        }

        public IOperationResult Update(User user)
        {
            try
            {
                var userUpdate = _context.Users.FirstOrDefault(x => x.Id == user.Id);

                if(userUpdate == null)
                {
                    return OperationResult.Error("User not found.");
                }

                var newImage = MakeImage(user.Image.FileName);

                userUpdate.Email = user.Email;
                userUpdate.Username = user.Username;
                userUpdate.Password = user.Password;
                userUpdate.Image = newImage;
                userUpdate.UpdatedAt = DateTime.Now;

                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult ConfirmRegistration(User user)
        {
            try
            {
                var userUpdate = _context.Users.FirstOrDefault(x => x.Id == user.Id);

                if (userUpdate == null)
                {
                    return OperationResult.Error("User not found.");
                }

                userUpdate.IsActive = true;
                _context.SaveChanges();

                return new OperationResult
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                return new OperationResult(ex);
            }
        }
        
        public IOperationResult MailingList(User user)
        {
            try
            {
                // Logged in user
                var userMail = _context.Users.FirstOrDefault(x => x.Id == user.Id);

                if (userMail == null)
                {
                    return OperationResult.Error("User not found.");
                }

                userMail.MailingList = true;
                _context.SaveChanges();

                return new OperationResult
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public List<int> Users()
        {
            var users = _context.Users.OrderByDescending(x => x.Id).Select(x => x.Id).ToList();
            return users;
        }
        

    }
}
