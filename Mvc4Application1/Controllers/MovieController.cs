using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4Application1.Models;

namespace Mvc4Application1.Controllers
{
    using System.Globalization;

    public class MovieController : Controller
    {
        private readonly MovieDBContext db = new MovieDBContext();

        ////
        //// GET: /Movie/

        public ActionResult Index()
        {
            ////System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");
            return this.View(this.db.Movies.ToList());
        }

        ////
        //// GET: /Movie/Details/5

        public ActionResult Details(int id = 0)
        {
            Movie movie = this.db.Movies.Find(id);
            if (movie == null)
            {
                return this.HttpNotFound();
            }
            return this.View(movie);
        }

        ////
        //// GET: /Movie/Create

        public ActionResult Create()
        {
            return this.View();
        }

        ////
        //// POST: /Movie/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.db.Movies.Add(movie);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(movie);
        }

        ////
        //// GET: /Movie/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var movie = this.db.Movies.Find(id);
            if (movie == null)
            {
                return this.HttpNotFound();
            }

            return this.View(movie);
        }

        ////
        //// POST: /Movie/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(movie).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }
            
            return this.View(movie);
        }

        ////
        //// GET: /Movie/Delete/5
        
        [ActionName("Delete")]
        public ActionResult DeleteZzz(int id = 0)
        {
            ActionResult res;
            var movie = this.db.Movies.Find(id);
            if (movie == null)
            {
                res = this.HttpNotFound();
            }
            else
            {
                res = this.View(movie);
            }
            
            return res;
        }

        /// <summary>
        /// Sample: POST: /Movie/Delete/5
        /// uses current url (which have id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = this.db.Movies.Find(id);
            this.db.Movies.Remove(movie);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        // Alternative
        ////[HttpPost]
        ////public ActionResult Delete(FormCollection notUsed, int id = 0)
        ////{
        ////    var movie = this.db.Movies.Find(id);
        ////    if (movie == null)
        ////    {
        ////        return this.HttpNotFound();
        ////    }

        ////    this.db.Movies.Remove(movie);
        ////    this.db.SaveChanges();
        ////    return this.RedirectToAction("Index");
        ////}

        public ActionResult SearchIndex(string movieGenre, string searchString)
        {
            ////var genreQry = from d in this.db.Movies
            ////               orderby d.Genre
            ////               select d.Genre;
            var genreLst = this.db.Movies
                .OrderBy(m => m.Genre)
                .Select(m => m.Genre)
                .Distinct()
                .ToList();
            ViewBag.movieGenre = new SelectList(genreLst);

            var movies = from m in this.db.Movies
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            return this.View(string.IsNullOrEmpty(movieGenre) ? movies : movies.Where(x => x.Genre == movieGenre));
        }

        public ActionResult SearchIndexOld(string searchString)
        {
            var movies = from m in this.db.Movies
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            return this.View(movies);
        }

        // Older version of search, unused now
        ////[HttpPost]
        ////public string SearchIndex(FormCollection fc, string searchString)
        ////{
        ////    return "<h3> From [HttpPost]SearchIndex: " + searchString + "</h3>";
        ////}

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}