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
    

    public class PracticerClassTester : BaseTester<PracticerClasses>// : IClassFixture<GlobalHooks<StartupTest>>
    {
        Guid practicerClassesId;


        public PracticerClassTester() : base()//GlobalHooks<StartupTest> fixture)
        {
            // Arrange
            controller = new PracticerClassesController(repo);
            practicerClassesId = Guid.NewGuid();
        }

        [Fact]
        public async Task PostListPracticerClasses()
        {
            await controller.Post(new PracticerClasses()
            {
                id = Guid.NewGuid(),
                classes = new System.Collections.Generic.List<Class>()
                {
                    new Class()
                    {
                        id = Guid.NewGuid(),
                        dayBegin = new System.DateTime(2017, 1, 1),
                        dayEnd = new System.DateTime(2018, 12, 31),
                        dayOfWeek = System.DayOfWeek.Monday,
                        timeOfDay = 7,
                        trainerId = Guid.NewGuid()
                    }
                },
                practicerId = Guid.NewGuid()
            });

            var result = repo.GetAll().Result;
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetPracticerClasses()
        {
            repo.Clear();
            await repo.Add(new PracticerClasses()
            {
                id = this.practicerClassesId
            });

            var data = await this.controller.Get(this.practicerClassesId);

            Assert.IsType<JsonResult>(data);
            JsonResult result = (JsonResult)data;
           
            Assert.Equal(((PracticerClasses)result.Value).id, this.practicerClassesId);

        }

        [Fact]
        public async Task PutPracticerClasses()
        {
            repo.Clear();
            await repo.Add(new PracticerClasses()
            {
                id = this.practicerClassesId
            });

            var data = await this.controller.Put(this.practicerClassesId, new PracticerClasses()
            {
                id = this.practicerClassesId,
                classes = new System.Collections.Generic.List<Class>()
                {
                    new Class()
                    {
                        id = Guid.NewGuid(),
                        dayBegin = new System.DateTime(2017, 1, 1),
                        dayEnd = new System.DateTime(2018, 12, 31),
                        dayOfWeek = System.DayOfWeek.Monday,
                        
                        timeOfDay = 7,
                        trainerId = Guid.NewGuid()
                    }
                },
                practicerId = Guid.NewGuid()
            });

            PracticerClasses practicerClasses = await repo.GetById(this.practicerClassesId);

            Assert.NotEmpty(practicerClasses.classes);
            Assert.NotNull(practicerClasses.practicerId);
            Assert.Equal(practicerClasses.id, this.practicerClassesId);
            JsonResult result = (JsonResult)data;
            
        }

        [Fact]
        public async Task DeletePracticerClasses()
        {
            repo.Clear();
            await repo.Add(new PracticerClasses()
            {
                id = this.practicerClassesId
            });

            await controller.Delete(this.practicerClassesId);

            Assert.Empty(await repo.GetAll());
        }
    }
}
