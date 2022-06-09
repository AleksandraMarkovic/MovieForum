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
    public class RolesController : BaseController
    {
        private readonly IRoleLogic _role;

        public RolesController(IRoleLogic role)
        {
            _role = role;
        }


        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult Get()
        {
            return CreateResponse(_role.GetAll());
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RolesController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(Role role)
        {
            return CreateResponse(_role.Add(role));
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, Role role)
        {
            role.Id = id;
            return CreateResponse(_role.Update(role));
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_role.Delete(id));
        }
    }
}
