using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        public IActionResult CreateResponse(IOperationResult result)//
        {
            if (result == null)
                throw new Exception("Not an error in result");

            if (!result.Result)
            {

                if (result.Exception != null)
                {
                    //Logger.Log.Error(result.Message, result.Exception);
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
                else
                {
                    //return StatusCode(StatusCodes.Status400BadRequest, result.Message);
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);
                }
            }


            return Ok(result.Data);
        }

    }
}
