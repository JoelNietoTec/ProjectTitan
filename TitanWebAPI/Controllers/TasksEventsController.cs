using System.Linq;
using System.Web.Http;
using TitanWebAPI.Models.Tasks;
using System;
using System.Web.Http.Cors;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class TasksEventsController : ApiController
    {
        private TasksModel db = new TasksModel();

        // GET: api/TasksEvents
        public IQueryable<TasksEvent> GetTasksEvents()
        {
            return db.TasksEvents.Where(x => x.start != null);
        }

        [HttpGet]
        [Route("api/tasks/calendar")]
        public IHttpActionResult GetTaskByRange(Range range)
        {
            if(range == null)
            {
                return NotFound();
            }
            return Ok(db.TasksEvents.Where(x => x.start >= range.StartDate && x.start <= range.EndDate));
        }

        public partial class Range
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

    }
}