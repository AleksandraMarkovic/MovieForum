using Application.DTOs;
using Application.Searches;
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
    public class PeopleController : BaseController
    {
        private readonly IPersonLogic _person;

        public PeopleController(IPersonLogic person)
        {
            _person = person;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public IActionResult Get([FromQuery] CommonSearch search)
        {
            return CreateResponse(_person.Search(search));
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PeopleController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromForm] Person person)
        {
            return CreateResponse(_person.Add(person));
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromForm] Person person)
        {
            person.Id = id;
            return CreateResponse(_person.Update(person));
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_person.Delete(id));
        }
    }
}
