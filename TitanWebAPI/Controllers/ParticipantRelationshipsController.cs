using System.Data;
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
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net", headers: "*", methods: "*")]
    public class ParticipantRelationshipsController : ApiController
    {

        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/ParticipantRelationships
        public IQueryable<ParticipantRelationship> GetParticipantRelationships()
        {
            return db.ParticipantRelationships;
        }

        [HttpGet]
        [Route("api/participants/{id}/relationships")]
        public IQueryable<ParticipantRelationship> GetRelationshipsParticipants(int id)
        {
            return db.ParticipantRelationships.Where(x => x.ParticipantID == id || x.RelatedParticipantID == id);
        }

        // GET: api/ParticipantRelationships/5
        [ResponseType(typeof(ParticipantRelationship))]
        public IHttpActionResult GetParticipantRelationship(int id)
        {
            ParticipantRelationship participantRelationship = db.ParticipantRelationships.Find(id);
            if (participantRelationship == null)
            {
                return NotFound();
            }

            return Ok(participantRelationship);
        }

        // PUT: api/ParticipantRelationships/5
        [ResponseType(typeof(ParticipantRelationship))]
        public IHttpActionResult PutParticipantRelationship(int id, ParticipantRelationship participantRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantRelationship.ID)
            {
                return BadRequest();
            }

            db.Entry(participantRelationship).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantRelationshipExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(participantRelationship);
        }

        // POST: api/ParticipantRelationships
        [ResponseType(typeof(ParticipantRelationship))]
        public IHttpActionResult PostParticipantRelationship(ParticipantRelationship participantRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParticipantRelationships.Add(participantRelationship);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participantRelationship.ID }, participantRelationship);
        }

        // DELETE: api/ParticipantRelationships/5
        [ResponseType(typeof(ParticipantRelationship))]
        public IHttpActionResult DeleteParticipantRelationship(int id)
        {
            ParticipantRelationship participantRelationship = db.ParticipantRelationships.Find(id);
            if (participantRelationship == null)
            {
                return NotFound();
            }

            db.ParticipantRelationships.Remove(participantRelationship);
            db.SaveChanges();

            return Ok(participantRelationship);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantRelationshipExists(int id)
        {
            return db.ParticipantRelationships.Count(e => e.ID == id) > 0;
        }
    }
}