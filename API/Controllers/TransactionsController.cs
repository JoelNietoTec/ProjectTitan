using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Financial;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class TransactionsController : ApiController
    {
        private FinancialModel db = new FinancialModel();

        // GET: api/Transactions
        public IQueryable<Transaction> GetTransactions()
        {
            return db.Transactions;
        }

        [HttpGet]
        [Route("api/participantprofiles/{id}/transactions")]
        public IQueryable<Transaction> GetTransactionsByProfiles(int id)
        {
            return db.Transactions.Where(x => x.ParticipantProfileID == id);
        }

        // GET: api/Transactions/5
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult GetTransaction(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // PUT: api/Transactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransaction(int id, Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.ID)
            {
                return BadRequest();
            }

            transaction.Account = null;
            transaction.TransactionSource = null;
            transaction.TransactionType = null;
            transaction.ProfileProduct = null;

            db.Entry(transaction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            db.Entry(transaction).Reference(t => t.ProfileProduct).Load();
            db.Entry(transaction).Reference(t => t.TransactionType).Load();
            db.Entry(transaction).Reference(t => t.Account).Load();
            db.Entry(transaction).Reference(t => t.TransactionSource).Load();
            return Ok(transaction);
        }

        // POST: api/Transactions
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult PostTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            transaction.Account = null;
            transaction.TransactionSource = null;
            transaction.TransactionType = null;
            transaction.ProfileProduct = null;

            db.Transactions.Add(transaction);
            db.SaveChanges();

            db.Entry(transaction).Reference(t => t.ProfileProduct).Load();
            db.Entry(transaction).Reference(t => t.TransactionSource).Load();
            db.Entry(transaction).Reference(t => t.TransactionType).Load();
            db.Entry(transaction).Reference(t => t.Account).Load();

            return CreatedAtRoute("DefaultApi", new { id = transaction.ID }, transaction);
        }

        // DELETE: api/Transactions/5
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult DeleteTransaction(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }

            db.Transactions.Remove(transaction);
            db.SaveChanges();

            return Ok(transaction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionExists(int id)
        {
            return db.Transactions.Count(e => e.ID == id) > 0;
        }
    }
}