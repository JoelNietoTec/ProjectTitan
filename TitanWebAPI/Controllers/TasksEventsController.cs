using System.Linq;
using System.Web.Http;
using TitanWebAPI.Models.Tasks;
using System.Web.Http.Cors;

namespace TitanWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net", headers: "*", methods: "*")]
    public class TasksEventsController : ApiController
    {
        private TasksModel db = new TasksModel();

        // GET: api/TasksEvents
        public IQueryable<TasksEvent> GetTasksEvents()
        {
            return db.TasksEvents;
        }

    }
}