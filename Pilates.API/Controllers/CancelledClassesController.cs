using Microsoft.AspNetCore.Mvc;
using Pilates.Domain.Entities;
using Pilates.Domain.Interfaces;

namespace Pilates.API.Controllers
{
    [Produces("application/json")]
    [Route("api/CancelledClasses")]
    public class CancelledClassesController : BaseController<CancelledClasses>
    {
        public CancelledClassesController(IRepositoryBase<CancelledClasses> repo) : base(repo)
        {

        }
    }
}