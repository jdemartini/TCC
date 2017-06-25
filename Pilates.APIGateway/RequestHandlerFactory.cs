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

        public RequestHandler getRequestHandler(string path, string method, string[] gatewayParams = null, object data = null)
        {
            RequestRouteTo route = this.routeRepo.getAPIRoute(path, method);
            var result = new RequestHandler(route, gatewayParams, data);
            return result;
        }
    }
}
