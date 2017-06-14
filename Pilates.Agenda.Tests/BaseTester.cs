using Pilates.API.Controllers;
using Pilates.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Agenda.Tests
{
    public abstract class BaseTester <TEntity> where TEntity : class, IEntity
    {
        protected InMemoryRepository<TEntity> repo;
        protected BaseController<TEntity> controller;
        
        public BaseTester()
        {
            repo = new InMemoryRepository<TEntity>();
            
        }
    }
}
