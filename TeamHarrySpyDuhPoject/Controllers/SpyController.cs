using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamHarrySpyDuhPoject.DataAccess;
using TeamHarrySpyDuhPoject.DataAccess.TeamHarrySpyDuhPoject.DataAccess;
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

        [HttpGet("agency/{agencyId}")]
        public IEnumerable<Spy> GetSpiesByAgency(Guid agencyId)
        {
            return _repo.GetAgencySpies(agencyId);
        }

        [HttpPost("addToFriendsList")]
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

        [HttpPost("addToEnemiesList")]
        public IActionResult AddSpyToEnemiesList(Guid selectedSpy, Guid assignedEnemy)
        {
            var spy1 = _repo.GetSpyById(selectedSpy);
            var spy2 = _repo.GetSpyById(assignedEnemy);
            spy1.Enemies.Add(spy2);
            return Ok();

        }

        [HttpGet("enemiesList")]
        public IActionResult ShowSpyEnemies(Guid enemyId)
        {
            var enemySpies = _repo.GetSpyById(enemyId);
            var spyWithEnemies = _repo.GetSpyById(enemyId);
            return Ok(spyWithEnemies.Enemies);
        }

        [HttpGet("crew")]
        public IActionResult ShowPotentialCrew(Guid spyId)
        {
            // get spy
            var spy = _repo.GetSpyById(spyId);
            // see that spy's friend's list
            var spyFriends = spy.Friends;

            var crew = new List<Spy>();

            foreach (var friend in spyFriends)
            {
                crew.Add(friend);
            }
            return Ok(crew);
            
        }

        [HttpGet("daysRemaining")]
        public IActionResult TimeLeft(Guid spyId)
        {
            var spy = _repo.GetSpyById(spyId);

            var today = DateTime.Now;
            var dateDiff = spy.MissionEndDate.Subtract(today);

            var howManyDaysLeft = dateDiff.Days;

            return Ok(howManyDaysLeft);
        }

        [HttpDelete("{spyId}/removeSkill/{skill}")]
        public IActionResult RemoveSkill(Guid spyId, SpySkills skill)
        {

            //get the spy from the repository
            var spy = _repo.GetSpyById(spyId);
            //modify the skills list to add the new skill
            spy.Skills.RemoveAll(spySkill => spySkill == skill);
            //spy.Skills.RemoveAll(x => x == skill);
            //return the spy with the new skill attached
            //...profit

            return Ok(spy);
        }

        [HttpDelete("{spyId}/removeService/{service}")]
        public IActionResult RemoveService(Guid spyId, SpyServices service)
        {

            //get the spy from the repository
            var spy = _repo.GetSpyById(spyId);
            //modify the skills list to add the new skill
            spy.Services.RemoveAll(spyService => spyService == service);
            //spy.Skills.RemoveAll(x => x == skill);
            //return the spy with the new skill attached
            //...profit

            return Ok(spy);
        }


    }
}
