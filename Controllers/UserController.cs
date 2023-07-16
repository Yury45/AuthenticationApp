using AuthenticationApp.Models;
using AuthenticationApp.Models.Interfaces;
using AuthenticationApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthenticationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        public UserController(ILogger logger)
        {
            _logger = logger;

            logger.WriteError("Error");
            logger.WriteEvent("Event");
        }

        [HttpGet]
        public User GetUser()
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Firstname = "Somebody",
                Lastname = "Sometimes",
                Email = "SS@gmail.com",
                Login = "SomSom",
                Password = "Password1!"
            };
        }
    }
}
