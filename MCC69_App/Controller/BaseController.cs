using Client.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class BaseController<TEntity, TRepository> : Microsoft.AspNetCore.Mvc.Controller
        where TEntity: class
        where TRepository: IGeneralRepository<TEntity>

    {
        private readonly TRepository repository;
        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = repository.GetAll();
            return Json(result);
        }
    }
}
