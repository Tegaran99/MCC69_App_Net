using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/Role")]
    [ApiController]
    public class RoleController : BaseController<RoleRepository, Role, int>
    {
        //RoleRepository roleRepository;
        public RoleController(RoleRepository roleRepository) : base(roleRepository)
        {
            

        }

    }
}
