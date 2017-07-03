using Microsoft.AspNetCore.Builder;

namespace Pilates.APIGateway
{
    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestMiddleware(
           this IApplicationBuilder builder,
           string serviceDiscoveryUrl)
        {
            return builder.UseMiddleware<RequestMiddleware>(serviceDiscoveryUrl);
        }
    }
}
