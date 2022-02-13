using CreditS.Repository.Models;
using CreditS.Repository.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService usersService;

        public UsersController(IUserService usersService)
        {
            this.usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate([FromBody] CreateUserModel userModel)
        {
            UserModel user = usersService.Authenticate(userModel.Username, userModel.Password);

            if (user == null)
            {
                return NotFound("Username or password are incorrect.");
            }

            return Ok(user);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = usersService.GetAllUsers();

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser([FromBody] CreateUserModel createUserModel)
        {
            UserModel user = usersService.CreateUser(createUserModel);

            return Ok(user);

        }
    }
}
