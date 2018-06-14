using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Users;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private UsersModel db = new UsersModel();

        // GET: api/Users
        public IQueryable<UsersInfo> GetUsers()
        {
            return db.UsersInfo;
        }

        // GET: api/Users/5
        [ResponseType(typeof(UsersInfo))]
        public IHttpActionResult GetUser(int id)
        {
            UsersInfo user = db.UsersInfo.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost]
        [Route("api/users/login/")]
        [ResponseType(typeof(UsersInfo))]
        public IHttpActionResult Login (Login log)
        {
            log.UserName = log.UserName.ToLower();

            User user;
            UsersInfo loggedUser;

            user = db.Users.Where(x => x.Email.ToLower() == log.UserName || x.UserName.ToLower() == log.UserName && (x.Password == log.Password)).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            loggedUser = db.UsersInfo.Find(user.ID);


            return Ok(loggedUser);

        }

        public IHttpActionResult ChangePassword(int id, User user)
        {
            return Ok();
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, UsersInfo user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _user = db.Users.Find(user.ID);

            _user.UserProfileID = user.UserProfileID;

            if (id != user.ID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
    }
}