using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RouteDefinition
    {
        public string[] gatewayEndpointPath;
        public string[] gatewayParams;
        public string gatewayMethod;
        public string APIOwner;
        public string APITargetEndPoint;
        public string APITargetEndPointParams;
        public string APITargetHTTPMethod;
        
        public RouteDefinition()
        {
            this.gatewayEndpointPath = new string[] { };
            this.gatewayParams = new string[] { };
            this.APITargetEndPointParams = string.Empty;
        }

        internal bool routeMatch(string gatewayRequestPath, string method)
        {
            var path = gatewayRequestPath.Trim().Trim('/').Split('/');
            if (path.Length != gatewayEndpointPath.Length + gatewayParams.Length)
                return false;

            for(int i = 0; i < gatewayEndpointPath.Length; i++)
            {
                if (gatewayEndpointPath[i].Equals(path[i], StringComparison.CurrentCultureIgnoreCase) == false)
                    return false;
            }

            return true;
        }
    }
}
