using Client.Models;
using MCC69_App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class RegionController : Microsoft.AspNetCore.Mvc.Controller
    {
        public async Task<IActionResult> Index()
        {
            Json<Regions> regionList = new Json<Regions>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44390/api/Region"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    regionList = JsonConvert.DeserializeObject<Json<Regions>>(apiResponse);
                }
            }
            return View(regionList.data);

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
