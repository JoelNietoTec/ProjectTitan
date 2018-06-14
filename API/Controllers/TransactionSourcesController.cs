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
    public class TransactionSourcesController : ApiController
    {
        private FinancialModel db = new FinancialModel();

        // GET: api/TransactionSources
        public IQueryable<TransactionSource> GetTransactionSources()
        {
            return db.TransactionSources;
        }

        // GET: api/TransactionSources/5
        [ResponseType(typeof(TransactionSource))]
        public IHttpActionResult GetTransactionSource(int id)
        {
            TransactionSource transactionSource = db.TransactionSources.Find(id);
            if (transactionSource == null)
            {
                return NotFound();
            }

            return Ok(transactionSource);
        }

        // PUT: api/TransactionSources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransactionSource(int id, TransactionSource transactionSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactionSource.ID)
            {
                return BadRequest();
            }

            db.Entry(transactionSource).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionSourceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(transactionSource);
        }

        // POST: api/TransactionSources
        [ResponseType(typeof(TransactionSource))]
        public IHttpActionResult PostTransactionSource(TransactionSource transactionSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TransactionSources.Add(transactionSource);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = transactionSource.ID }, transactionSource);
        }

        // DELETE: api/TransactionSources/5
        [ResponseType(typeof(TransactionSource))]
        public IHttpActionResult DeleteTransactionSource(int id)
        {
            TransactionSource transactionSource = db.TransactionSources.Find(id);
            if (transactionSource == null)
            {
                return NotFound();
            }

            db.TransactionSources.Remove(transactionSource);
            db.SaveChanges();

            return Ok(transactionSource);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionSourceExists(int id)
        {
            return db.TransactionSources.Count(e => e.ID == id) > 0;
        }
    }
}