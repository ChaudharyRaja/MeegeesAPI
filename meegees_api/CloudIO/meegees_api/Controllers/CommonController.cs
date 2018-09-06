using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using application.brain.Declaration;
using application.data.Models;


namespace meegees_api.Controllers
{
    public class CommonController : ApiController
    {
        private readonly IInterests _interests;
        private readonly ICommon _common;
        public CommonController(IInterests interests, ICommon common)
        {
            _interests = interests;
            _common = common;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/interest")]
        public List<Interest> GetInterests([FromUri] int intCatId = 0, int intId = 0)
        {
            return _interests.GetInterests(intCatId, intId);
        }

        [HttpGet]
        [Authorize]
        [Route("api/connect")]
        public IHttpActionResult RegisterUserConnection([FromUri] string connectionId)
        {
            var userId = ((ClaimsIdentity)User?.Identity)?.Claims.Where(x => x.Type == "id")
                .FirstOrDefault().Value;
            return Ok(userId != null && _common.RegisterUserConnection(connectionId, userId));
        }

        [HttpGet]
        [Authorize]
        [Route("api/deleteconnected")]
        public IHttpActionResult DeleteUserConnection()
        {
            var userId = ((ClaimsIdentity)User?.Identity)?.Claims.Where(x => x.Type == "id")
                .FirstOrDefault().Value;
            return Ok(userId != null && _common.DeleteUserConnection(userId));
        }

        [HttpPost]
        [Authorize]
        [Route("api/addfolder")]
        public IHttpActionResult AddFolder([FromBody] FolderModel body)
        {
            var userId = ((ClaimsIdentity)User?.Identity)?.Claims.Where(x => x.Type == "id")
               .FirstOrDefault().Value;
            body.UserId = userId;
            return Ok(_common.AddFolder(body));
        }

        [HttpGet]     
        [Route("api/folders")]
        public IHttpActionResult GetFolders()
        {
            var userId = ((ClaimsIdentity)User?.Identity)?.Claims.Where(x => x.Type == "id")
               .FirstOrDefault().Value;           
            return Ok(_common.GetFolders(userId));
        }
    }
}
