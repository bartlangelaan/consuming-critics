﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using s0895604.Models;

namespace s0895604.Controllers
{
    [AuthorizeLoggedIn]
    public class ReviewsController : BaseController
    {
        // GET: Reviews
        public ActionResult Index(int? category, string search)
        {
            if (LoggedInUser.Role == UserRole.Admin)
            {
                var reviews = db.Reviews.Include(r => r.Category).Include(r => r.User);
                return View(reviews.ToList());
            }
            else
            {
                var reviews = db.Reviews.Include(r => r.Category).Where(a => a.Active);

                if (category != null)
                    reviews = reviews.Where(a => a.Category.CategoryId == category);

                if (!string.IsNullOrEmpty(search))
                    reviews = reviews.Where(
                        a =>
                            a.Content.ToLower().Contains(search.ToLower()) ||
                            a.Name.ToLower().Contains(search.ToLower())
                        );

                ViewBag.category = new SelectList(db.Categories, "CategoryId", "Name", category);
                ViewBag.search = search;

                return View("IndexPublic", reviews);
            }
        }

        // GET: Reviews/Mine
        public ActionResult Mine()
        {
            var reviews = db.Reviews.Include(r => r.Category).Where(a => a.UserId == LoggedInUser.UserId);

            ViewBag.CanCreateNew = db.Ratings.Count(r => r.UserId == LoggedInUser.UserId) >= 3;

            return View("IndexMine", reviews);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mine(int reviewId)
        {

            var review = db.Reviews.Find(reviewId);
            review.Active = !review.Active;
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Mine");
        }


        // GET: Reviews/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }

            ViewBag.AlreadyRated = db.Ratings.Any(a => a.UserId == LoggedInUser.UserId && a.ReviewId == id);

            return View(review);
        }

        // POST: Reviews/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id, int rating)
        {
            db.Ratings.Add(new Rating
            {
                ReviewId = id,
                UserId = LoggedInUser.UserId,
                RatingNumber = rating
            });
            db.SaveChanges();

            return RedirectToAction("Details");
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Content,CategoryId")] Review review)
        {
            review.User = LoggedInUser;
            review.UserId = LoggedInUser.UserId;
            review.CreatedDateTime = DateTime.Now;
            review.Active = true;
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", review.CategoryId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", review.CategoryId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewId,Name,Content,CategoryId")] Review review)
        {
            ModelState.Remove("CreatedDateTime");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                var toUpdate = db.Reviews.Single(p => p.ReviewId == review.ReviewId);
                toUpdate.Name = review.Name;
                toUpdate.CategoryId = review.CategoryId;
                toUpdate.Content = review.Content;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", review.CategoryId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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