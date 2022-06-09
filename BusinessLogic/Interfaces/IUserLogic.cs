using Application;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserLogic
    {
        IOperationResult Add(User user);
        IQueryable<User> GetUsersBackground();
        IOperationResult Update(User user);
        IOperationResult Delete(int id);
        IOperationResult ConfirmRegistration(User user);
        IOperationResult MailingList(User user);

    }
}
