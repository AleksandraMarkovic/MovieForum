using Application.DTOs;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IPersonRepository
    {
        IOperationResult Add(Person person);
        IOperationResult Search(CommonSearch search);
        IOperationResult Update(Person person);
        IOperationResult Delete(int id);
    }
}
