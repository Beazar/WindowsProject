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
    public class KortingsBonsController : ApiController
    {
        private WindowsProjectServiceContext db = new WindowsProjectServiceContext();

        // GET: api/KortingsBons
        public IQueryable<KortingsBon> GetKortingsBons()
        {
            return db.KortingsBons;
        }

        // GET: api/KortingsBons/5
        [ResponseType(typeof(KortingsBon))]
        public IHttpActionResult GetKortingsBon(int id)
        {
            KortingsBon kortingsBon = db.KortingsBons.Find(id);
            if (kortingsBon == null)
            {
                return NotFound();
            }

            return Ok(kortingsBon);
        }

        // PUT: api/KortingsBons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKortingsBon(int id, KortingsBon kortingsBon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kortingsBon.KortingsBonID)
            {
                return BadRequest();
            }

            db.Entry(kortingsBon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KortingsBonExists(id))
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

        // POST: api/KortingsBons
        [ResponseType(typeof(KortingsBon))]
        public IHttpActionResult PostKortingsBon(KortingsBon kortingsBon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KortingsBons.Add(kortingsBon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kortingsBon.KortingsBonID }, kortingsBon);
        }

        // DELETE: api/KortingsBons/5
        [ResponseType(typeof(KortingsBon))]
        public IHttpActionResult DeleteKortingsBon(int id)
        {
            KortingsBon kortingsBon = db.KortingsBons.Find(id);
            if (kortingsBon == null)
            {
                return NotFound();
            }

            db.KortingsBons.Remove(kortingsBon);
            db.SaveChanges();

            return Ok(kortingsBon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KortingsBonExists(int id)
        {
            return db.KortingsBons.Count(e => e.KortingsBonID == id) > 0;
        }
    }
}