using Client.Models;
using Client.ViewModels;
using MCC69_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class CountryController : Microsoft.AspNetCore.Mvc.Controller
    {
        public async Task<IActionResult> Index(Login login)
        {
            Json<Countries> countryList = new Json<Countries>();
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("token");
                if (token == null)
                {
                    return View("Unauthorize");
                }
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync("https://localhost:44390/api/Country"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    countryList = JsonConvert.DeserializeObject<Json<Countries>>(apiResponse);
                }
            }
            return View(countryList.data);
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Regions region)
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Regions region)
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Regions region)
        {
            return View();
        }

    }
}
