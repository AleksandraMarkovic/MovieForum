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
    public class UsersController : BaseController
    {
        private readonly IUserLogic _user;

        public UsersController(IUserLogic user)
        {
            _user = user;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromForm] User user)
        {
            return CreateResponse(_user.Add(user));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Put(int id, [FromForm] User user)
        {
            user.Id = id;
            return CreateResponse(_user.Update(user));
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_user.Delete(id));
        }
    }
}
