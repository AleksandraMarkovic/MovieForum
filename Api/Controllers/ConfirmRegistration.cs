using Application.DTOs;
using BusinessLogic.Interfaces;
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
    public class ConfirmRegistration : BaseController
    {
        private readonly IUserLogic _user;

        public ConfirmRegistration(IUserLogic user)
        {
            _user = user;
        }

        // GET: api/<ConfirmRegistration>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConfirmRegistration>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConfirmRegistration>
        [HttpPost]
        public void Post(string username)
        {
            //return CreateResponse(_user.ConfirmRegistration(username));
        }

        // PUT api/<ConfirmRegistration>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            user.Id = id;
            return CreateResponse(_user.ConfirmRegistration(user));
        }

        // DELETE api/<ConfirmRegistration>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
