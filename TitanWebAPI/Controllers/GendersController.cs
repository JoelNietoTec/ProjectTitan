using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Individuals;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers:"*", methods:"*")]
    public class GendersController : ApiController
    {
        private IndividualsModel db = new IndividualsModel();

        // GET: api/Genders
        public IQueryable<Gender> GetGenders()
        {
            return db.Genders;
        }

        // GET: api/Genders/5
        [ResponseType(typeof(Gender))]
        public IHttpActionResult GetGender(int id)
        {
            Gender gender = db.Genders.Find(id);
            if (gender == null)
            {
                return NotFound();
            }

            return Ok(gender);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenderExists(int id)
        {
            return db.Genders.Count(e => e.ID == id) > 0;
        }
    }
}