using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ProductClientHubException productClientHubException)
            {
                context.HttpContext.Response.StatusCode = (int) productClientHubException.GetHttpStatusCode();
                context.Result = new ObjectResult(new ErrorResponse(productClientHubException.GetErrors()));
                return;
            }
            
            ThrowUnknowError(context);
        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ErrorResponse("Erro desconhecido"));
        }
    }
}
