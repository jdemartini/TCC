using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private RequestHandlerFactory reqFactory;
        private ServiceDiscovery serviceDiscovery;
        public RequestMiddleware(RequestDelegate next, string serviceDiscoveryUrl)
        {
            _next = next;
            this.serviceDiscovery = new ServiceDiscovery(serviceDiscoveryUrl);
            this.reqFactory = new RequestHandlerFactory(this.serviceDiscovery);
           
        }

        public async Task Invoke(HttpContext context)
        {
            var reqHandler = reqFactory.getRequestHandler(context.Request);
            if (reqHandler == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync("Invalid path");
            }
            else
            {
                // Call the next delegate/middleware in the pipeline
                var result = await reqHandler.executeAsync();

                await result.Content.CopyToAsync(context.Response.Body);
            }
            //return context.Response.WriteAsync();
        }


        public Task Invoke2(HttpContext context)
        {
            string jsonBody = string.Empty;
            using (var stream = new MemoryStream())
            {
                byte[] buffer = new byte[2048];
                int bytesRead;
                while ((bytesRead = context.Request.Body.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
                byte[] body = stream.ToArray();
                jsonBody = System.Text.Encoding.UTF8.GetString(body);
            }
            var reqHandler = reqFactory.getRequestHandler(context.Request);
            if (reqHandler == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return context.Response.WriteAsync("Invalid path");
            }
            // Call the next delegate/middleware in the pipeline
            var result = reqHandler.execute(jsonBody);
            var content = string.Empty;
            if (result.IsSuccessStatusCode)
            {
                content = result.Content.ReadAsStringAsync().Result;
            }
            else
            {
                if (result.StatusCode != HttpStatusCode.OK)
                    context.Response.StatusCode = (int)HttpStatusCode.BadGateway;
            }

            return context.Response.WriteAsync(content);
        }
        
    }
    
}
