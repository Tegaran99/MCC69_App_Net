using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers

{
    [Route("api/Job")]
    [ApiController]
    public class JobController : Controller
    {

        MyContext myContext;
        public JobController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = 200, data = myContext.Job.ToList() });
        }
        [HttpGet("{id}")]
        public IActionResult GetDetail([FromRoute] int id)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var region = myContext.Job.FirstOrDefault(_job => _job.Id.Equals(id));
            if (region != null)
            {
                return Ok(new { status = 200, data = region });
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create(Jobs job)
        {
            myContext.Job.Add(job);
            int result = myContext.SaveChanges();
            if (result > 0)
                return CreatedAtAction(nameof(GetDetail), new { id = job.Id }, new { status = 200, message = "data inserted successfully", data = job });
            return BadRequest();


        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, Jobs job)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var data = myContext.Job.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            data.JobTitle = job.JobTitle;
            

            var result = myContext.SaveChanges();
            if (result > 0)
                return CreatedAtAction(nameof(GetDetail), new { id = data.Id }, new { status = 200, message = "data edited successfully", data = data });
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, Jobs job)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var data = myContext.JobHistory.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            myContext.Job.Remove(job);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { status = 200, message = "data deleted successfully" });
            return BadRequest();


        }


    }
}
