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
    public class RatingsController : BaseController
    {
        private readonly IRateLogic _rating;

        public RatingsController(IRateLogic rating)
        {
            _rating = rating;
        }

        // GET: api/<RatingsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RatingsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RatingsController>
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Post(Rating rating)
        {
            return CreateResponse(_rating.Add(rating));
        }

        // PUT api/<RatingsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Put(int id, Rating rating)
        {
            rating.Id = id;
            return CreateResponse(_rating.Update(rating));
        }

        // DELETE api/<RatingsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_rating.Delete(id));
        }
    }
}
