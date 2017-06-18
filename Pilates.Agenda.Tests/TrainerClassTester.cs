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
    

    public class TrainerScheduleTester : BaseTester<TrainerSchedule>// : IClassFixture<GlobalHooks<StartupTest>>
    {
        Guid trainerScheduleId;


        public TrainerScheduleTester() : base()//GlobalHooks<StartupTest> fixture)
        {
            // Arrange
            controller = new TrainerScheduleController(repo);
            trainerScheduleId = Guid.NewGuid();
        }

        [Fact]
        public async Task PostListTrainerSchedule()
        {
            await controller.Post(new TrainerSchedule()
            {
                daysOfWeek = DayOfWeek.Monday,
                maxNumberOfTrainers = 3,
                timeMinutesBegin = 0,
                timesOfDay = new uint[] { 7, 8, 9, 10, 11, 12 },
                trainerId = Guid.NewGuid(),
                trainerScheduleId = this.trainerScheduleId
            });

            var result = repo.GetAll().Result;
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetTrainerSchedule()
        {
            repo.Clear();
            await repo.Add(new TrainerSchedule()
            {
                trainerScheduleId = this.trainerScheduleId
            });

            var data = await this.controller.Get(this.trainerScheduleId);

            Assert.IsType<JsonResult>(data);
            JsonResult result = (JsonResult)data;
           
            Assert.Equal(((TrainerSchedule)result.Value).trainerScheduleId, this.trainerScheduleId);

        }

        [Fact]
        public async Task PutTrainerSchedule()
        {
            repo.Clear();
            await repo.Add(new TrainerSchedule()
            {
                trainerScheduleId = this.trainerScheduleId
            });

            var data = await this.controller.Put(this.trainerScheduleId, new TrainerSchedule()
            {
                daysOfWeek = DayOfWeek.Monday,
                maxNumberOfTrainers = 3,
                timeMinutesBegin = 0,
                timesOfDay = 7 & 8 & 9 & 10 & 11 & 12,
                trainerId = Guid.NewGuid(),
                trainerScheduleId = this.trainerScheduleId
            });

            TrainerSchedule trainerSchedule = await repo.GetById(this.trainerScheduleId);

            Assert.NotNull(trainerSchedule.trainerId);
            Assert.Equal(trainerSchedule.trainerScheduleId, this.trainerScheduleId);
            JsonResult result = (JsonResult)data;
            
        }

        [Fact]
        public async Task DeleteTrainerSchedule()
        {
            repo.Clear();
            await repo.Add(new TrainerSchedule()
            {
                trainerScheduleId = this.trainerScheduleId
            });

            await controller.Delete(this.trainerScheduleId);

            Assert.Empty(await repo.GetAll());
        }
    }
}
