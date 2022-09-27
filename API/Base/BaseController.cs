using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository, Entity, Primary> : ControllerBase
        where Entity : class
        where Repository : GeneralRepository<Entity, Primary>
    {
        Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = repository.Get();
            return Ok(new { result = 200, data = data });
        }
        [HttpGet("{id}")]
        public IActionResult GetDetail(Primary id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var data = repository.Get(id);
            if (data != null)            
                return Ok(data);
            return NotFound();            
            
        }


        [HttpPost]
        public IActionResult Create(Entity entity)
        {
            if (ModelState.IsValid)
            {
                var result = repository.Create(entity);
                if (result > 0)
                    return Ok(new { result = 200, message = "Success" });
            }
            return BadRequest();

        }

        [HttpPut("{id}")]
        public IActionResult Edit(Primary id, Entity entity)
        {
            if (ModelState.IsValid)
            {
                var result = repository.Update(id, entity);
                if (result > 0)
                    return Ok();
            }
            
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Primary id)
        {
            var result = repository.Delete(id);
            if(result > 0)
                return Ok(new { result = 200, message = "success" });

            return BadRequest();

        }
        
    }
}
