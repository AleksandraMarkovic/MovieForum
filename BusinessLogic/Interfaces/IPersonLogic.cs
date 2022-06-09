using Application;
using Application.DTOs;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPersonLogic
    {
        IOperationResult Add(Person person);
        IOperationResult Search(CommonSearch search);
        IOperationResult Update(Person person);
        IOperationResult Delete(int id);
    }
}
