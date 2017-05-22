using Microsoft.AspNetCore.Mvc;
using Pilates.Data.Repos;
using Pilates.Domain.Entities;
using Pilates.Domain.Interfaces;

namespace Pilates.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Schedule")]
    public class ScheduleController : BaseController<Schedule>
    {
        public ScheduleController(IRepositoryBase<Schedule> repo) : base(new RepositoryBase<Schedule>())
        {

        }
    }
}