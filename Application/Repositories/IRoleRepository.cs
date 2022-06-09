using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRoleRepository 
    {
        IOperationResult Add(Role role);
        IOperationResult GetAll();
        IOperationResult Update(Role role);
        IOperationResult Delete(int id);
    }
}
