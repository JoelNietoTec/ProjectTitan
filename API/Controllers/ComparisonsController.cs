using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Web.Http.Description;
using TitanWebAPI.Models.Participants;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class ComparisonsController : ApiController
    {
        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/Comparisons
        public IQueryable<Comparison> GetComparisons()
        {
            var pending = db.Matches.Where(x => x.Pending == true).Select(i => i.ComparisonID).ToList();

            return db.Comparisons.Where(item => pending.Contains(item.ID));
        }

        // GET: api/Comparisons/5
        [ResponseType(typeof(Comparison))]
        public IHttpActionResult GetComparison(int id)
        {
            Comparison comparison = db.Comparisons.Find(id);
            if (comparison == null)
            {
                return NotFound();
            }

            return Ok(comparison);
        }

        // PUT: api/Comparisons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComparison(int id, Comparison comparison)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comparison.ID)
            {
                return BadRequest();
            }

            db.Entry(comparison).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComparisonExists(id))
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

        // POST: api/Comparisons
        [ResponseType(typeof(Comparison))]
        public IHttpActionResult PostComparison(Comparison comparison)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            comparison.Date = DateTime.Now;

            db.Comparisons.Add(comparison);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comparison.ID }, comparison);
        }

        // DELETE: api/Comparisons/5
        [ResponseType(typeof(Comparison))]
        public IHttpActionResult DeleteComparison(int id)
        {
            Comparison comparison = db.Comparisons.Find(id);
            if (comparison == null)
            {
                return NotFound();
            }

            db.Comparisons.Remove(comparison);
            db.SaveChanges();

            return Ok(comparison);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComparisonExists(int id)
        {
            return db.Comparisons.Count(e => e.ID == id) > 0;
        }
    }
}