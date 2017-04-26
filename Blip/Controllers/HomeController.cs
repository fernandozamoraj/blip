﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blip.Models;

namespace Blip.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}