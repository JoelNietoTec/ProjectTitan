using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Tasks;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net", headers: "*", methods: "*")]
    public class TaskStatusController : ApiController
    {
        private TasksModel db = new TasksModel();

        // GET: api/TaskStatus
        public IQueryable<TaskStatu> GetTaskStatus()
        {
            return db.TaskStatus;
        }

        // GET: api/TaskStatus/5
        [ResponseType(typeof(TaskStatu))]
        public IHttpActionResult GetTaskStatu(int id)
        {
            TaskStatu taskStatu = db.TaskStatus.Find(id);
            if (taskStatu == null)
            {
                return NotFound();
            }

            return Ok(taskStatu);
        }

        // PUT: api/TaskStatus/5
        [ResponseType(typeof(TaskStatu))]
        public IHttpActionResult PutTaskStatu(int id, TaskStatu taskStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskStatu.ID)
            {
                return BadRequest();
            }

            db.Entry(taskStatu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskStatuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = taskStatu.ID }, taskStatu);
        }

        // POST: api/TaskStatus
        [ResponseType(typeof(TaskStatu))]
        public IHttpActionResult PostTaskStatu(TaskStatu taskStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskStatus.Add(taskStatu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taskStatu.ID }, taskStatu);
        }

        // DELETE: api/TaskStatus/5
        [ResponseType(typeof(TaskStatu))]
        public IHttpActionResult DeleteTaskStatu(int id)
        {
            TaskStatu taskStatu = db.TaskStatus.Find(id);
            if (taskStatu == null)
            {
                return NotFound();
            }

            db.TaskStatus.Remove(taskStatu);
            db.SaveChanges();

            return Ok(taskStatu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskStatuExists(int id)
        {
            return db.TaskStatus.Count(e => e.ID == id) > 0;
        }
    }
}