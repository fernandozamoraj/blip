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

        [Route("createwinner")]
        [HttpGet]
        public HttpResponseMessage CreateWinner()
        {
            BlipRepo.Current.CreateWinner();

            return Request.CreateResponse(HttpStatusCode.OK, new { Winner = BlipRepo.Current.GetWinner() });
        }

        [Route("getwinner")]
        [HttpGet]
        public HttpResponseMessage GetWinner()
        {
            BlipUser user = BlipRepo.Current.GetWinner();

            
            return Request.CreateResponse(HttpStatusCode.OK, new { Winner = user });
        }


        [Route("resetwinner")]
        [HttpGet]
        public HttpResponseMessage ResetWinner()
        {
            BlipRepo.Current.SetWinnerClaimed();
            
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Success" });
        }


        [Route("admin")]
        [HttpGet]
        public HttpResponseMessage Admin()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "blipapi/createwinner, blipapi/getwinner, blipapi/resetwinner, blipapi/resetdb" });
        }

        [Route("resetdb")]
        [HttpGet]
        public HttpResponseMessage ResetDb()
        {
            BlipRepo.Current.Clear();
            FeedRepo.Current.Clear();

            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "db has been reset" });
        }
    }
}
