using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Sanctions;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class SanctionListsController : ApiController
    {
        private SanctionsModel db = new SanctionsModel();

        // GET: api/SanctionLists
        public IQueryable<SanctionList> GetSanctionLists()
        {
            return db.SanctionLists;
        }

        // GET: api/SanctionLists/5
        [ResponseType(typeof(SanctionList))]
        public IHttpActionResult GetSanctionList(int id)
        {
            SanctionList sanctionList = db.SanctionLists.Find(id);
            if (sanctionList == null)
            {
                return NotFound();
            }

            return Ok(sanctionList);
        }

        // PUT: api/SanctionLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanctionList(int id, SanctionList sanctionList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanctionList.ID)
            {
                return BadRequest();
            }

            db.Entry(sanctionList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanctionListExists(id))
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

        // POST: api/SanctionLists
        [ResponseType(typeof(SanctionList))]
        public IHttpActionResult PostSanctionList(SanctionList sanctionList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SanctionLists.Add(sanctionList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sanctionList.ID }, sanctionList);
        }

        // DELETE: api/SanctionLists/5
        [ResponseType(typeof(SanctionList))]
        public IHttpActionResult DeleteSanctionList(int id)
        {
            SanctionList sanctionList = db.SanctionLists.Find(id);
            if (sanctionList == null)
            {
                return NotFound();
            }

            db.SanctionLists.Remove(sanctionList);
            db.SaveChanges();

            return Ok(sanctionList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanctionListExists(int id)
        {
            return db.SanctionLists.Count(e => e.ID == id) > 0;
        }
    }
}