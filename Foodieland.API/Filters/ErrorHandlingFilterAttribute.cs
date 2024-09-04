using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Foodieland.API.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        context.Result = new ObjectResult(new { error = "An error occurred while processing your request" })
        {
            StatusCode = 500
        };
        context.ExceptionHandled = true;
    }
}