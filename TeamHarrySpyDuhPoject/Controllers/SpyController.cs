using Microsoft.AspNetCore.Mvc;
using System;
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
    }
}
