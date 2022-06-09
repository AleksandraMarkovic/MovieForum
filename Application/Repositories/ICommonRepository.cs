using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICommonRepository<TRequest>
    {
        IOperationResult Add(TRequest request);
        IOperationResult Update(TRequest request);
        IOperationResult Delete(int id);
    }
}
