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
    public class SanctionsController : ApiController
    {
        private ParticipantsModel db = new ParticipantsModel();

        // GET: api/Sanctions
        public IQueryable<Sanction> GetSanctions()
        {
            return db.Sanctions;
        }

        [HttpGet]
        [Route("api/lists/{id}/sanctions")]
        public IQueryable<Sanction> GetSanctionsByList(int id)
        {
            return db.Sanctions.Where(x => x.ListID == id); 
        }

        // GET: api/Sanctions/5
        [ResponseType(typeof(Sanction))]
        public IHttpActionResult GetSanction(int id)
        {
            Sanction sanction = db.Sanctions.Find(id);
            if (sanction == null)
            {
                return NotFound();
            }

            return Ok(sanction);
        }

        // PUT: api/Sanctions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanction(int id, Sanction sanction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanction.ID)
            {
                return BadRequest();
            }

            db.Entry(sanction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanctionExists(id))
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

        // POST: api/Sanctions
        [ResponseType(typeof(Sanction))]
        public IHttpActionResult PostSanction(Sanction sanction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sanctions.Add(sanction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sanction.ID }, sanction);
        }

        // DELETE: api/Sanctions/5
        [ResponseType(typeof(Sanction))]
        public IHttpActionResult DeleteSanction(int id)
        {
            Sanction sanction = db.Sanctions.Find(id);
            if (sanction == null)
            {
                return NotFound();
            }

            db.Sanctions.Remove(sanction);
            db.SaveChanges();

            return Ok(sanction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanctionExists(int id)
        {
            return db.Sanctions.Count(e => e.ID == id) > 0;
        }
    }
}