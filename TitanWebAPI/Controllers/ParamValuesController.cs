using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Params;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class ParamValuesController : ApiController
    {
        private ParamsModel db = new ParamsModel();

        // GET: api/ParamValues
        public IQueryable<ParamValue> GetParamValues()
        {
            return db.ParamValues;
        }

        // GET: api/ParamValues/5
        [ResponseType(typeof(ParamValue))]
        public IHttpActionResult GetParamValue(int id)
        {
            ParamValue paramValue = db.ParamValues.Find(id);
            if (paramValue == null)
            {
                return NotFound();
            }

            return Ok(paramValue);
        }

        [HttpGet]
        [Route("api/paramtables/{id}/values")]
        public IQueryable<ParamValue> GetValuesByTable(int id)
        {
            return db.ParamValues.Where(x => x.ParamTableID == id);
        }

        // PUT: api/ParamValues/5
        [ResponseType(typeof(ParamValue))]
        public IHttpActionResult PutParamValue(int id, ParamValue paramValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramValue.ID)
            {
                return BadRequest();
            }

            db.Entry(paramValue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamValueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(paramValue);
        }

        // POST: api/ParamValues
        [ResponseType(typeof(ParamValue))]
        public IHttpActionResult PostParamValue(ParamValue paramValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParamValues.Add(paramValue);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paramValue.ID }, paramValue);
        }

        // DELETE: api/ParamValues/5
        [ResponseType(typeof(ParamValue))]
        public IHttpActionResult DeleteParamValue(int id)
        {
            ParamValue paramValue = db.ParamValues.Find(id);
            if (paramValue == null)
            {
                return NotFound();
            }

            db.ParamValues.Remove(paramValue);
            db.SaveChanges();

            return Ok(paramValue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParamValueExists(int id)
        {
            return db.ParamValues.Count(e => e.ID == id) > 0;
        }
    }
}