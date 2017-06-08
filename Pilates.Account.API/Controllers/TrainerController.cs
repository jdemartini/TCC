using Microsoft.AspNetCore.Mvc;
using Pilates.Account.Domain.Entities;
using Pilates.Account.Domain.Interfaces;
using System.Threading.Tasks;

namespace Pilates.Account.API.Controllers
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