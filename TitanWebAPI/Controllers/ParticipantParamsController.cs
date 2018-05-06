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
    public class ParticipantParamsController : ApiController
    {
        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/ParticipantParams
        public IQueryable<ParticipantParam> GetParticipantParams()
        {
            return db.ParticipantParams;
        }

        // GET: api/ParticipantParams/5
        [ResponseType(typeof(ParticipantParam))]
        public IHttpActionResult GetParticipantParam(int id)
        {
            ParticipantParam participantParam = db.ParticipantParams.Find(id);
            if (participantParam == null)
            {
                return NotFound();
            }

            return Ok(participantParam);
        }

        [Route("api/participants/{participantID}/params")]
        public IQueryable<ParticipantParam> GetParamsByParticipant(int participantID)
        {
            return db.ParticipantParams.Where(x => x.ParticipantID.Equals(participantID));
        }

        [HttpGet]
        [Route("api/participants/{participantID}/params/{paramID}")]
        [ResponseType(typeof(ParticipantParam))]
        public IHttpActionResult GetParam(int participantID, int paramID)
        {
            ParticipantParam param =  db.ParticipantParams.Where(x => x.ParticipantID.Equals(participantID) && x.ParamID.Equals(paramID)).FirstOrDefault();
            if (param == null)
            {
                return NotFound();
            }

            return Ok(param);
        }

        // PUT: api/ParticipantParams/5
        [ResponseType(typeof(ParticipantParam))]
        public IHttpActionResult PutParticipantParam(int id, ParticipantParam participantParam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantParam.ID)
            {
                return BadRequest();
            }

            db.Entry(participantParam).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantParamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(participantParam);
        }

        // POST: api/ParticipantParams
        [ResponseType(typeof(ParticipantParam))]
        public IHttpActionResult PostParticipantParam(ParticipantParam participantParam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParticipantParams.Add(participantParam);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participantParam.ID }, participantParam);
        }

        // DELETE: api/ParticipantParams/5
        [ResponseType(typeof(ParticipantParam))]
        public IHttpActionResult DeleteParticipantParam(int id)
        {
            ParticipantParam participantParam = db.ParticipantParams.Find(id);
            if (participantParam == null)
            {
                return NotFound();
            }

            db.ParticipantParams.Remove(participantParam);
            db.SaveChanges();

            return Ok(participantParam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantParamExists(int id)
        {
            return db.ParticipantParams.Count(e => e.ID == id) > 0;
        }
    }
}