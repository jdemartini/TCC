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
        private RequestRouteTo requestTo;
        private HttpClient httpRequest;
        private object requestData;
        private string[] requestParams;
        public RequestHandler(RequestRouteTo requestTo, string[] requestParams = null, object requestData = null)
        {
            this.requestTo = requestTo;
            this.httpRequest.BaseAddress = new Uri(requestTo.APIServiceEndPoint);
            this.requestData = requestData;
            this.requestParams = requestParams ?? new string[] { };
        }

        public Task<HttpResponseMessage> execute()
        {
            switch (this.requestTo.APIServiceMethod)
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
            using (this.httpRequest = new HttpClient())
            {
                StringBuilder urlPath = new StringBuilder(this.requestTo.APIServiceEndPoint);
                for (var i = 0; i < this.requestTo.gatewayParams.Length; i++)
                {
                    urlPath.AppendFormat("/{0}", this.requestParams[i]);
                }
                return this.httpRequest.DeleteAsync(urlPath.ToString());
            }
                    
        }

        private Task<HttpResponseMessage> executePut(object requestData)
        {
            throw new NotImplementedException();
        }

        private Task<HttpResponseMessage> executePost(object requestData)
        {
            throw new NotImplementedException();
        }

        private Task<HttpResponseMessage> executeGet()
        {
            throw new NotImplementedException();
        }
    }
}
