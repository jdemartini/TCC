using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RequestRouteRepository
    {
        private RequestRouteTo[] reRoutes;

        public RequestRouteRepository()
        {
            this.reRoutes = new RequestRouteTo[] { };
        }

        public RequestRouteTo getAPIRoute(string gatewayPath, string method)
        {
            RequestRouteTo result = null;

            var r = from route in this.reRoutes
                    where route.isTheRoute(gatewayPath.Trim().Trim('/').Split('/'), method)
                    select route;

            return result;
        }
    }
}
