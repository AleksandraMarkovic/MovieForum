using Application;
using Application.DTOs;
using Application.Repositories;
using Application.Searches;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class PersonRepository : CommonImageRepository, IPersonRepository
    {
        private readonly MoviesContext _context;

        public PersonRepository(MoviesContext context)
        {
            _context = context;
        }

        public IOperationResult Add(Person person)
        {
            try
            {
                var newImage = MakeImage(person.Image.FileName);

                var newPerson = new PersonEntity
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Bio = person.Bio,
                    PlaceOfBirth = person.PlaceOfBirth,
                    Image = newImage,
                    PersonRoleMovies = person.PersonRoleMovies.Select(x =>
                    {
                        return new PersonRoleMovieEntity
                        {
                            MovieId = x.MovieId,
                            RoleId = x.RoleId,
                            CreatedAt = DateTime.Now
                        };
                    }).ToList()
                };

                _context.People.Add(newPerson);
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
                var person = _context.People.FirstOrDefault(x => x.Id == id);

                if(person == null)
                {
                    return OperationResult.Error("Person not found.");
                }

                _context.People.Remove(person);
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

        public IOperationResult Search(CommonSearch search)
        {
            try
            {
                var query = _context.People.Include(x => x.PersonRoleMovies).ThenInclude(x => x.Role).AsQueryable();

                if (!string.IsNullOrEmpty(search.Keyword))
                {
                    search.Keyword = search.Keyword.ToLower();

                    query = query.Where(x => x.FirstName.ToLower().Contains(search.Keyword)
                    || x.LastName.ToLower().Contains(search.Keyword) 
                    || x.PersonRoleMovies.Any(y => y.Role.Name.ToLower().Contains(search.Keyword)));
                }

                var people = query.Select(x => new Person
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Bio = x.Bio,
                    PlaceOfBirth = x.PlaceOfBirth,
                    PersonRoleMovies = x.PersonRoleMovies.Select(x => new Person.PersonRoleMovie
                    {
                        MovieId = x.MovieId,
                        RoleId = x.RoleId,
                        Role = x.Role.Name
                    })
                });

                return new OperationResult()
                {
                    Result = true,
                    Data = people
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Update(Person person)
        {
            try
            {
                var personUpdate = _context.People.FirstOrDefault(x => x.Id == person.Id);

                if(personUpdate == null)
                {
                    return OperationResult.Error("Person not found.");
                }

                var rolesMovies = _context.PersonRoleMovies.Where(x => x.PersonId == person.Id).ToList();

                foreach (var rm in rolesMovies)
                {
                    _context.PersonRoleMovies.Remove(rm);
                    _context.SaveChanges();
                }

                var newImage = MakeImage(person.Image.FileName);

                personUpdate.FirstName = person.FirstName;
                personUpdate.LastName = person.LastName;
                personUpdate.Bio = person.Bio;
                personUpdate.Image = newImage;
                personUpdate.PlaceOfBirth = person.PlaceOfBirth;
                personUpdate.PersonRoleMovies = person.PersonRoleMovies.Select(x =>
                {
                    return new PersonRoleMovieEntity
                    {
                        MovieId = x.MovieId,
                        RoleId = x.RoleId
                    };
                }).ToList();
                personUpdate.UpdatedAt = DateTime.Now;

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
