using Consul;
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
                #region Agenda
                new RouteDefinition()
                {
                    APIOwner= "pilates-agenda-api-v1",
                    APITargetEndPoint= "/api/PracticerClasses",
                    APITargetHTTPMethod = "Get",
                    gatewayEndpointPath = new string[] { "api", "practicerClasses" },
                    gatewayMethod = "Get"
                    
                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-agenda-api-v1",
                    APITargetEndPoint= "/api/PracticerClasses",
                    APITargetHTTPMethod = "Delete",
                    gatewayEndpointPath = new string[] { "api", "practicerClasses" },
                    gatewayMethod = "Delete"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-agenda-api-v1",
                    APITargetEndPoint= "/api/PracticerClasses",
                    APITargetHTTPMethod = "Put",
                    gatewayEndpointPath = new string[] { "api", "practicerClasses" },
                    gatewayMethod = "Put"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-agenda-api-v1",
                    APITargetEndPoint= "/api/PracticerClasses",
                    APITargetHTTPMethod = "Post",
                    gatewayEndpointPath = new string[] { "api", "practicerClasses" },
                    gatewayMethod = "Post"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-agenda-api-v1",
                    APITargetEndPoint= "/api/TrainerSchedule",
                    APITargetHTTPMethod = "Get",
                    gatewayEndpointPath = new string[] { "api", "trainerSchedule" },
                    gatewayMethod = "Get"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-agenda-api-v1",
                    APITargetEndPoint= "/api/TrainerSchedule",
                    APITargetHTTPMethod = "Delete",
                    gatewayEndpointPath = new string[] { "api", "trainerSchedule" },
                    gatewayMethod = "Delete"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-agenda-api-v1",
                    APITargetEndPoint= "/api/TrainerSchedule",
                    APITargetHTTPMethod = "Put",
                    gatewayEndpointPath = new string[] { "api", "trainerSchedule" },
                    gatewayMethod = "Put"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-agenda-api-v1",
                    APITargetEndPoint= "/api/TrainerSchedule",
                    APITargetHTTPMethod = "Post",
                    gatewayEndpointPath = new string[] { "api", "trainerSchedule" },
                    gatewayMethod = "Post"

                },
                #endregion
                #region Account
                new RouteDefinition()
                {
                    APIOwner= "pilates-account-api-v1",
                    APITargetEndPoint= "/api/Practicer",
                    APITargetHTTPMethod = "Delete",
                    gatewayEndpointPath = new string[] { "api", "practicer" },
                    gatewayMethod = "Delete"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-account-api-v1",
                    APITargetEndPoint= "/api/Practicer",
                    APITargetHTTPMethod = "Get",
                    gatewayEndpointPath = new string[] { "api", "practicer" },
                    gatewayMethod = "Get"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-account-api-v1",
                    APITargetEndPoint= "/api/Practicer",
                    APITargetHTTPMethod = "Put",
                    gatewayEndpointPath = new string[] { "api", "practicer" },
                    gatewayMethod = "Put"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-account-api-v1",
                    APITargetEndPoint= "/api/Practicer",
                    APITargetHTTPMethod = "Post",
                    gatewayEndpointPath = new string[] { "api", "practicer" },
                    gatewayMethod = "Post"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-account-api-v1",
                    APITargetEndPoint= "/api/Trainer",
                    APITargetHTTPMethod = "Delete",
                    gatewayEndpointPath = new string[] { "api", "trainer" },
                    gatewayMethod = "Delete"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-account-api-v1",
                    APITargetEndPoint= "/api/Trainer",
                    APITargetHTTPMethod = "Get",
                    gatewayEndpointPath = new string[] { "api", "trainer" },
                    gatewayMethod = "Get"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-account-api-v1",
                    APITargetEndPoint= "/api/Trainer",
                    APITargetHTTPMethod = "Put",
                    gatewayEndpointPath = new string[] { "api", "trainer" },
                    gatewayMethod = "Put"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-account-api-v1",
                    APITargetEndPoint= "/api/Trainer",
                    APITargetHTTPMethod = "Post",
                    gatewayEndpointPath = new string[] { "api", "trainer" },
                    gatewayMethod = "Post"

                },
                #endregion
                #region Messages
                new RouteDefinition()
                {
                    APIOwner= "pilates-message-api-v1",
                    APITargetEndPoint= "/api/message",
                    APITargetHTTPMethod = "Get",
                    gatewayEndpointPath = new string[] { "api", "message" },
                    gatewayMethod = "Get"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-message-api-v1",
                    APITargetEndPoint= "/api/message",
                    APITargetHTTPMethod = "Put",
                    gatewayEndpointPath = new string[] { "api", "message" },
                    gatewayMethod = "Put"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-message-api-v1",
                    APITargetEndPoint= "/api/message",
                    APITargetHTTPMethod = "Post",
                    gatewayEndpointPath = new string[] { "api", "message" },
                    gatewayMethod = "Post"

                },
                new RouteDefinition()
                {
                    APIOwner= "pilates-message-api-v1",
                    APITargetEndPoint= "/api/message",
                    APITargetHTTPMethod = "Delete",
                    gatewayEndpointPath = new string[] { "api", "message" },
                    gatewayMethod = "Delete"

                }
#endregion
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
