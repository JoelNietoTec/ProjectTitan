using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Financial;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]

    public class ProfileProductsController : ApiController
    {
        private FinancialModel db = new FinancialModel();

        // GET: api/ProfileProducts
        public IQueryable<ProfileProduct> GetProfileProducts()
        {
            return db.ProfileProducts;
        }

        [HttpGet]
        [Route("api/participantprofiles/{id}/products")]
        public IQueryable<ProfileProduct> GetProductsByProducts(int id)
        {
            return db.ProfileProducts.Where(x => x.ParticipantProfileID == id);
        }

        // GET: api/ProfileProducts/5
        [ResponseType(typeof(ProfileProduct))]
        public IHttpActionResult GetProfileProduct(int id)
        {
            ProfileProduct profileProduct = db.ProfileProducts.Find(id);
            if (profileProduct == null)
            {
                return NotFound();
            }

            return Ok(profileProduct);
        }

        // PUT: api/ProfileProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfileProduct(int id, ProfileProduct profileProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profileProduct.ID)
            {
                return BadRequest();
            }

            profileProduct.FinancialProduct = null;

            db.Entry(profileProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            db.Entry(profileProduct).Reference(t => t.FinancialProduct).Load();

            return Ok(profileProduct);
        }

        // POST: api/ProfileProducts
        [ResponseType(typeof(ProfileProduct))]
        public IHttpActionResult PostProfileProduct(ProfileProduct profileProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            profileProduct.FinancialProduct = null;

            db.ProfileProducts.Add(profileProduct);
            db.SaveChanges();

            db.Entry(profileProduct).Reference(t => t.FinancialProduct).Load();

            return CreatedAtRoute("DefaultApi", new { id = profileProduct.ID }, profileProduct);
        }

        // DELETE: api/ProfileProducts/5
        [ResponseType(typeof(ProfileProduct))]
        public IHttpActionResult DeleteProfileProduct(int id)
        {
            ProfileProduct profileProduct = db.ProfileProducts.Find(id);
            if (profileProduct == null)
            {
                return NotFound();
            }

            db.ProfileProducts.Remove(profileProduct);
            db.SaveChanges();

            return Ok(profileProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileProductExists(int id)
        {
            return db.ProfileProducts.Count(e => e.ID == id) > 0;
        }
    }
}