using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HeroesBackend.BusinessLayer;
using HeroesBackend.Entities;
using HeroesBackend.Queries;
using HeroesBackend.Common.Pagging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroesBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly HeroBusinessLayer businessLayer;

        public HeroesController()
        {
            this.businessLayer = new HeroBusinessLayer();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Hero>> All()
        {
            return Ok(businessLayer.GetAll());
        }

        [HttpGet]
        public ActionResult<PagedListResult<Hero>> Paginated([FromQuery]PaginatedQuery query)
        {
            return Ok(businessLayer.GetPaginated(query.PageNumber, query.PageSize, query.OrderBy, query.SortDirection));
        }

        [HttpGet("{id}")]
        public ActionResult<Hero> GetOne(int id)
        {
            return Ok(businessLayer.GetOne(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hero>> Search([FromQuery] SearchQuery query)
        {
            return Ok(this.businessLayer.SearchHeroByName(query.Term));
        }

        [HttpPost]
        public ActionResult Save([FromBody] Hero hero)
        {
            bool result = businessLayer.Save(hero);

            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}