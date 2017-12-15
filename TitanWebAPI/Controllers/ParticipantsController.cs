using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Data.SqlClient;
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
            db.Database.SqlQuery<decimal>("dbo.GetParticipantScore @ParticipantID", new SqlParameter("ParticipantID", id));
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
        [Route("api/participants/{participantID}/pending")]
        public IQueryable<PendingDocument> PendingDocuments(int participantID)
        {
            return db.PendingDocuments.Where(x => x.ParticipantID == participantID);
        }

        

        [HttpGet]
        [Route("api/participants/byrisk")]
        public IQueryable<ParticipantsByRisk> ParticipantsByRisk()
        {
            return db.ParticipantsByRisk;
        }

        [HttpGet]
        [Route("api/participants/bycountry")]
        public IQueryable<ParticipantsByCountry> ParticipantsByCountry()
        {
            return db.ParticipantsByCountry;
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

            return Ok(participant);
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

            return Ok(db.Participants.Find(participant.ID));
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