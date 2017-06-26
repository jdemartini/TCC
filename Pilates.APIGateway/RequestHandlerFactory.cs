using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RequestHandlerFactory
    {
        private RequestRouteRepository routeRepo;

        public RequestHandlerFactory()
        {
            this.routeRepo = new RequestRouteRepository();
        }

        public RequestHandler getRequestHandler(HttpRequest request)
        {
            var route = this.routeRepo.getAPIRoute(request.Path, request.Method);
            if (route == null)
                return null;
            var result = new RequestHandler(route, request);
            return result;
        }
    }
}
