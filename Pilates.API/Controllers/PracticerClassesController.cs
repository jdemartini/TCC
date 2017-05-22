using Microsoft.AspNetCore.Mvc;
using Pilates.Domain.Entities;
using Pilates.Domain.Interfaces;

namespace Pilates.API.Controllers
{
    [Produces("application/json")]
    [Route("api/PracticerClasses")]
    public class PracticerClassesController : BaseController<PracticerClasses>
    {
        public PracticerClassesController(IRepositoryBase<PracticerClasses> repo) : base(repo)
        {

        }
    }
}