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
    public class CommentsController : BaseController
    {
        private readonly ICommentLogic _comment;

        public CommentsController(ICommentLogic comment)
        {
            _comment = comment;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommentsController>
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Post(Comment comment)
        {
            return CreateResponse(_comment.Add(comment));
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult Put(int id, Comment comment)
        {
            comment.Id = id;
            return CreateResponse(_comment.Update(comment));
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_comment.Delete(id));
        }
    }
}
