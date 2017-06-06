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
    public class ParamMatricesController : ApiController
    {
        private ParamsModel db = new ParamsModel();

        // GET: api/ParamMatrices
        public IQueryable<ParamMatrix> GetParamMatrices()
        {
            return db.ParamMatrices;
        }

        // GET: api/ParamMatrices/5
        [ResponseType(typeof(ParamMatrix))]
        public IHttpActionResult GetParamMatrix(int id)
        {
            ParamMatrix paramMatrix = db.ParamMatrices.Find(id);
            if (paramMatrix == null)
            {
                return NotFound();
            }

            return Ok(paramMatrix);
        }

        // PUT: api/ParamMatrices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParamMatrix(int id, ParamMatrix paramMatrix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramMatrix.ID)
            {
                return BadRequest();
            }

            db.Entry(paramMatrix).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamMatrixExists(id))
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

        // POST: api/ParamMatrices
        [ResponseType(typeof(ParamMatrix))]
        public IHttpActionResult PostParamMatrix(ParamMatrix paramMatrix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParamMatrices.Add(paramMatrix);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paramMatrix.ID }, paramMatrix);
        }

        // DELETE: api/ParamMatrices/5
        [ResponseType(typeof(ParamMatrix))]
        public IHttpActionResult DeleteParamMatrix(int id)
        {
            ParamMatrix paramMatrix = db.ParamMatrices.Find(id);
            if (paramMatrix == null)
            {
                return NotFound();
            }

            db.ParamMatrices.Remove(paramMatrix);
            db.SaveChanges();

            return Ok(paramMatrix);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParamMatrixExists(int id)
        {
            return db.ParamMatrices.Count(e => e.ID == id) > 0;
        }
    }
}