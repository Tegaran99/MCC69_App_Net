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
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : Controller
    {

        EmployeeRepository employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = 200, data = employeeRepository.Get() });
        }
        [HttpGet("{id}")]
        public IActionResult GetDetail([FromRoute] int id)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var employee = employeeRepository.GetDetail(id);
            if (employee != null)
            {
                return Ok(new { status = 200, data = employee });
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create(Employees employee)
        {
            var result = employeeRepository.Create(employee);
            if (result > 0)
                return Ok(new { result = 200, message = "data successfully Create" });
            return BadRequest();


        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, Employees employee)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var result = employeeRepository.Edit(id, employee);
            if (result > 0)
                return Ok(new { result = 200, message = "data successfully Edit" });
            else if (result == -1)
                return NotFound();
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, Employees employee)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var result = employeeRepository.Delete(id);
            if (result > 0)
                return Ok(new { status = 200, message = "data deleted successfully" });
            else if (result == -1)
                return NotFound();
            return BadRequest();


        }


    }
}
