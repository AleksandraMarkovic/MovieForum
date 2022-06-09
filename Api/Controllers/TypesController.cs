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
    public class TypesController : BaseController
    {
        private readonly ITypeLogic _type;

        public TypesController(ITypeLogic type)
        {
            _type = type;
        }

        // GET: api/<TypesController>
        [HttpGet]
        public IActionResult Get()
        {
            return CreateResponse(_type.GetAll());
        }

        // GET api/<TypesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TypesController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(Application.DTOs.Type type)
        {
            return CreateResponse(_type.Add(type));
        }

        // PUT api/<TypesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, Application.DTOs.Type type)
        {
            type.Id = id;
            return CreateResponse(_type.Update(type));
        }

        // DELETE api/<TypesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_type.Delete(id));
        }
    }
}
