using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("info/{id}")]
        public SpyInfo GetSpyInfo(Guid id)
        {
            return _repo.GetInfo(id);
        }

        [HttpPost]
        public IActionResult AddSpyToFriendsList(Guid spy1Id, Guid spyFriendToBeId)
        {
            var friend1 = _repo.GetSpyById(spy1Id);
            var friendToBe = _repo.GetSpyById(spyFriendToBeId);
            friend1.Friends.Add(friendToBe);
            return Ok();
        }

        [HttpGet("friendsList")]
        public IActionResult ShowSpyFriends(Guid spyId)
        {
            var spyWithFriends = _repo.GetSpyById(spyId);
            return Ok(spyWithFriends.Friends);
        }

        [HttpGet("crew")]
        public IActionResult ShowPotentialCrew(Guid spyId)
        {
            // get spy
            var spy = _repo.GetSpyById(spyId);
            // see that spy's friend's list
            var spyFriends = spy.Friends;
            // get a spy from that list and see their friends
            
            return Ok(spy);
        }
    }
}
