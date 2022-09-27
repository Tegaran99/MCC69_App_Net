using Client.Models;
using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace Client.Controller
{
    [Route("Account")]
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            LoginResult loginResult = new LoginResult();
            using (var client = new System.Net.Http.HttpClient())
            {
                using (var response = await client.PostAsJsonAsync("https://localhost:44390/api/Account/Login", login))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    loginResult = JsonConvert.DeserializeObject<LoginResult>(apiResponse);
                    HttpContext.Session.SetString("token", loginResult.token);
                    if (loginResult.result == "200")
                    {
                        return View("Success");
                    }
                    return View("Invalid Account");
                }
            }
        }

    }

}
