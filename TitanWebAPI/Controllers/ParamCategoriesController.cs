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
    public class ParamCategoriesController : ApiController
    {
        private ParamsModel db = new ParamsModel();

        // GET: api/ParamCategories
        public IQueryable<ParamCategory> GetParamCategories()
        {
            return db.ParamCategories;
        }

        [HttpGet]
        [Route("api/parammatrices/{id}/categories")]
        public IQueryable<ParamCategory> GetParamCategoriesByMatrix(int id)
        {
            return db.ParamCategories.Where(x => x.ParamMatrixID == id);
        }

        // GET: api/ParamCategories/5
        [ResponseType(typeof(ParamCategory))]
        public IHttpActionResult GetParamCategory(int id)
        {
            ParamCategory paramCategory = db.ParamCategories.Find(id);
            if (paramCategory == null)
            {
                return NotFound();
            }

            return Ok(paramCategory);
        }

        // PUT: api/ParamCategories/5
        [ResponseType(typeof(ParamCategory))]
        public IHttpActionResult PutParamCategory(int id, ParamCategory paramCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paramCategory.ID)
            {
                return BadRequest();
            }

            db.Entry(paramCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(paramCategory);
        }

        // POST: api/ParamCategories
        [ResponseType(typeof(ParamCategory))]
        public IHttpActionResult PostParamCategory(ParamCategory paramCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParamCategories.Add(paramCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paramCategory.ID }, paramCategory);
        }

        // DELETE: api/ParamCategories/5
        [ResponseType(typeof(ParamCategory))]
        public IHttpActionResult DeleteParamCategory(int id)
        {
            ParamCategory paramCategory = db.ParamCategories.Find(id);
            if (paramCategory == null)
            {
                return NotFound();
            }

            db.ParamCategories.Remove(paramCategory);
            db.SaveChanges();

            return Ok(paramCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParamCategoryExists(int id)
        {
            return db.ParamCategories.Count(e => e.ID == id) > 0;
        }
    }
}