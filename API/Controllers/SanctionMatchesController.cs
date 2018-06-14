using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Web.Http.Description;
using TitanWebAPI.Models.Sanctions;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class SanctionMatchesController : ApiController
    {
        private SanctionsModel db = new SanctionsModel();

        // GET: api/SanctionMatches
        public IQueryable<SanctionMatch> GetSanctionMatches()
        {
            return db.SanctionMatches;
        }

        [HttpGet]
        [Route("api/sanctionmatches/run/all")]
        public IHttpActionResult RunDiscardAll ()
        {
            var participants = db.Participants;

            int count = 0;

            var sanctions = db.SanctionedItems;

            foreach(Participant participant in participants.ToList())
            {
                var fullname = participant.FullName.Replace(",", "");
                string[] names = fullname.Split(' ');

                
                foreach (SanctionedItem sanction in sanctions.ToList())
                {
                    int matchcount = 0;
                    foreach (string name in names)
                    {
                       if (sanction.FullTerm.IndexOf(name) != -1 && name.Length > 2)
                        {
                            matchcount++;
                        }
                    }
                    if (matchcount >= 2)
                    {
                        SanctionMatch match = new SanctionMatch();
                        match.ParticipantID = participant.ID;
                        match.SanctionListID = sanction.ListID;
                        match.SanctionComments = sanction.Comments;
                        match.SanctionTerm = sanction.FullTerm;
                        match.Date = DateTime.Now;
                        db.SanctionMatches.Add(match);
                        db.SaveChanges();
                        count++;
                    }
                }
              
            }
            return Ok(count);
        }

        // GET: api/SanctionMatches/5
        [ResponseType(typeof(SanctionMatch))]
        public IHttpActionResult GetSanctionMatch(int id)
        {
            SanctionMatch sanctionMatch = db.SanctionMatches.Find(id);
            if (sanctionMatch == null)
            {
                return NotFound();
            }

            return Ok(sanctionMatch);
        }

        // PUT: api/SanctionMatches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanctionMatch(int id, SanctionMatch sanctionMatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanctionMatch.ID)
            {
                return BadRequest();
            }

            db.Entry(sanctionMatch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanctionMatchExists(id))
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

        // POST: api/SanctionMatches
        [ResponseType(typeof(SanctionMatch))]
        public IHttpActionResult PostSanctionMatch(SanctionMatch sanctionMatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            sanctionMatch.Date = DateTime.Now;
            sanctionMatch.Status = "P";

            db.SanctionMatches.Add(sanctionMatch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sanctionMatch.ID }, sanctionMatch);
        }

        // DELETE: api/SanctionMatches/5
        [ResponseType(typeof(SanctionMatch))]
        public IHttpActionResult DeleteSanctionMatch(int id)
        {
            SanctionMatch sanctionMatch = db.SanctionMatches.Find(id);
            if (sanctionMatch == null)
            {
                return NotFound();
            }

            db.SanctionMatches.Remove(sanctionMatch);
            db.SaveChanges();

            return Ok(sanctionMatch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanctionMatchExists(int id)
        {
            return db.SanctionMatches.Count(e => e.ID == id) > 0;
        }
    }
}