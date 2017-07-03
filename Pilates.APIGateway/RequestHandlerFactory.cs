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
        private ServiceDiscovery serviceDiscovery;

        public RequestHandlerFactory(ServiceDiscovery serviceDiscovery)
        {
            this.routeRepo = new RequestRouteRepository();
            this.serviceDiscovery = serviceDiscovery;
        }

        public RequestHandler getRequestHandler(HttpRequest request)
        {
            var route = this.routeRepo.getAPIRoute(request.Path, request.Method);
            if (route == null)
                return null;
            var result = new RequestHandler(route, serviceDiscovery.getServiceUrl(route.APIOwner), request);
            return result;
        }
    }
}
