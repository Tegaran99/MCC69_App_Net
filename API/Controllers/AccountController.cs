using API.Base;
using API.Context;
using API.Models;
using API.Repositories.Data;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using API.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : BaseController<UserRepository, User, int>
    {
        private IConfiguration _config;

        UserRepository userRepository;

        public AccountController(UserRepository userRepository, IConfiguration config) : base(userRepository)
        {
            _config = config;
            this.userRepository = userRepository;
        }
        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
                return BadRequest();
            
            var result = userRepository.Login(login.Username, login.Password);
            var userRole = userRepository.GetRoleById(result.Id);
            if (result == null)
                return NotFound();
            var jwt = new JwtServices(_config);
            var token = jwt.GenerateSecurityToken(result.Id, result.Employee.Email,
                result.Employee.FirstName + " " + result.Employee.LastName, userRole.Role.Name);
            return Ok(new { result = 200, message = "successfully Login" ,token = token});
            

        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] Register register)
        {
            if(!string.IsNullOrWhiteSpace(register.Username) && !string.IsNullOrWhiteSpace(register.Password))
            {
                if (ModelState.IsValid)
                {
                    var result = userRepository.Create(register);
                    if (result > 0)
                        return Ok(new { result = 200, message = "successfully Register" });
                    else if (result == -2)
                        return BadRequest(new { result = 400, message = "Username sudah digunakan" });

                }
            }
            return BadRequest();

        }
        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var result = userRepository.ChangePassword(user);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Updated" });
                else if (result == -1)
                    return NotFound();
                /*else if (result == -2)
                    return BadRequest(new { result = 400, message = "UserName sudah digunakan" });*/
            }
            return BadRequest();
        }
        [HttpPut("ForgotPassword")]
        public IActionResult ForgotPassword(User user)
        {
            if (ModelState.IsValid)
            {
                var result = userRepository.ForgotPassword(user);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Updated pasword" });
                else if (result == -1)
                    return NotFound();
            }
            return BadRequest();
        }
        
        //mycontext
        //id, email, fullname, role
    }
}
