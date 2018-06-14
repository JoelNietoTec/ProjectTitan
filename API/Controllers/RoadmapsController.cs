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
    public class RoadmapsController : ApiController
    {
        private RoadmapModel db = new RoadmapModel();

        // GET: api/Roadmaps
        public IQueryable<Roadmap> GetRoadmaps()
        {
            return db.Roadmaps;
        }

        [HttpGet]
        [Route("api/recurrences")]
        public IQueryable<Recurrence> GetRecurrence()
        {
            return db.Recurrences;
        }

        // GET: api/Roadmaps/5
        [ResponseType(typeof(Roadmap))]
        public IHttpActionResult GetRoadmap(int id)
        {
            Roadmap roadmap = db.Roadmaps.Find(id);
            if (roadmap == null)
            {
                return NotFound();
            }

            return Ok(roadmap);
        }

        // PUT: api/Roadmaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoadmap(int id, Roadmap roadmap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roadmap.ID)
            {
                return BadRequest();
            }

            db.Entry(roadmap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoadmapExists(id))
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

        // POST: api/Roadmaps
        [ResponseType(typeof(Roadmap))]
        public IHttpActionResult PostRoadmap(Roadmap roadmap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roadmaps.Add(roadmap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roadmap.ID }, roadmap);
        }

        // DELETE: api/Roadmaps/5
        [ResponseType(typeof(Roadmap))]
        public IHttpActionResult DeleteRoadmap(int id)
        {
            Roadmap roadmap = db.Roadmaps.Find(id);
            if (roadmap == null)
            {
                return NotFound();
            }

            db.Roadmaps.Remove(roadmap);
            db.SaveChanges();

            return Ok(roadmap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoadmapExists(int id)
        {
            return db.Roadmaps.Count(e => e.ID == id) > 0;
        }
    }
}