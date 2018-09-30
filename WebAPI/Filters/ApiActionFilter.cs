using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;
using System.Linq;
using WebAPI.Models.Users;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace WebAPI.Filters
{
    public class SkipActionFilter : Attribute
    {
        public SkipActionFilter()
        {
            
        }
    }

    public class ApiActionFilter : ActionFilterAttribute
    {
        private readonly UsersContext db;

        public ApiActionFilter(UsersContext context)
        {
            this.db = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var attrib = (context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(inherit: true);
            foreach (var att in attrib)
            {
                if (att.GetType() == typeof(SkipActionFilter))
                {
                    return;
                }
            }
            
            var request = context.HttpContext.Request;
            int userId; 
            if (!int.TryParse(request.Headers["userId"], out userId))
            {
                throw new AuthorizationException("User ID required");
            }

            string sessionId = request.Headers["sessionId"];
            
            if (sessionId == null)
            {
                throw new AuthorizationException("Session ID required");
            };

            Session session;

            session = db.Sessions.Where(x => x.UserId == userId && x.SessionId == sessionId).FirstOrDefault();

            if (session == null) {
                throw new AuthorizationException("Sesión inexistente");
            }

            if (session.LogoutTime != null) {
                throw new System.NotFiniteNumberException("Sesión terminada");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context) {
            var headerName = "OnResultExecuting";
            context.HttpContext.Response.Headers.Add(
                headerName, new string[] { "ResultExecutingSuccessfully" });        }
    }
}
