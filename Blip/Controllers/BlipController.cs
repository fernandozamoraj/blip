using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blip.Models;

namespace Blip.Controllers
{
    public class BlipController : Controller
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

        public ActionResult Users()
        {
            return View(BlipRepo.Current.GetAll());
        }

    }
}