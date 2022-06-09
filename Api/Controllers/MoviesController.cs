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
    public class MoviesController : BaseController
    {
        private readonly IMovieLogic _movie;

        public MoviesController(IMovieLogic movie)
        {
            _movie = movie;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public IActionResult Get([FromQuery] MovieSearch search)
        {
            //return CreateResponse(_movie.Search(search));
            return CreateResponse(_movie.GetAll());
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return CreateResponse(_movie.GetMovie(id));
        }

        // POST api/<MoviesController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromForm] Movie movie)
        {
            return CreateResponse(_movie.Add(movie));
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromForm] Movie movie)
        {
            movie.Id = id;
            return CreateResponse(_movie.Update(movie));
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_movie.Delete(id));
        }
    }
}
