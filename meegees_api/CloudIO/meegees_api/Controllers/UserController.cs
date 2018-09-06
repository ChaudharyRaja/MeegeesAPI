using application.brain.Declaration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace meegees_api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("api/getrequests")]
        public IHttpActionResult GetFriendRequests()
        {
            return Ok();
        }

        [HttpPost]
        [Route("api/processrequests")]
        public IHttpActionResult ProcessFriendRequest([FromBody] List<string> userIds)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/sendrequest")]
        public IHttpActionResult ConnectToUser([FromUri]  string friendId)
        {
            var userId = ((System.Security.Claims.ClaimsIdentity)User?.Identity)?.Claims.Where(x => x.Type == "id")
               .FirstOrDefault().Value;
            return Ok(_userRepo.ConnectToUser(userId, friendId));
        }

        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult SearchUser([FromUri] string searchVal)
        {
            return Ok(_userRepo.SearchUser(searchVal));
        }

        [HttpGet]
        [Route("api/userdetails")]
        public IHttpActionResult GetUserDetails()
        {
            var userId = ((System.Security.Claims.ClaimsIdentity)User?.Identity)?.Claims.Where(x => x.Type == "id")
               .FirstOrDefault().Value;
            return Ok(_userRepo.GetUserDetails(userId));
        }


    }
}
