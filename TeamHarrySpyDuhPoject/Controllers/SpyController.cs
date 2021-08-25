using Microsoft.AspNetCore.Mvc;
using System;
using TeamHarrySpyDuhPoject.DataAccess;

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

        [HttpGet("info/{id}")]
        public SpyInfo GetSpyInfo(Guid id)
        {
            return _repo.GetInfo(id);
        }

    }
}
