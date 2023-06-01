using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SemesterWebProject.Models;

namespace SemesterWebProject.Controllers
{
    [EmailSessionAuthorization]

    public class ImageSaverModelsController : Controller
    {
        private ImageSaverContext db = new ImageSaverContext();

        // GET: ImageSaverModels
        public ActionResult Index()
        {
            return View(db.imageSaverModels.ToList());
        }

        // GET: ImageSaverModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageSaverModel imageSaverModel = db.imageSaverModels.Find(id);
            if (imageSaverModel == null)
            {
                return HttpNotFound();
            }
            return View(imageSaverModel);
        }

        // GET: ImageSaverModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageSaverModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imgId,imgTitle,imgDisc,imgSelf")] ImageSaverModel imageSaverModel, HttpPostedFileBase imglink) 
        {
            if (ModelState.IsValid)
            {
                if(imglink != null)
                {
                    imageSaverModel.imgSelf = new byte[imglink.ContentLength];
                    imglink.InputStream.Read(imageSaverModel.imgSelf, 0, imglink.ContentLength);
                    db.imageSaverModels.Add(imageSaverModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }

            return View(imageSaverModel);
        }

        // GET: ImageSaverModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageSaverModel imageSaverModel = db.imageSaverModels.Find(id);
            if (imageSaverModel == null)
            {
                return HttpNotFound();
            }
            return View(imageSaverModel);
        }

        // POST: ImageSaverModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imgId,imgTitle,imgDisc,imgSelf")] ImageSaverModel imageSaverModel, HttpPostedFileBase imglink)
        {
            if (ModelState.IsValid)
            {
                imageSaverModel.imgSelf = new byte[imglink.ContentLength];
                imglink.InputStream.Read(imageSaverModel.imgSelf, 0, imglink.ContentLength);
                db.Entry(imageSaverModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imageSaverModel);
        }

        // GET: ImageSaverModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageSaverModel imageSaverModel = db.imageSaverModels.Find(id);
            if (imageSaverModel == null)
            {
                return HttpNotFound();
            }
            return View(imageSaverModel);
        }

        // POST: ImageSaverModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageSaverModel imageSaverModel = db.imageSaverModels.Find(id);
            db.imageSaverModels.Remove(imageSaverModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
