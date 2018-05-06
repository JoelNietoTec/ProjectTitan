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
    public class ProfileAccountsController : ApiController
    {
        private FinancialModel db = new FinancialModel();

        // GET: api/ProfileAccounts
        public IQueryable<ProfileAccount> GetProfileAccounts()
        {
            return db.ProfileAccounts;
        }

        // GET: api/ProfileAccounts/5
        [ResponseType(typeof(ProfileAccount))]
        public IHttpActionResult GetProfileAccount(int id)
        {
            ProfileAccount profileAccount = db.ProfileAccounts.Find(id);
            if (profileAccount == null)
            {
                return NotFound();
            }

            return Ok(profileAccount);
        }

        // PUT: api/ProfileAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfileAccount(int id, ProfileAccount profileAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profileAccount.ID)
            {
                return BadRequest();
            }

            db.Entry(profileAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            db.Entry(profileAccount).Reference(p => p.AccountType).Load();
            db.Entry(profileAccount).Reference(p => p.Bank).Load();
            return Ok(profileAccount);
        }

        // POST: api/ProfileAccounts
        [ResponseType(typeof(ProfileAccount))]
        public IHttpActionResult PostProfileAccount(ProfileAccount profileAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProfileAccounts.Add(profileAccount);
            db.SaveChanges();

            db.Entry(profileAccount).Reference(p => p.AccountType).Load();
            db.Entry(profileAccount).Reference(p => p.Bank).Load();

            return CreatedAtRoute("DefaultApi", new { id = profileAccount.ID }, profileAccount);
        }

        // DELETE: api/ProfileAccounts/5
        [ResponseType(typeof(ProfileAccount))]
        public IHttpActionResult DeleteProfileAccount(int id)
        {
            ProfileAccount profileAccount = db.ProfileAccounts.Find(id);
            if (profileAccount == null)
            {
                return NotFound();
            }

            db.ProfileAccounts.Remove(profileAccount);
            db.SaveChanges();

            return Ok(profileAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileAccountExists(int id)
        {
            return db.ProfileAccounts.Count(e => e.ID == id) > 0;
        }
    }
}