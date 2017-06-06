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
    public class ParamMastersController : ApiController
    {
        private ParamsModel db = new ParamsModel();

        // GET: api/ParamMasters
        public IQueryable<ParamMaster> GetParamMasters()
        {
            return db.ParamMasters;
        }

        // GET: api/ParamMasters/5
        [ResponseType(typeof(ParamMaster))]
        public IHttpActionResult GetParamMaster(int id)
        {
            ParamMaster paramMaster = db.ParamMasters.Find(id);
            if (paramMaster == null)
            {
                return NotFound();
            }

            return Ok(paramMaster);
        }

        // PUT: api/ParamMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParamMaster(int id, ParamMaster paramMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(paramMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamMasterExists(id))
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

        // POST: api/ParamMasters
        [ResponseType(typeof(ParamMaster))]
        public IHttpActionResult PostParamMaster(ParamMaster paramMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParamMasters.Add(paramMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paramMaster.ID }, paramMaster);
        }

        // DELETE: api/ParamMasters/5
        [ResponseType(typeof(ParamMaster))]
        public IHttpActionResult DeleteParamMaster(int id)
        {
            ParamMaster paramMaster = db.ParamMasters.Find(id);
            if (paramMaster == null)
            {
                return NotFound();
            }

            db.ParamMasters.Remove(paramMaster);
            db.SaveChanges();

            return Ok(paramMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParamMasterExists(int id)
        {
            return db.ParamMasters.Count(e => e.ID == id) > 0;
        }
    }
}