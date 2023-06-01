using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SemesterWebProject.Models;

namespace SemesterWebProject.Controllers
{
    [EmailSessionAuthorization]
    public class UsersController : Controller
    {
        private ImageSaverContext db = new ImageSaverContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }
        [AllowAnonymous]

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public ActionResult Create([Bind(Include = "userId,userName,userEmail,userPass")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(users);
                db.SaveChanges();
                TempData["SuccessMessage"] = "User registered successfully!";
                return RedirectToAction("Index");
            }

            return View(users);
        }
        [AllowAnonymous]

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        //public ActionResult Login(string userEmail, string userPass)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var data = db.users.FirstOrDefault(s => s.userEmail == userEmail && s.userPass == userPass);

        //        if (data != null)
        //        {
        //            // Add session
        //            Session["userName"] = data.userName;
        //            Session["userEmail"] = data.userEmail;
        //            Session["userId"] = data.userId;

        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ViewBag.error = "Login failed";
        //            return RedirectToAction("Login");
        //        }
        //    }
        //    return View();
        //}
        [AllowAnonymous]
        public ActionResult Login(string userEmail, string userPass)
        {
            if (ModelState.IsValid)
            {
                var data = db.users.FirstOrDefault(s => s.userEmail == userEmail && s.userPass == userPass);

                if (data != null)
                {
                    // Add session
                    FormsAuthentication.SetAuthCookie(data.userName, false);
                    Session["userName"] = data.userName;
                    Session["userEmail"] = data.userEmail;
                    Session["userId"] = data.userId;

                    return RedirectToAction("Index", "imageSaverModels");
                }
            }

            ViewBag.error = "Please Enter Valid Email And Password";
            return View("Login");
        }


        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,userName,userEmail,userPass")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }
        [AllowAnonymous]

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.users.Find(id);
            db.users.Remove(users);
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
