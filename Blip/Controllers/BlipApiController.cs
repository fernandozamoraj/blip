using Blip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blip.Controllers
{
    [RoutePrefix("blipapi")]
    public class BlipApiController : ApiController
    {

        [Route("upvote")]
        [HttpPost]
        public string Upvote([FromBody]string feedId)
        {
            int iId = 0;

            int.TryParse(feedId, out iId);
            FeedRepo.Current.VoteUp(iId);
            
            return "Success";
        }

        [Route("feedcount")]
        [HttpGet]
        public HttpResponseMessage FeedCount()
        {
            int feedCount = FeedRepo.Current.GetAll().Count;

            return Request.CreateResponse(HttpStatusCode.OK, new { FeedCount = feedCount });
        }
    }
}
