using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesBackend.BusinessLayer;
using HeroesBackend.Entities;
using HeroesBackend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroesBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HerosHomesController : ControllerBase
    {
        private HeroHomeBusinessLayer businessLayer;

        public HerosHomesController()
        {
            this.businessLayer = new HeroHomeBusinessLayer();
        }

        [HttpGet]
        public ActionResult<IEnumerable<HeroHome>> All()
        {
            return Ok(businessLayer.GetAll());
        }
    }
}
