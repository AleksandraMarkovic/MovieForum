using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ITypeRepository
    {
        IOperationResult GetAll();
        IOperationResult Add(DTOs.Type type);
        IOperationResult Update(DTOs.Type type);
        IOperationResult Delete(int id);
    }
}
