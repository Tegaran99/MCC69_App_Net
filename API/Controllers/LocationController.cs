using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers

{
    [Route("api/Location")]
    [ApiController]
    public class LocationController : Controller
    {

        LocationRepository locationRepository;
        public LocationController(LocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = 200, data = locationRepository.Get()});
        }
        [HttpGet("{id}")]
        public IActionResult GetDetail([FromRoute] int id)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var location = locationRepository.GetDetail(id);
            if (location != null)
            {
                return Ok(new { status = 200, data = location });
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create(Locations location)
        {
            var result = locationRepository.Create(location);
            if (result > 0)
                return Ok(new { result = 200, message = "data successfully Edit" });
            return BadRequest();


        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, Locations location)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var result = locationRepository.Edit(id, location);
            if (result > 0)
                return Ok(new { result = 200, message = "data successfully Edit" });
            else if (result == -1)
                return NotFound();
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, Locations location)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var result = locationRepository.Delete(id);
            if (result > 0)
                return Ok(new { status = 200, message = "data deleted successfully" });
            else if (result == -1)
                return NotFound();
            return BadRequest();


        }


    }
}
