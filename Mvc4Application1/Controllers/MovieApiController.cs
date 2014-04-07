namespace Andriy.Mvc4Application1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Andriy.Mvc4Application1.Models;

    public class MovieApiController : ApiController
    {
        private MovieDBContext db = new MovieDBContext();
                
        /// <summary>
        /// Gets available movie list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Movie> GetMovies()
        {
            return this.db.Movies.AsEnumerable();
        }

        // GET api/MovieApi/5
        public Movie GetMovie(int id)
        {
            Movie movie = this.db.Movies.Find(id);
            if (movie == null)
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return movie;
        }

        // PUT api/MovieApi/5
        public HttpResponseMessage PutMovie(int id, Movie movie)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            if (id != movie.ID)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            this.db.Entry(movie).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/MovieApi
        public HttpResponseMessage PostMovie(Movie movie)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Movies.Add(movie);
                this.db.SaveChanges();

                HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Created, movie);
                response.Headers.Location = new Uri(this.Url.Link("DefaultApi", new { id = movie.ID }));
                return response;
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }
        }

        // DELETE api/MovieApi/5
        public HttpResponseMessage DeleteMovie(int id)
        {
            Movie movie = this.db.Movies.Find(id);
            if (movie == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this.db.Movies.Remove(movie);

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, movie);
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}