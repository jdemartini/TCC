using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pilates.Account.Domain.Interfaces;
using Pilates.Account.Domain.Entities;
using System.Net;

namespace Pilates.Account.API.Controllers
{
    abstract public class BaseController<TEntity> : Controller
        where TEntity : class, IEntity
    {
        private readonly IRepositoryBase<TEntity> repo;

        public BaseController(IRepositoryBase<TEntity> repo)
        {
            this.repo = repo;
        }

        // GET: TModel
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Json(await repo.GetAll());
        }

        // GET: TModel/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var data = await repo.GetById(id);
            if (data != null)
            {
                return Json(data);
            }

            return NotFound();
        }

        // POST: TModel
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEntity item)
        {
            if (ModelState.IsValid)
            {
                var data = await repo.Add(item);
                return Json(data);
            }
            return BadRequest(ModelState);
        }

        // PUT: TModel/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TEntity item)
        {
            var data = await repo.Update(id, item);
            return Json(item);
        }

        // DELETE: TModel/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await repo.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}