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

            return;
            var attrib = (context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(inherit: true);
            foreach (var att in attrib)
            {
                if (att.GetType() == typeof(SkipActionFilter))
                {
                    return;
                }
            }
            
            var request = context.HttpContext.Request;
            string userName = request.Headers["userName"];
            userName = userName.ToLower();
            string pass = request.Headers["password"];
            User user;

            user = db.Users.Where(x => x.Email.ToLower() == userName || x.UserName.ToLower() == userName && (x.Password == pass)).FirstOrDefault();
            if (user == null)
            {
                throw new System.NotImplementedException();
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context) {
            //throw new System.NotImplementedException();
        }
    }
}
