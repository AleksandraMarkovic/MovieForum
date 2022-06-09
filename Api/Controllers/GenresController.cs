using Application;
using Application.DTOs;
using Application.Repositories;
using Application.Searches;
using BusinessLogic.Interfaces;
using Domain;
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
    public class GenresController : BaseController
    {
        private readonly IGenreLogic _genre;

        public GenresController(IGenreLogic genre)
        {
            _genre = genre;
        }

        // GET: api/<GenresController>
        [HttpGet]
        public IActionResult Get([FromQuery] CommonSearch search)
        {
            //return CreateResponse(_genre.Search(search));
            return CreateResponse(_genre.GetAll());
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return CreateResponse(_genre.GetGenre(id));
        }

        // POST api/<GenresController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(Genre genre)
        {
            return CreateResponse(_genre.Add(genre));
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, Genre genre)
        {
            genre.Id = id;
            return CreateResponse(_genre.Update(genre));
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_genre.Delete(id));
        }
    }
}
