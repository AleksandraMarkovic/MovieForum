using Application;
using Application.Repositories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly MoviesContext _context;

        public TypeRepository(MoviesContext context)
        {
            _context = context;
        }

        public IOperationResult Add(Application.DTOs.Type type)
        {
            try
            {
                var newType = new TypeEntity
                {
                    MovieType = type.MovieType
                };
                _context.Types.Add(newType);
                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Delete(int id)
        {
            try
            {
                var type = _context.Types.FirstOrDefault(x => x.Id == id);

                if(type == null)
                {
                    return OperationResult.Error("Type not found.");
                }

                _context.Types.Remove(type);
                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult GetAll()
        {
            try
            {
                var query = _context.Types.AsQueryable();
                var types = query.Select(x => new Application.DTOs.Type
                {
                    Id = x.Id,
                    MovieType = x.MovieType
                });

                return new OperationResult()
                {
                    Result = true,
                    Data = types
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Update(Application.DTOs.Type type)
        {
            try
            {
                var typeUpdate = _context.Types.FirstOrDefault(x => x.Id == type.Id);

                if(typeUpdate == null)
                {
                    return OperationResult.Error("Type not found.");
                }

                typeUpdate.MovieType = type.MovieType;
                typeUpdate.UpdatedAt = DateTime.Now;
                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }
    }
}
