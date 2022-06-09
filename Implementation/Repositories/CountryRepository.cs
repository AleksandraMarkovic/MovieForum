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
    public class CountryRepository : ICountryRepository
    {
        private readonly MoviesContext _context;

        public CountryRepository(MoviesContext context)
        {
            _context = context;
        }

        public IOperationResult Add(Country country)
        {
            try
            {
                var newCountry = new CountryEntity
                {
                    CountryName = country.CountryName
                };
                _context.Countries.Add(newCountry);
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
            var country = _context.Countries.FirstOrDefault(x => x.Id == id);

            if(country == null)
            {
                return OperationResult.Error("Country not found");
            }

            _context.Countries.Remove(country);
            _context.SaveChanges();

            return new OperationResult()
            {
                Result = true
            };
        }

        public IOperationResult GetAll()
        {
            try
            {
                var query = _context.Countries.AsQueryable();
                var countries = query.Select(x => new Country
                {
                    Id = x.Id,
                    CountryName = x.CountryName
                });

                return new OperationResult()
                {
                    Result = true,
                    Data = countries
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Update(Country country)
        {
            try
            {
                var countryUpdate = _context.Countries.FirstOrDefault(x => x.Id == country.Id);

                if(countryUpdate == null)
                {
                    return OperationResult.Error("Country not found");                
                }

                countryUpdate.CountryName = country.CountryName;
                countryUpdate.UpdatedAt = DateTime.Now;
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
