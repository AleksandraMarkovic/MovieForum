using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICountryRepository
    {
        IOperationResult GetAll();
        IOperationResult Add(Country country);
        IOperationResult Update(Country country);
        IOperationResult Delete(int id);
    }
}
