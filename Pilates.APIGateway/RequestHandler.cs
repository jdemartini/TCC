using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RequestHandler
    {
        private RouteDefinition requestTo;
        private string urlPath;
        private object requestData;
        private string[] requestParams;
        internal RequestHandler(RouteDefinition requestTo, HttpRequest originalRequest)
        {
            this.requestTo = requestTo;
            this.urlPath = requestTo.APITargetEndPoint.Trim().Trim('/') + this.getParams(originalRequest.Path);
            this.requestData = originalRequest.Body;
            this.requestParams = requestParams ?? new string[] { };
        }

        private string getParams(PathString path)
        {
            string result = string.Empty;
            if (this.requestTo.APITargetEndPointParams.Length > 0)
            {
                var urlParams = path.Value.Trim().Trim('/').Split('/');
                int paramsCount = this.requestTo.gatewayEndpointPath.Length - this.requestTo.APITargetEndPointParams.Length;
                for (int i = paramsCount; i < this.requestTo.gatewayEndpointPath.Length; i++)
                {
                    result = $"{result}/{this.requestTo.gatewayEndpointPath[i]}";
                }
            }

            return result;
        }

        public Task<HttpResponseMessage> execute()
        {
            
            switch (this.requestTo.APITargetHTTPMethod)
            {
                case "Get":
                    return this.executeGet();
                case "Post":
                    return this.executePost(this.requestData);
                case "Put":
                    return this.executePut(this.requestData);
                case "Delete":
                    return this.executeDelete(this.requestData);

            }
            return null;
        }

        private Task<HttpResponseMessage> executeDelete(object requestData)
        {
            using (HttpClient httpRequest = new HttpClient())
            {
                httpRequest.BaseAddress = new Uri(this.urlPath);
                return httpRequest.DeleteAsync(urlPath.ToString());
            }

        }
        
        private Task<HttpResponseMessage> executePut(object requestData)
        {
            using (HttpClient httpRequest = new HttpClient())
            {

                httpRequest.BaseAddress = new Uri(this.urlPath);
                HttpContent content = new StringContent(requestData.ToString());
                return httpRequest.PutAsync(urlPath.ToString(), content);
            }
        }

        private Task<HttpResponseMessage> executePost(object requestData)
        {
            using (var httpRequest = new HttpClient())
            {
                httpRequest.BaseAddress = new Uri(this.urlPath);
                HttpContent content = new StringContent(requestData.ToString());
                return httpRequest.PostAsync(urlPath.ToString(), content);
            }
        }

        private Task<HttpResponseMessage> executeGet()
        {
            using (var httpRequest = new HttpClient())
            {
                httpRequest.BaseAddress = new Uri(this.urlPath);
                return httpRequest.GetAsync(urlPath.ToString());
            }
        }
    }
}
