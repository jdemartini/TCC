using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RequestRouteTo
    {
        public string[] gatewayEndpointPath;
        public string[] gatewayParams;
        public string gatewayMethod;
        public string APIOwner;
        public string APIServiceEndPoint;
        public string APIServiceMethod;

        internal bool isTheRoute(string[] gatewayPath, string method)
        {
            if (gatewayPath.Length != gatewayEndpointPath.Length + gatewayParams.Length)
                return false;

            for(int i = 0; i < gatewayEndpointPath.Length; i++)
            {
                if (gatewayEndpointPath[i] != gatewayPath[i])
                    return false;
            }

            return true;
        }
    }
}
