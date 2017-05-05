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
        public HttpResponseMessage Upvote(LikeEntry likeEntry)
        {
            int likesCount = FeedRepo.Current.VoteUp(likeEntry.FeedId, likeEntry.UserId);
            
            return Request.CreateResponse(HttpStatusCode.OK, new { LikesCount = likesCount });
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


        [Route("addfeed")]
        [HttpPost]
        public HttpResponseMessage AddFeed(FeedEntry model)
        {

            UserFeed feed = new UserFeed
            {
                Avatar = model.Avatar,
                UserName = model.UserName,
                Comment = model.Comment
            };

            FeedRepo.Current.Add(feed);

            return Request.CreateResponse(HttpStatusCode.OK, feed);
        }

        private BlipUser GetUser()
        {
            BlipUser user = null;

            try
            {
                System.Console.WriteLine("Api Session ID: {0}", System.Web.HttpContext.Current.Session.SessionID);
                user = System.Web.HttpContext.Current.Session["CurrentUser"] as BlipUser;
            }
            catch (Exception e)
            {
                //TODO fix this
                user = new BlipUser
                {
                    Avatar = "av1.PNG",
                    UserId = 0,
                    UserName = "TODO"
                };
            }

            return user;
        }

        [Route("login")]
        [HttpPost]
        public HttpResponseMessage Create(LoginModel model)
        {

            BlipUser user = new BlipUser
            {
                Avatar = model.Avatar,
                UserName = model.UserName,
            };

            user = BlipRepo.Current.AddUser(user);

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("getall")]
        public HttpResponseMessage GetAll()
        {

            BlipUser user = GetUser();

            List<UserFeed> feed = FeedRepo.Current.GetAll();

            feed.Sort((x, y) => y.FeedId - x.FeedId);

            FeedViewModel model = new FeedViewModel
            {
                Feed = feed,
                Comment = "",
                User = user
            };

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [Route("getavatars")]
        public HttpResponseMessage GetAvatars()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Avatars = BlipRepo.Current.GetAvatars() });
        }
    }
}
