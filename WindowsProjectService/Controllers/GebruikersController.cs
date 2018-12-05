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
    public class GebruikersController : ApiController
    {
        private WindowsProjectServiceContext db = new WindowsProjectServiceContext();

        // GET: api/Gebruikers
        public IQueryable<Gebruiker> GetGebruikers()
        {
            return db.Gebruikers;
        }

        // GET: api/Gebruikers/5
        [ResponseType(typeof(Gebruiker))]
        public IHttpActionResult GetGebruiker(int id)
        {
            Gebruiker gebruiker = db.Gebruikers.Find(id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            return Ok(gebruiker);
        }

        // PUT: api/Gebruikers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGebruiker(int id, Gebruiker gebruiker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gebruiker.GebruikerID)
            {
                return BadRequest();
            }

            db.Entry(gebruiker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GebruikerExists(id))
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

        // POST: api/Gebruikers
        [ResponseType(typeof(Gebruiker))]
        public IHttpActionResult PostGebruiker(Gebruiker gebruiker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gebruikers.Add(gebruiker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gebruiker.GebruikerID }, gebruiker);
        }

        // DELETE: api/Gebruikers/5
        [ResponseType(typeof(Gebruiker))]
        public IHttpActionResult DeleteGebruiker(int id)
        {
            Gebruiker gebruiker = db.Gebruikers.Find(id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            db.Gebruikers.Remove(gebruiker);
            db.SaveChanges();

            return Ok(gebruiker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GebruikerExists(int id)
        {
            return db.Gebruikers.Count(e => e.GebruikerID == id) > 0;
        }
    }
}