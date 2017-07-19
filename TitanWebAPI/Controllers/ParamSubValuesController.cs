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
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net", headers: "*", methods: "*")]
    public class ParamSubValuesController : ApiController
    {
        private ParamsModel db = new ParamsModel();

        // GET: api/ParamSubValues
        public IQueryable<ParamSubValue> GetParamSubValues()
        {
            return db.ParamSubValues;
        }

        // GET: api/ParamSubValues/5
        [ResponseType(typeof(ParamSubValue))]
        public IHttpActionResult GetParamSubValue(int id)
        {
            ParamSubValue paramSubValue = db.ParamSubValues.Find(id);
            if (paramSubValue == null)
            {
                return NotFound();
            }

            return Ok(paramSubValue);
        }

        // PUT: api/ParamSubValues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParamSubValue(int id, ParamSubValue paramSubValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramSubValue.ID)
            {
                return BadRequest();
            }

            db.Entry(paramSubValue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamSubValueExists(id))
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

        // POST: api/ParamSubValues
        [ResponseType(typeof(ParamSubValue))]
        public IHttpActionResult PostParamSubValue(ParamSubValue paramSubValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParamSubValues.Add(paramSubValue);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paramSubValue.ID }, paramSubValue);
        }

        // DELETE: api/ParamSubValues/5
        [ResponseType(typeof(ParamSubValue))]
        public IHttpActionResult DeleteParamSubValue(int id)
        {
            ParamSubValue paramSubValue = db.ParamSubValues.Find(id);
            if (paramSubValue == null)
            {
                return NotFound();
            }

            db.ParamSubValues.Remove(paramSubValue);
            db.SaveChanges();

            return Ok(paramSubValue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParamSubValueExists(int id)
        {
            return db.ParamSubValues.Count(e => e.ID == id) > 0;
        }
    }
}