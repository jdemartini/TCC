using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RequestRouteRepository
    {
        private RouteDefinition[] reRoutes;

        public RequestRouteRepository()
        {
            this.reRoutes = new RouteDefinition[] {
                new RouteDefinition()
                {
                    APIOwner= "AgendaAPI",
                    APITargetEndPoint= "http://localhost:54250/api/PracticerClasses",
                    APITargetHTTPMethod = "Get",
                    gatewayEndpointPath = new string[] { "api", "practicerClasses" },
                    gatewayMethod = "Get"
                    
                }
            };
        }

        public RouteDefinition getAPIRoute(string gatewayPath, string method)
        {
            var r = from route in this.reRoutes
                    where route.routeMatch(gatewayPath, method)
                    select route;

            return r.FirstOrDefault();
        }
    }
}
