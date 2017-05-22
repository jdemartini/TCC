using Microsoft.AspNetCore.Mvc;
using Pilates.Domain.Entities;
using Pilates.Domain.Interfaces;

namespace Pilates.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Practicer")]
    public class PracticerController : BaseController<Practicer>
    {
        public PracticerController(IRepositoryBase<Practicer> repo) : base(repo)
        {

        }
    }
}