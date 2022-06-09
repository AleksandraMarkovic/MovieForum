using Application;
using Application.DTOs;
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
    public class RoleRepository : IRoleRepository
    {
        private readonly MoviesContext _context;

        public RoleRepository(MoviesContext context)
        {
            _context = context;
        }

        public IOperationResult Add(Role role)
        {
            try
            {
                var newRole = new RoleEntity
                {
                    Name = role.Name
                };

                _context.Roles.Add(newRole);
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
                var query = _context.Roles.AsQueryable();
                var roles = query.Select(x => new Role
                {
                    Id = x.Id,
                    Name = x.Name
                });
                return new OperationResult()
                {
                    Result = true,
                    Data = roles
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
                var role = _context.Roles.FirstOrDefault(x => x.Id == id);

                if(role == null)
                {
                    return OperationResult.Error("Role not found.");
                }

                _context.Roles.Remove(role);
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

        public IOperationResult Update(Role role)
        {
            try
            {
                var roleUpdate = _context.Roles.FirstOrDefault(x => x.Id == role.Id);

                if(roleUpdate == null)
                {
                    return OperationResult.Error("Role not found");
                }

                roleUpdate.Name = role.Name;
                roleUpdate.UpdatedAt = DateTime.Now;
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
