using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var cultureQuery = context.Request.Query["culture"];

            // Call the next delegate/middleware in the pipeline
            return context.Response.WriteAsync("Chegou aqui: " + cultureQuery);
        }
        
    }
    
}
