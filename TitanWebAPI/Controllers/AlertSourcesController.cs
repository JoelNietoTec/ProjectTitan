using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Alerts;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class AlertSourcesController : ApiController
    {
        private AlertsModel db = new AlertsModel();

        // GET: api/AlertSources
        public IQueryable<AlertSource> GetAlertSources()
        {
            return db.AlertSources;
        }

        // GET: api/AlertSources/5
        [ResponseType(typeof(AlertSource))]
        public IHttpActionResult GetAlertSource(int id)
        {
            AlertSource alertSource = db.AlertSources.Find(id);
            if (alertSource == null)
            {
                return NotFound();
            }

            return Ok(alertSource);
        }

        // PUT: api/AlertSources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlertSource(int id, AlertSource alertSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alertSource.ID)
            {
                return BadRequest();
            }

            db.Entry(alertSource).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertSourceExists(id))
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

        // POST: api/AlertSources
        [ResponseType(typeof(AlertSource))]
        public IHttpActionResult PostAlertSource(AlertSource alertSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AlertSources.Add(alertSource);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = alertSource.ID }, alertSource);
        }

        // DELETE: api/AlertSources/5
        [ResponseType(typeof(AlertSource))]
        public IHttpActionResult DeleteAlertSource(int id)
        {
            AlertSource alertSource = db.AlertSources.Find(id);
            if (alertSource == null)
            {
                return NotFound();
            }

            db.AlertSources.Remove(alertSource);
            db.SaveChanges();

            return Ok(alertSource);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlertSourceExists(int id)
        {
            return db.AlertSources.Count(e => e.ID == id) > 0;
        }
    }
}