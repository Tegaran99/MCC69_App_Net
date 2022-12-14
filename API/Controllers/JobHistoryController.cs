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
    [Route("api/JobHistory")]
    [ApiController]
    public class JobHistoryController : Controller
    {

        MyContext myContext;
        public JobHistoryController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = 200, data = myContext.JobHistory.ToList() });
        }
        [HttpGet("{id}")]
        public IActionResult GetDetail([FromRoute] int id)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var region = myContext.JobHistory.FirstOrDefault(_jobhistory => _jobhistory.Id.Equals(id));
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
        public IActionResult Create(JobHistory jobhistory)
        {
            myContext.JobHistory.Add(jobhistory);
            int result = myContext.SaveChanges();
            if (result > 0)
                return CreatedAtAction(nameof(GetDetail), new { id = jobhistory.Id }, new { status = 200, message = "data inserted successfully", data = jobhistory });
            return BadRequest();


        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, JobHistory jobhistory)
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
            data.Id = jobhistory.Id;
            data.Job_Id = jobhistory.Job_Id;
            data.Department_Id = jobhistory.Job_Id;

            var result = myContext.SaveChanges();
            if (result > 0)
                return CreatedAtAction(nameof(GetDetail), new { id = data.Id }, new { status = 200, message = "data edited successfully", data = data });
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, JobHistory jobhistory)
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

            myContext.JobHistory.Remove(jobhistory);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { status = 200, message = "data deleted successfully" });
            return BadRequest();


        }


    }
}
