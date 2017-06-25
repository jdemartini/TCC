using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private RequestHandlerFactory reqFactory;
        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
            this.reqFactory = new RequestHandlerFactory();
        }

        public Task Invoke(HttpContext context)
        {
            var reqHandler = reqFactory.getRequestHandler(
                context.Request.Path,
                context.Request.Method,
                null,
                context.Request.Body);
             context.Request.Path
            // Call the next delegate/middleware in the pipeline
            return context.Response.WriteAsync(reqHandler.execute());
        }
        
    }
    
}
