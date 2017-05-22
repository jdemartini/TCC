using Microsoft.AspNetCore.Mvc;
using Pilates.Domain.Entities;
using Pilates.Domain.Interfaces;

namespace Pilates.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Class")]
    public class ClassController : BaseController<Class>
    {
        public ClassController(IRepositoryBase<Class> repo) : base(repo)
        {

        }
    }
}