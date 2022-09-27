using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers

{
    [Route("api/Country")]
    [ApiController]
    [Authorize]
    
    public class CountryController : Controller
    {

        CountryRepository countryRepository;
        public CountryController(CountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = 200, data = countryRepository.Get() });
        }
        [HttpGet("{id}")]
        public IActionResult GetDetail([FromRoute] int id)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var country = countryRepository.GetDetail(id);
            if (country != null)
            {
                return Ok(new { status = 200, data = country });
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create(Countries country)
        {
            var result = countryRepository.Create(country);
            if (result > 0)
                return Ok(new { result = 200, message = "data successfully Create" });
            return BadRequest();


        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, Countries country)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var result = countryRepository.Edit(id, country);
            if (result > 0)
                return Ok(new { result = 200, message = "data successfully Edit" });
            else if (result == -1)
                return NotFound();
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, Countries country)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var result = countryRepository.Delete(id);
            if (result > 0)
                return Ok(new { status = 200, message = "data deleted successfully" });
            else if (result == -1)
                return NotFound();
            return BadRequest();

        }


    }
}
