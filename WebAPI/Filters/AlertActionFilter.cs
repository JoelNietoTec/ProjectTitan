using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
    public class AlertActionFilter : ActionFilterAttribute
    {
        private const string V = "GetSanctions";

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (actionDescriptor.ActionName == V)
            {

            }
        }
    }
}