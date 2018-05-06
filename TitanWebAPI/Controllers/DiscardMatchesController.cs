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
    public class DiscardMatchesController : ApiController
    {
        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/DiscardMatches
        public IQueryable<DiscardMatch> GetDiscardMatches()
        {
            return db.DiscardMatches;
        }

        [HttpGet]
        [Route("api/discards/{id}/matches")]
        public IQueryable<DiscardMatch> GetMatchesByDiscard(int id)
        {
            return db.DiscardMatches.Where(x => x.DiscardID == id);
        }

        // GET: api/DiscardMatches/5
        [ResponseType(typeof(DiscardMatch))]
        public IHttpActionResult GetDiscardMatch(int id)
        {
            DiscardMatch discardMatch = db.DiscardMatches.Find(id);
            if (discardMatch == null)
            {
                return NotFound();
            }

            return Ok(discardMatch);
        }

        // PUT: api/DiscardMatches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiscardMatch(int id, DiscardMatch discardMatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discardMatch.ID)
            {
                return BadRequest();
            }

            discardMatch.Pending = false;

            db.Entry(discardMatch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscardMatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(discardMatch);
        }

        [HttpGet]
        [Route("api/discards/matches/{id}/{valid}")]
        [ResponseType(typeof(DiscardMatch))]
        public IHttpActionResult ValidDiscard(int id, string valid)
        {
            DiscardMatch discard = db.DiscardMatches.Find(id);

            if (discard == null)
            {
                return NotFound();
            }

            if (valid == "valid")
            {
                discard.Valid = true;
            } else
            {
                discard.Valid = false;
            }

            discard.Pending = false;

            db.Entry(discard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!DiscardMatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(discard);
        }
        // POST: api/DiscardMatches
        [ResponseType(typeof(DiscardMatch))]
        public IHttpActionResult PostDiscardMatch(DiscardMatch discardMatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            discardMatch.Pending = true;

            db.DiscardMatches.Add(discardMatch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = discardMatch.ID }, discardMatch);
        }

        // DELETE: api/DiscardMatches/5
        [ResponseType(typeof(DiscardMatch))]
        public IHttpActionResult DeleteDiscardMatch(int id)
        {
            DiscardMatch discardMatch = db.DiscardMatches.Find(id);
            if (discardMatch == null)
            {
                return NotFound();
            }

            db.DiscardMatches.Remove(discardMatch);
            db.SaveChanges();

            return Ok(discardMatch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiscardMatchExists(int id)
        {
            return db.DiscardMatches.Count(e => e.ID == id) > 0;
        }
    }
}