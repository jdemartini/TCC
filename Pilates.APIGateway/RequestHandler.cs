using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pilates.APIGateway
{
    public class RequestHandler
    {
        private RouteDefinition requestTo;
        private string urlPath;
        private StreamContent requestData;
        private string[] requestParams;
        internal RequestHandler(RouteDefinition requestTo, string serviceUrl, HttpRequest originalRequest)
        {
            this.requestTo = requestTo;
            this.urlPath = $"{serviceUrl}/{requestTo.APITargetEndPoint.Trim().Trim('/')}{this.getParams(originalRequest.Path)}";
            this.requestData = new StreamContent(originalRequest.Body);
            foreach (var header in originalRequest.Headers)
            {
                if (!requestData.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray()) && requestData != null)
                {
                    requestData.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
                }
            }
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

        public Task<HttpResponseMessage> executeAsync()
        {
            switch (this.requestTo.APITargetHTTPMethod)
            {
                case "Get":
                    return this.executeGetAsync();
                case "Post":
                    return this.executePostAsync();
                case "Put":
                    return this.executePutAsync();
                case "Delete":
                    return this.executeDeleteAsync();

            }
            return null;
        }

        private async Task<HttpResponseMessage> executeDeleteAsync()
        {
            using (HttpClient httpRequest = new HttpClient())
            {
                httpRequest.BaseAddress = new Uri(this.urlPath);
                httpRequest.DefaultRequestHeaders.Accept.Clear();
                httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = httpRequest.DeleteAsync(urlPath.ToString());
                return await result;
            }

        }

        private async Task<HttpResponseMessage> executePutAsync()
        {
            using (HttpClient httpRequest = new HttpClient())
            {

                httpRequest.BaseAddress = new Uri(this.urlPath);
                httpRequest.DefaultRequestHeaders.Accept.Clear();
                httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = requestData;
                return await httpRequest.PutAsync(urlPath.ToString(), content);
            }
        }

        private async Task<HttpResponseMessage> executePostAsync()
        {
            using (var httpRequest = new HttpClient())
            {
                httpRequest.BaseAddress = new Uri(this.urlPath);
                httpRequest.DefaultRequestHeaders.Accept.Clear();
                httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = requestData;
                
                return await httpRequest.PostAsync(urlPath.ToString(), content);
            }
        }

        private async Task<HttpResponseMessage> executeGetAsync()
        {
            using (var httpRequest = new HttpClient())
            {
                httpRequest.BaseAddress = new Uri(this.urlPath);
                httpRequest.DefaultRequestHeaders.Accept.Clear();
                httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await httpRequest.GetAsync(urlPath.ToString());

            }
        }


        public HttpResponseMessage execute(string body)
        {

            switch (this.requestTo.APITargetHTTPMethod)
            {
                case "Get":
                    return this.executeGet();
                case "Post":
                    return this.executePost(body);
                case "Put":
                    return this.executePut(body);
                case "Delete":
                    return this.executeDelete(body);

            }
            return null;
        }
        
        private HttpResponseMessage executeDelete(string requestData)
        {
            using (HttpClient httpRequest = new HttpClient())
            {
                httpRequest.BaseAddress = new Uri(this.urlPath);
                httpRequest.DefaultRequestHeaders.Accept.Clear();
                httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = httpRequest.DeleteAsync(urlPath.ToString());
                return result.Result;
            }

        }

        private HttpResponseMessage executePut(string requestData)
        {
            using (HttpClient httpRequest = new HttpClient())
            {

                httpRequest.BaseAddress = new Uri(this.urlPath);
                httpRequest.DefaultRequestHeaders.Accept.Clear();
                httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent(requestData.ToString());
                return httpRequest.PutAsync(urlPath.ToString(), content).Result;
            }
        }

        private HttpResponseMessage executePost(string requestData)
        {
            using (var httpRequest = new HttpClient())
            {
                httpRequest.BaseAddress = new Uri(this.urlPath);
                httpRequest.DefaultRequestHeaders.Accept.Clear();
                httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent(requestData.ToString(), Encoding.UTF8, "application/json");
                return httpRequest.PostAsync(urlPath.ToString(), content).Result;
            }
        }

        private HttpResponseMessage executeGet()
        {
            using (var httpRequest = new HttpClient())
            {
                httpRequest.BaseAddress = new Uri(this.urlPath);
                httpRequest.DefaultRequestHeaders.Accept.Clear();
                httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return httpRequest.GetAsync(urlPath.ToString()).Result;

            }
        }
    }
}
