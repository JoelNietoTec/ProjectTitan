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
    public class FinancialProductsController : ApiController
    {
        private FinancialModel db = new FinancialModel();

        // GET: api/FinancialProducts
        public IQueryable<FinancialProduct> GetFinancialProducts()
        {
            return db.FinancialProducts;
        }

        // GET: api/FinancialProducts/5
        [ResponseType(typeof(FinancialProduct))]
        public IHttpActionResult GetFinancialProduct(int id)
        {
            FinancialProduct financialProduct = db.FinancialProducts.Find(id);
            if (financialProduct == null)
            {
                return NotFound();
            }

            return Ok(financialProduct);
        }

        // PUT: api/FinancialProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinancialProduct(int id, FinancialProduct financialProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != financialProduct.ID)
            {
                return BadRequest();
            }

            financialProduct.ProductType = null;

            db.Entry(financialProduct).State = EntityState.Modified;

            
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            db.Entry(financialProduct).Reference(t => t.ProductType).Load();
            return Ok(financialProduct);
        }

        // POST: api/FinancialProducts
        [ResponseType(typeof(FinancialProduct))]
        public IHttpActionResult PostFinancialProduct(FinancialProduct financialProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            financialProduct.ProductType = null;

            db.FinancialProducts.Add(financialProduct);
            db.SaveChanges();
            db.Entry(financialProduct).Reference(t => t.ProductType).Load();

            return CreatedAtRoute("DefaultApi", new { id = financialProduct.ID }, financialProduct);
        }

        // DELETE: api/FinancialProducts/5
        [ResponseType(typeof(FinancialProduct))]
        public IHttpActionResult DeleteFinancialProduct(int id)
        {
            FinancialProduct financialProduct = db.FinancialProducts.Find(id);
            if (financialProduct == null)
            {
                return NotFound();
            }

            db.FinancialProducts.Remove(financialProduct);
            db.SaveChanges();

            return Ok(financialProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinancialProductExists(int id)
        {
            return db.FinancialProducts.Count(e => e.ID == id) > 0;
        }
    }
}