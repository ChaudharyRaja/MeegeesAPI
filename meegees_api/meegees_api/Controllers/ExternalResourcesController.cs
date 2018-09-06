using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using application.brain.Defination;
using meegees_api.Pushers;

namespace meegees_api.Controllers
{
    
    public class ExternalResourcesController : ApiController
    {
        private readonly ExternalResources _externalResources;
   

        public ExternalResourcesController(ExternalResources externalResources)
        {
            _externalResources = externalResources;
           
        }

        [HttpGet]
        [Route("api/search")]
        public IHttpActionResult SearchYoutubeVideo([FromUri] string query = null)
        {
            return Ok(_externalResources.SearchYoutube(query ?? "top trending videos"));
        }

        [HttpGet]
        [Route("api/share")]
        public IHttpActionResult ShareVideo([FromUri] string msg="video is shared with you")
        {
        
            return Ok();
        }
    }
}
