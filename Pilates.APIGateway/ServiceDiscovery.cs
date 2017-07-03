using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class ServiceDiscovery
    {
        private ConsulClient consulClient;
        private Dictionary<string, AgentService> serversUrls;
        public ServiceDiscovery(string consulUrl)
        {
            consulClient = new ConsulClient(c =>
            {
                var uri = new Uri(consulUrl);
                c.Address = uri;
            });

            this.serversUrls = new Dictionary<string, AgentService>();

            this.reloadServiceUrls();
        }

        private Dictionary<string, AgentService> reloadServiceUrls()
        {
            this.serversUrls = consulClient.Agent.Services().Result.Response;
            return serversUrls;
        }

        public string getServiceUrl(string apiServiceId)
        {
            if (this.serversUrls.ContainsKey(apiServiceId) == false)
                this.reloadServiceUrls();

            if (this.serversUrls.ContainsKey(apiServiceId) == false)
                throw new KeyNotFoundException();

            return $"{this.serversUrls[apiServiceId].Address}:{this.serversUrls[apiServiceId].Port}";

        }
    }
}
