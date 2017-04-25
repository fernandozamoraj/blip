using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blip.Models;

namespace Blip.Controllers
{
    public class BlipUserController : Controller
    {
        // GET: BlipUser
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BlipUser model)
        {
           BlipUser user = BlipRepo.Current.AddUser(model);

            this.HttpContext.Session.Add("CurrentUser", user);

            return RedirectToAction("Feed");
        }

        private BlipUser GetUser()
        {
            BlipUser user = null;

            user = this.HttpContext.Session["CurrentUser"] as BlipUser;

            return user;
        }

        public ActionResult Feed()
        {
            List<UserFeed> feed = FeedRepo.Current.GetAll();
            
            feed.Sort((x, y) => y.FeedId - x.FeedId);

            FeedViewModel model = new FeedViewModel
            {
                Feed = feed,
                Message = "",
                User = GetUser()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Feed(FeedViewModel model)
        {


            BlipUser user = GetUser();

            if(user == null)
            {
                return RedirectToAction("Index");
            }

            UserFeed feed = new UserFeed
            {
                Avatar = user.Avatar,
                UserName = user.UserName,
                Comment = model.Message
            };

            FeedRepo.Current.Add(feed);

            return RedirectToAction("Feed");
        }

        public ActionResult Users()
        {
            return View(BlipRepo.Current.GetAll());
        }

    }
}