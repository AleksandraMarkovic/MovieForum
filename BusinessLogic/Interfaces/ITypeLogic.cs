using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITypeLogic
    {
        IOperationResult GetAll();
        IOperationResult Add(Application.DTOs.Type type);
        IOperationResult Update(Application.DTOs.Type type);
        IOperationResult Delete(int id);
    }
}
