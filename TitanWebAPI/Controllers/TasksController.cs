using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Tasks;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net", headers: "*", methods: "*")]
    public class TasksController : ApiController
    {
        private TasksModel db = new TasksModel();

        // GET: api/Tasks
        public IQueryable<Task> GetTasks()
        {
            return db.Tasks;
        }

        [HttpGet]
        [Route("api/tasks/category/{id}")]
        public IQueryable<Task> GetTasksByCategory(int id)
        {
            return db.Tasks.Where(x => x.CategoryID == id);
        }

        [HttpGet]
        [Route("api/tasks/byparticipant")]
        public IQueryable<Participant> GetTasksByParticipant()
        {
            var participants = db.Tasks.Where(x => x.StatusID != 3 && x.CategoryID == 2).Select(i => i.ParticipantID).ToList();
            return db.Participants.Where(x => participants.Contains(x.ID));
        }

        [HttpGet]
        [Route("api/tasks/category/{id}/count")]
        public IQueryable<TasksByCategory> GetTasksCount(int id)
        {
            return db.TaskByCategories.Where(x => x.CategoryID == id);
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.ID)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(task);
        }

        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            task.CreatedDate = DateTime.Now;
            db.Tasks.Add(task);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = task.ID }, task);
        }

        [HttpPost]
        [Route("api/tasks/{id}/progress")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult ProgressTask(int id)
        {
            Task task = db.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            task.StatusID = task.StatusID + 1;

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = task.ID }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(task);
            db.SaveChanges();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.ID == id) > 0;
        }
    }
}