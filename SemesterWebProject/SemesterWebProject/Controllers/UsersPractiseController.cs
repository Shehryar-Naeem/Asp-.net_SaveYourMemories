using SemesterWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SemesterWebProject.Controllers
{
    public class UsersPractiseController : Controller
    {
        // GET: UsersPractise
        public ActionResult UserDetailpractise()
        {
            ImageSaverContext imageSaverContext = new ImageSaverContext();
            List<Users> user = imageSaverContext.users.ToList();
            return View(user);
        }
    }
}