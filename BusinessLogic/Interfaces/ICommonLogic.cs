using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICommonLogic<TRequest>
    {
        IOperationResult Add(TRequest request);
        IOperationResult Update(TRequest request);
        IOperationResult Delete(int id);
    }
}
