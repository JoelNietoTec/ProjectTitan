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
    public class AlertReasonsController : ApiController
    {
        private AlertsModel db = new AlertsModel();

        // GET: api/AlertReasons
        public IQueryable<AlertReason> GetAlertReasons()
        {
            return db.AlertReasons;
        }

        // GET: api/AlertReasons/5
        [ResponseType(typeof(AlertReason))]
        public IHttpActionResult GetAlertReason(int id)
        {
            AlertReason alertReason = db.AlertReasons.Find(id);
            if (alertReason == null)
            {
                return NotFound();
            }

            return Ok(alertReason);
        }


        [HttpGet]
        [ResponseType(typeof(AlertReason))]
        [Route("api/AlertReasons/bycode/{code}")]
        public IHttpActionResult GetAlertReasonByCode(string code)
        {
            AlertReason alertReason = db.AlertReasons.Where(x => x.Code == code).FirstOrDefault();
            if (alertReason == null)
            {
                return NotFound();
            }

            return Ok(alertReason);
        }

        // PUT: api/AlertReasons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlertReason(int id, AlertReason alertReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alertReason.ID)
            {
                return BadRequest();
            }

            db.Entry(alertReason).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertReasonExists(id))
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

        // POST: api/AlertReasons
        [ResponseType(typeof(AlertReason))]
        public IHttpActionResult PostAlertReason(AlertReason alertReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            alertReason.AlertSource = null;
            alertReason.AlertPriority = null;

            db.AlertReasons.Add(alertReason);
            db.SaveChanges();

            db.Entry(alertReason).Reference(p => p.AlertSource).Load();
            db.Entry(alertReason).Reference(p => p.AlertPriority).Load();

            return CreatedAtRoute("DefaultApi", new { id = alertReason.ID }, alertReason);
        }

        // DELETE: api/AlertReasons/5
        [ResponseType(typeof(AlertReason))]
        public IHttpActionResult DeleteAlertReason(int id)
        {
            AlertReason alertReason = db.AlertReasons.Find(id);
            if (alertReason == null)
            {
                return NotFound();
            }

            db.AlertReasons.Remove(alertReason);
            db.SaveChanges();

            return Ok(alertReason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlertReasonExists(int id)
        {
            return db.AlertReasons.Count(e => e.ID == id) > 0;
        }
    }
}