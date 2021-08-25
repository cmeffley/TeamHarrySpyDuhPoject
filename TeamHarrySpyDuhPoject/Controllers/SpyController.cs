using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet("skills/{skill}")]
        public IEnumerable<SpyWithSkill> GetSpyBySkill(SpySkills skill)
        {
            var skilledSpies = _repo.GetBySkill(skill);

            return skilledSpies.Select(spy => 
                new SpyWithSkill
                { 
                    Id = spy.Id, 
                    Name = spy.Name 
                });
        }

    }
}
