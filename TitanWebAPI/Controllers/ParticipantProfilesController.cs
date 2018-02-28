using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Financial;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net", headers: "*", methods: "*")]
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
            ParticipantProfile profile = db.ParticipantProfiles.Where(x => x.ParticipantID == id).FirstOrDefault();

            if (profile == null)
            {
                return NotFound();
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