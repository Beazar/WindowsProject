using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WindowsProjectService.Models;

namespace WindowsProjectService.Controllers
{
    public class OndernemingsController : ApiController
    {
        private WindowsProjectServiceContext db = new WindowsProjectServiceContext();

        // GET: api/Ondernemings
        public IQueryable<Onderneming> GetOndernemings()
        {
            return db.Ondernemings;
        }

        // GET: api/Ondernemings/5
        [Route("ondernemings/{id}")]
        [ResponseType(typeof(Onderneming))]
        public IHttpActionResult GetOnderneming(int id)
        {
            Onderneming onderneming = db.Ondernemings.First(user => user.OndernemingID == id);
            if (onderneming == null)
            {
                return NotFound();
            }

            return Ok(onderneming);
        }

        // GET: api/Ondernemings/james
        [Route("ondernemings/{gebruikersnaam}_{wachtwoord}")]
        [ResponseType(typeof(Onderneming))]
        public IHttpActionResult GetLoggedInOnderneming(string gebruikersnaam, string wachtwoord)
        {
            Onderneming onderneming = db.Ondernemings.First(user => (user.Gebruikersnaam == gebruikersnaam) && (user.Wachtwoord == wachtwoord));
            if(onderneming == null)
            {
                return NotFound();
            }
            return Ok(onderneming);
        }

        // PUT: api/Ondernemings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOnderneming(int id, Onderneming onderneming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != onderneming.OndernemingID)
            {
                return BadRequest();
            }

            db.Entry(onderneming).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OndernemingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ondernemings
        [ResponseType(typeof(Onderneming))]
        public IHttpActionResult PostOnderneming(Onderneming onderneming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ondernemings.Add(onderneming);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = onderneming.OndernemingID }, onderneming);
        }

        // DELETE: api/Ondernemings/5
        [ResponseType(typeof(Onderneming))]
        public IHttpActionResult DeleteOnderneming(int id)
        {
            Onderneming onderneming = db.Ondernemings.Find(id);
            if (onderneming == null)
            {
                return NotFound();
            }

            db.Ondernemings.Remove(onderneming);
            db.SaveChanges();

            return Ok(onderneming);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OndernemingExists(int id)
        {
            return db.Ondernemings.Count(e => e.OndernemingID == id) > 0;
        }
    }
}