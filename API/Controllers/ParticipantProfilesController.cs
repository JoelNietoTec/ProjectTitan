using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Financial;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class ParticipantProfilesController : ApiController
    {
        private FinancialModel db = new FinancialModel();

        // GET: api/ParticipantProfiles
        public IQueryable<ParticipantProfile> GetParticipantProfiles()
        {
            return db.ParticipantProfiles;
        }

        [Route("api/participants/{id}/profile")]
        public IHttpActionResult GetProfileByParticipant(int id)
        {
            FinancialProfile profile = db.FinancialProfiles.Where(x => x.ParticipantID == id).FirstOrDefault();
           
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/ParticipantRelationships/5
        [ResponseType(typeof(ParticipantProfile))]
        public IHttpActionResult PutParticipantRelationship(int id, ParticipantProfile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.ID)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(profile);
        }


        // GET: api/ParticipantProfiles/5
        [ResponseType(typeof(ParticipantProfile))]
        public IHttpActionResult GetParticipantProfile(int id)
        {
            ParticipantProfile participantProfile = db.ParticipantProfiles.Find(id);
            if (participantProfile == null)
            {
                return NotFound();
            }

            return Ok(participantProfile);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantProfileExists(int id)
        {
            return db.ParticipantProfiles.Count(e => e.ID == id) > 0;
        }
    }
}