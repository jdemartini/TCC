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
            this.reRoutes = new RequestRouteTo[] {
                new RequestRouteTo()
                {
                    APIOwner= "AgendaAPI",
                    APIServiceEndPoint= "http://localhost:54250/api/PracticerClasses",
                    APIServiceMethod = "Get",
                    gatewayEndpointPath = new string[] { "practicerClasses" },
                    gatewayMethod = "Get"
                    
                }
            };
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
