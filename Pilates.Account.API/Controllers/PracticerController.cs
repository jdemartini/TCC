using Microsoft.AspNetCore.Mvc;
using Pilates.Account.Domain.Entities;
using Pilates.Account.Domain.Interfaces;

namespace Pilates.Account.API.Controllers
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