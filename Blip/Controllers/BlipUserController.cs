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
            BlipUserCreateViewModel model = new BlipUserCreateViewModel
            {
                Avatars = BlipRepo.Current.GetAvatars(),
                SelectedAvatar = "",
                User = new BlipUser()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BlipUserCreateViewModel model)
        {

           BlipUser user = BlipRepo.Current.AddUser(model.User);

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
            return View();
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
                Comment = model.Comment
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