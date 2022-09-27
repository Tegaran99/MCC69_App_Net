using API.Base;
using API.Context;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers

{
    [Route("api/Region")]
    [ApiController]
    public class RegionController : BaseController<RegionRepository, Regions, int>
    {

        //RegionRepository regionRepository;
        public RegionController(RegionRepository regionRepository) : base(regionRepository)
        {
           
        }

        

    }
}
