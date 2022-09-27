using API.Models;
using API.Base;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    
    public class UserController : BaseController<UserRepository,User,int>
    {
        private IConfiguration _config;

        UserRepository userRepository;
        public UserController(UserRepository userRepository, IConfiguration config) :base(userRepository)
        {
            _config = config;
            this.userRepository = userRepository;
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


    }
}
