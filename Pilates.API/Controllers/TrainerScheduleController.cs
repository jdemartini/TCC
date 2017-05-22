using Microsoft.AspNetCore.Mvc;
using Pilates.Domain.Entities;
using Pilates.Domain.Interfaces;

namespace Pilates.API.Controllers
{
    [Produces("application/json")]
    [Route("api/TrainerSchedule")]
    public class TrainerScheduleController : BaseController<TrainerSchedule>
    {
        public TrainerScheduleController(IRepositoryBase<TrainerSchedule> repo) : base(repo)
        {

        }
    }
}