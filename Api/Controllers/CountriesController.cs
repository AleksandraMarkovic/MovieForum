using Application.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        private readonly ICountryLogic _country;

        public CountriesController(ICountryLogic country)
        {
            _country = country;
        }

        // GET: api/<CountriesControlles>
        [HttpGet]
        public IActionResult Get()
        {
            return CreateResponse(_country.GetAll());
        }

        // GET api/<CountriesControlles>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountriesControlles>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(Country country)
        {
            return CreateResponse(_country.Add(country));
        }

        // PUT api/<CountriesControlles>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, Country country)
        {
            country.Id = id;
            return CreateResponse(_country.Update(country));
        }

        // DELETE api/<CountriesControlles>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_country.Delete(id));
        }
    }
}
