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
    public class WatchlistsController : BaseController
    {
        private readonly IWatchlistLogic _watchlist;

        public WatchlistsController(IWatchlistLogic watchlist)
        {
            _watchlist = watchlist;
        }

        // GET: api/<WatchlistsController>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Get()
        {
            return CreateResponse(_watchlist.Get());
        }

        // GET api/<WatchlistsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WatchlistsController>
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Post(Watchlist watchlist)
        {
            return CreateResponse(_watchlist.Add(watchlist));
        }

        // PUT api/<WatchlistsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WatchlistsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            return CreateResponse(_watchlist.Delete(id));
        }
    }
}
