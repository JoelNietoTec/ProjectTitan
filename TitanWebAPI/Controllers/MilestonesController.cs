using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Roadmaps;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class MilestonesController : ApiController
    {
        private RoadmapModel db = new RoadmapModel();

        // GET: api/Milestones
        public IQueryable<Milestone> GetMilestones()
        {
            return db.Milestones;
        }

        // GET: api/Milestones/5
        [ResponseType(typeof(Milestone))]
        public IHttpActionResult GetMilestone(int id)
        {
            Milestone milestone = db.Milestones.Find(id);
            if (milestone == null)
            {
                return NotFound();
            }

            return Ok(milestone);
        }

        // PUT: api/Milestones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMilestone(int id, Milestone milestone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != milestone.ID)
            {
                return BadRequest();
            }

            db.Entry(milestone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilestoneExists(id))
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

        // POST: api/Milestones
        [ResponseType(typeof(Milestone))]
        public IHttpActionResult PostMilestone(Milestone milestone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Milestones.Add(milestone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = milestone.ID }, milestone);
        }

        // DELETE: api/Milestones/5
        [ResponseType(typeof(Milestone))]
        public IHttpActionResult DeleteMilestone(int id)
        {
            Milestone milestone = db.Milestones.Find(id);
            if (milestone == null)
            {
                return NotFound();
            }

            db.Milestones.Remove(milestone);
            db.SaveChanges();

            return Ok(milestone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MilestoneExists(int id)
        {
            return db.Milestones.Count(e => e.ID == id) > 0;
        }
    }
}