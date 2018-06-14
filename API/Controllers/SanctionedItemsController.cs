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
    public class SanctionedItemsController : ApiController
    {
        private SanctionsModel db = new SanctionsModel();

        // GET: api/SanctionedItems
        public IQueryable<SanctionedItem> GetSanctionedItems()
        {
            return db.SanctionedItems;
        }

        
        [Route("api/sanctionlists/{id}/items")]
        public IQueryable<SanctionedItem> GetSanctionsByList(int id)
        {
            return db.SanctionedItems.Where(x => x.ListID == id);
        }

        // GET: api/SanctionedItems/5
        [ResponseType(typeof(SanctionedItem))]
        public IHttpActionResult GetSanctionedItem(int id)
        {
            SanctionedItem sanctionedItem = db.SanctionedItems.Find(id);
            if (sanctionedItem == null)
            {
                return NotFound();
            }

            return Ok(sanctionedItem);
        }

        // PUT: api/SanctionedItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanctionedItem(int id, SanctionedItem sanctionedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanctionedItem.ID)
            {
                return BadRequest();
            }

            db.Entry(sanctionedItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanctionedItemExists(id))
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

        // POST: api/SanctionedItems
        [ResponseType(typeof(SanctionedItem))]
        public IHttpActionResult PostSanctionedItem(SanctionedItem sanctionedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SanctionedItems.Add(sanctionedItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sanctionedItem.ID }, sanctionedItem);
        }

        // DELETE: api/SanctionedItems/5
        [ResponseType(typeof(SanctionedItem))]
        public IHttpActionResult DeleteSanctionedItem(int id)
        {
            SanctionedItem sanctionedItem = db.SanctionedItems.Find(id);
            if (sanctionedItem == null)
            {
                return NotFound();
            }

            db.SanctionedItems.Remove(sanctionedItem);
            db.SaveChanges();

            return Ok(sanctionedItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanctionedItemExists(int id)
        {
            return db.SanctionedItems.Count(e => e.ID == id) > 0;
        }
    }
}