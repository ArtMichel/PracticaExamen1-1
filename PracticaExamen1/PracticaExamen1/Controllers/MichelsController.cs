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
using PracticaExamen1.Models;

namespace PracticaExamen1.Controllers
{
    public class MichelsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Michels
        [Authorize]
        public IQueryable<Michel> GetMichels()
        {
            return db.Michels;
        }

        // GET: api/Michels/5
        [Authorize]
        [ResponseType(typeof(Michel))]
        public IHttpActionResult GetMichel(int id)
        {
            Michel michel = db.Michels.Find(id);
            if (michel == null)
            {
                return NotFound();
            }

            return Ok(michel);
        }

        // PUT: api/Michels/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMichel(int id, Michel michel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != michel.MichelID)
            {
                return BadRequest();
            }

            db.Entry(michel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MichelExists(id))
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

        // POST: api/Michels
        [Authorize]
        [ResponseType(typeof(Michel))]
        public IHttpActionResult PostMichel(Michel michel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Michels.Add(michel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = michel.MichelID }, michel);
        }

        // DELETE: api/Michels/5
        [Authorize]
        [ResponseType(typeof(Michel))]
        public IHttpActionResult DeleteMichel(int id)
        {
            Michel michel = db.Michels.Find(id);
            if (michel == null)
            {
                return NotFound();
            }

            db.Michels.Remove(michel);
            db.SaveChanges();

            return Ok(michel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MichelExists(int id)
        {
            return db.Michels.Count(e => e.MichelID == id) > 0;
        }
    }
}