using SemesterWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SemesterWebProject.Controllers
{
    public class ImageSaverController : Controller
    {
        // GET: ImageSaver
        public ActionResult Index()
        {
            ImageSaverContext imageSaverContext = new ImageSaverContext();
            List<ImageSaverModel> imageSaverModels = imageSaverContext.imageSaverModels.ToList();
            return View(imageSaverModels);
        }
    }
}