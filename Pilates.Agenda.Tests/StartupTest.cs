using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Pilates.API;
using Pilates.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Agenda.Tests
{
    public class StartupTest : Startup
    {
        public StartupTest(IHostingEnvironment env) : base(env)
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            //services.AddScoped(typeof(IRepositoryBase<IEntity>), typeof(RepositoryBase<IEntity>));
            //services.AddTransient(typeof(IRepositoryBase<IEntity>), typeof(RepositoryBase<IEntity>));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(InMemoryRepository<>));

        }
    }
}
