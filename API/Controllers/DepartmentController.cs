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
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : Controller
    {

        DepartmentRepository departmentRepository;
        public DepartmentController(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = 200, data = departmentRepository.Get() });
        }
        [HttpGet("{id}")]
        public IActionResult GetDetail([FromRoute] int id)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var country = departmentRepository.GetDetail(id);
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
        public IActionResult Create(Departments department)
        {
            var result = departmentRepository.Create(department);
            if (result > 0)
                return Ok(new { result = 200, message = "data successfully Create" });
            return BadRequest();


        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, Departments department)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var result = departmentRepository.Edit(id, department);
            if (result > 0)
                return Ok(new { result = 200, message = "data successfully Edit" });
            else if (result == -1)
                return NotFound();
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, Departments department)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var result = departmentRepository.Delete(id);
            if (result > 0)
                return Ok(new { status = 200, message = "data deleted successfully" });
            else if (result == -1)
                return NotFound();
            return BadRequest();


        }


    }
}
