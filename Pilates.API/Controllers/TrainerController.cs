using Microsoft.AspNetCore.Mvc;
using Pilates.Domain.Entities;
using Pilates.Domain.Interfaces;
using System.Threading.Tasks;

namespace Pilates.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Trainer")]
    public class TrainerController : BaseController<Trainer>
    {
        public TrainerController(IRepositoryBase<Trainer> repo): base(repo)
        {
            
        }

    }
}