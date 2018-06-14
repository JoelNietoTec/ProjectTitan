using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Params;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class ParamTablesController : ApiController
    {
        private ParamsModel db = new ParamsModel();

        // GET: api/ParamTables
        public IQueryable<ParamTable> GetParamTables()
        {
            return db.ParamTables;
        }

        // GET: api/ParamTables/5
        [ResponseType(typeof(ParamTable))]
        public IHttpActionResult GetParamTable(int id)
        {
            ParamTable paramTable = db.ParamTables.Find(id);
            if (paramTable == null)
            {
                return NotFound();
            }

            return Ok(paramTable);
        }

        // PUT: api/ParamTables/5
        [ResponseType(typeof(ParamTable))]
        public IHttpActionResult PutParamTable(int id, ParamTable paramTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramTable.ID)
            {
                return BadRequest();
            }

            paramTable.TableType = null;

            db.Entry(paramTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(paramTable);
        }

        // POST: api/ParamTables
        [ResponseType(typeof(ParamTable))]
        public IHttpActionResult PostParamTable(ParamTable paramTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            paramTable.TableType = null;

            db.ParamTables.Add(paramTable);
            db.SaveChanges();

            db.Entry(paramTable).Reference(t => t.TableType).Load();

            return CreatedAtRoute("DefaultApi", new { id = paramTable.ID }, paramTable);
        }

        // DELETE: api/ParamTables/5
        [ResponseType(typeof(ParamTable))]
        public IHttpActionResult DeleteParamTable(int id)
        {
            ParamTable paramTable = db.ParamTables.Find(id);
            if (paramTable == null)
            {
                return NotFound();
            }

            db.ParamTables.Remove(paramTable);
            db.SaveChanges();

            return Ok(paramTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParamTableExists(int id)
        {
            return db.ParamTables.Count(e => e.ID == id) > 0;
        }
    }
}