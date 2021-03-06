﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using s0895604.Models;

namespace s0895604.Controllers
{
    [AuthorizeLoggedIn]
    public class RatingsController : BaseController
    {

        // GET: Ratings[/Index/5]
        public ActionResult Index(int? id)
        {
            var ratings = db.Ratings.Include(r => r.Review).Include(r => r.User);
            if (id != null)
            {
                ratings = (from a in ratings where a.ReviewId == id select a);
                ViewBag.Review = db.Reviews.Find(id);
            }

            return View(ratings.ToList());
        }

        // GET: Ratings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // GET: Ratings/Create
        public ActionResult Create()
        {
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Name");
            ViewBag.UserId = new SelectList(db.Accounts, "UserId", "Username", LoggedInUser.UserId);
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewId,RatingNumber")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Ratings.Add(rating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Name", rating.ReviewId);
            ViewBag.UserId = new SelectList(db.Accounts, "UserId", "Username", rating.ReviewId);
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Name", rating.ReviewId);
            ViewBag.UserId = new SelectList(db.Accounts, "UserId", "Username", rating.ReviewId);
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingId,ReviewId,UserId,RatingNumber")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Name", rating.ReviewId);
            ViewBag.UserId = new SelectList(db.Accounts, "UserId", "Username", rating.ReviewId);
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rating rating = db.Ratings.Find(id);
            db.Ratings.Remove(rating);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AuthorizeLoggedIn(true)]
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
