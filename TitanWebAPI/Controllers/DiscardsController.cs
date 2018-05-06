using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Participants;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class DiscardsController : ApiController
    {
        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/Discards
        public IQueryable<Discard> GetDiscards()
        {
            return db.Discards;
        }

        // GET: api/Discards/5
        [ResponseType(typeof(Discard))]
        public IHttpActionResult GetDiscard(int id)
        {
            Discard discard = db.Discards.Find(id);
            if (discard == null)
            {
                return NotFound();
            }

            return Ok(discard);
        }

        // PUT: api/Discards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiscard(int id, Discard discard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discard.ID)
            {
                return BadRequest();
            }

            db.Entry(discard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscardExists(id))
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

        // POST: api/Discards
        [ResponseType(typeof(Discard))]
        public IHttpActionResult PostDiscard(Discard discard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            discard.Date = DateTime.Now;

            db.Discards.Add(discard);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = discard.ID }, discard);
        }

        // DELETE: api/Discards/5
        [ResponseType(typeof(Discard))]
        public IHttpActionResult DeleteDiscard(int id)
        {
            Discard discard = db.Discards.Find(id);
            if (discard == null)
            {
                return NotFound();
            }

            db.Discards.Remove(discard);
            db.SaveChanges();

            return Ok(discard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiscardExists(int id)
        {
            return db.Discards.Count(e => e.ID == id) > 0;
        }
    }
}