using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Assignment_4___Server.Models;
using Managing_Adults.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private IUserService _inMemoryUserService;

        public AuthenticateController(IUserService inMemoryUserService)
        {
            _inMemoryUserService = inMemoryUserService;
        }
        
        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string userName, [FromQuery] string password)
        {
            try
            {
                Task<User> user = _inMemoryUserService.ValidateUser(userName, password);
                return Ok(user.Result);
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
                return StatusCode(404);
            }
        }
    }
}