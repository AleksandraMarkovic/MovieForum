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
    public class MailingListController : BaseController
    {
        private readonly IUserLogic _user;

        public MailingListController(IUserLogic user)
        {
            _user = user;
        }
        // GET: api/<MailingListController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MailingListController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MailingListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MailingListController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] User user)
        {
            user.Id = id;
            return CreateResponse(_user.MailingList(user));
        }

        // DELETE api/<MailingListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
