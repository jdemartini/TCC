using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Pilates.Domain.Interfaces;
using System;
using System.IO;
using System.Net.Http;

namespace Pilates.Agenda.Tests
{
    public sealed class GlobalHooks<TStartup> : IDisposable where TStartup : class
    {
        private readonly TestServer _server;

        public GlobalHooks()
        {
            var builder = new WebHostBuilder().UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<TStartup>()
                .UseApplicationInsights();
            

            _server = new TestServer(builder);


            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:5000");

        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
