using Microsoft.AspNetCore.TestHost;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Pilates.API;
using System.Net.Http;
using Pilates.API.Controllers;
using Pilates.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Pilates.Agenda.Tests
{
    

    public class CancelledClassesTester : BaseTester<CancelledClasses>// : IClassFixture<GlobalHooks<StartupTest>>
    {
        Guid cancelledClassesId;


        public CancelledClassesTester() : base()//GlobalHooks<StartupTest> fixture)
        {
            // Arrange
            controller = new CancelledClassesController(repo);
            cancelledClassesId = Guid.NewGuid();
        }

        [Fact]
        public async Task PostListCancelledClasses()
        {
            await controller.Post(new CancelledClasses()
            {
                canRecover = true,
                dateBegin = new DateTime(2017, 6, 1),
                dateFinish = new DateTime(2017, 6, 7),
                quantityOfMissedClasses = 1,
                cancelledClassesId = this.cancelledClassesId
            });

            var result = repo.GetAll().Result;
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetCancelledClasses()
        {
            repo.Clear();
            await repo.Add(new CancelledClasses()
            {
                cancelledClassesId = this.cancelledClassesId
            });

            var data = await this.controller.Get(this.cancelledClassesId);

            Assert.IsType<JsonResult>(data);
            JsonResult result = (JsonResult)data;
           
            Assert.Equal(((CancelledClasses)result.Value).cancelledClassesId, this.cancelledClassesId);

        }

        [Fact]
        public async Task PutCancelledClasses()
        {
            repo.Clear();
            await repo.Add(new CancelledClasses()
            {
                cancelledClassesId = this.cancelledClassesId
            });

            var data = await this.controller.Put(this.cancelledClassesId, new CancelledClasses()
            {
                canRecover = true,
                dateBegin = new DateTime(2017, 6, 1),
                dateFinish = new DateTime(2017, 6, 7),
                quantityOfMissedClasses = 1,
                cancelledClassesId = this.cancelledClassesId
            });

            CancelledClasses cancelledClasses = await repo.GetById(this.cancelledClassesId);

            Assert.NotNull(cancelledClasses.dateBegin);
            Assert.Equal(cancelledClasses.cancelledClassesId, this.cancelledClassesId);
            JsonResult result = (JsonResult)data;
            
        }

        [Fact]
        public async Task DeleteCancelledClasses()
        {
            repo.Clear();
            await repo.Add(new CancelledClasses()
            {
                cancelledClassesId = this.cancelledClassesId
            });

            await controller.Delete(this.cancelledClassesId);

            Assert.Empty(await repo.GetAll());
        }
    }
}
