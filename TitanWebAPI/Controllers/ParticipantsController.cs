using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Participants;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net", headers: "*", methods: "*")]
    public class ParticipantsController : ApiController
    {
        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/Participants
        public IQueryable<Participant> GetParticipants()
        {
            return db.Participants;
        }

        // GET: api/Participants/5
        [ResponseType(typeof(Participant))]
        public IHttpActionResult GetParticipant(int id)
        {
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }

        [Route("api/participants/{participantID}/score")]
        public decimal GetParticipantScore(int participantID)
        {
            var score = db.Database.SqlQuery<decimal>("dbo.GetParticipantScore @ParticipantID", new SqlParameter("ParticipantID", participantID)).Single();
            return score;
        }

        [HttpGet]
        [Route("api/participants/byrisk")]
        public IQueryable<ParticipantsByRisk> ParticipantsByRisk()
        {
            return db.ParticipantsByRisk;
        }

        // PUT: api/Participants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParticipant(int id, Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participant.ID)
            {
                return BadRequest();
            }

            var updatedParticipant = new Participant()
            {
                ID = participant.ID
            };

            db.Entry(participant.ModifiedByUser).State = EntityState.Modified;
            db.Entry(participant.CreatedByUser).State = EntityState.Modified;
            db.Entry(participant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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

        // POST: api/Participants
        [ResponseType(typeof(Participant))]
        public IHttpActionResult PostParticipant(Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Participants.Add(participant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participant.ID }, participant);
        }

        [HttpPost]
        [Route("api/participants/relationships")]
        public IHttpActionResult PostParticipantRelationship(ParticipantRelationship relationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            relationship.ParticipantID = relationship.Participant.ID;
            relationship.RelatedParticipantID = relationship.RelatedParticipant.ID;
            relationship.RelationshipTypeID = relationship.Type.ID;

            db.ParticipantRelationships.Add(relationship);
            db.Entry(relationship.Participant).State = EntityState.Unchanged;
            db.Entry(relationship.RelatedParticipant).State = EntityState.Detached;
            db.Entry(relationship.Type).State = EntityState.Detached;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = relationship.ID }, relationship);
        }

        [HttpDelete]
        [Route("api/participants/relationships")]
        public IHttpActionResult DeleteParticipantRelationShip(int id)
        {
            ParticipantRelationship relationship = db.ParticipantRelationships.Find(id);
            if (relationship == null)
            {
                return NotFound();
            }

            db.ParticipantRelationships.Remove(relationship);
            db.SaveChanges();

            return Ok(relationship);
        }

        // DELETE: api/Participants/5
        [ResponseType(typeof(Participant))]
        public IHttpActionResult DeleteParticipant(int id)
        {
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return NotFound();
            }

            db.Participants.Remove(participant);
            db.SaveChanges();

            return Ok(participant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantExists(int id)
        {
            return db.Participants.Count(e => e.ID == id) > 0;
        }
    }
}