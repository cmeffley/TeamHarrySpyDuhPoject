using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamHarrySpyDuhPoject.DataAccess;
using TeamHarrySpyDuhPoject.Models;

namespace TeamHarrySpyDuhPoject.Controllers
{
    [Route("api/spies")]
    [ApiController]
    public class SpyController : ControllerBase
    {
        private SpyRepository _repo;

        public SpyController()
        {
            _repo = new SpyRepository();
        }

        [HttpGet]
        public IActionResult GetAllSpies()
        {
            return Ok(_repo.GetAll());
        }

    }
}
