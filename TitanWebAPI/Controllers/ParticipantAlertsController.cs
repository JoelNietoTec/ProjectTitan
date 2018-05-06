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
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class ParticipantAlertsController : ApiController
    {
        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/ParticipantAlerts
        public IQueryable<ParticipantAlert> GetParticipantAlerts()
        {
            return db.ParticipantAlerts;
        }

        [HttpGet]
        [Route("api/participantalerts/after/{id}")]
        public IQueryable<ParticipantAlert> GetPartcicipantAlertsBefore(int id)
        {
            return db.ParticipantAlerts.Where(x => x.ID > id);
        }

        [HttpGet]
        [Route("api/participants/{id}/alerts")]
        public IQueryable<ParticipantAlert> GetAlertsByParticipant(int id)
        {
            return db.ParticipantAlerts.Where(x => x.ParticipantID == id);
        }

        // GET: api/ParticipantAlerts/5
        [ResponseType(typeof(ParticipantAlert))]
        public IHttpActionResult GetParticipantAlert(int id)
        {
            ParticipantAlert participantAlert = db.ParticipantAlerts.Find(id);
            if (participantAlert == null)
            {
                return NotFound();
            }

            return Ok(participantAlert);
        }

        // PUT: api/ParticipantAlerts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParticipantAlert(int id, ParticipantAlert participantAlert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantAlert.ID)
            {
                return BadRequest();
            }

            db.Entry(participantAlert).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantAlertExists(id))
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

        // POST: api/ParticipantAlerts
        [ResponseType(typeof(ParticipantAlert))]
        public IHttpActionResult PostParticipantAlert(ParticipantAlert participantAlert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParticipantAlerts.Add(participantAlert);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participantAlert.ID }, participantAlert);
        }

        // DELETE: api/ParticipantAlerts/5
        [ResponseType(typeof(ParticipantAlert))]
        public IHttpActionResult DeleteParticipantAlert(int id)
        {
            ParticipantAlert participantAlert = db.ParticipantAlerts.Find(id);
            if (participantAlert == null)
            {
                return NotFound();
            }

            db.ParticipantAlerts.Remove(participantAlert);
            db.SaveChanges();

            return Ok(participantAlert);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantAlertExists(int id)
        {
            return db.ParticipantAlerts.Count(e => e.ID == id) > 0;
        }
    }
}