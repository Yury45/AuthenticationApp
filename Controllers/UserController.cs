using AuthenticationApp.Models;
using AuthenticationApp.Models.Interfaces;
using AuthenticationApp.Services;
using AuthenticationApp.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IUserRepository _usersRepository;
        public UserController(ILogger logger, IMapper mapper, IUserRepository usersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _usersRepository = usersRepository;

            logger.WriteError("Error");
            logger.WriteEvent("Event");
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<UserViewModel> AuthenticateAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Запрос не корректен");

            var user = _usersRepository.GetByLogin(login);
            if (user == null)
                throw new ArgumentNullException("Запрос не корректен");
            if (user.Password != password)
                throw new AuthenticationException("Введенные данные не корректны");

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, 
                "AppCookies",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return _mapper.Map<UserViewModel>(user);
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

        [Authorize]
        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel()
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Firstname = "Somebody",
                Lastname = "Sometimes",
                Email = "SS@gmail.com",
                Login = "SomSom",
                Password = "Password1!"
            };

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }
    }
}
