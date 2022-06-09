using Application;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRoleLogic
    {
        IOperationResult Add(Role role);
        IOperationResult GetAll();
        IOperationResult Update(Role role);
        IOperationResult Delete(int id);
    }
}
