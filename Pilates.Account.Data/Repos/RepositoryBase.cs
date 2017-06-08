using Pilates.Account.Domain.Entities;
using Pilates.Account.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilates.Account.Data.Repos
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        public RepositoryBase()
        {
        }

        public virtual async Task<TEntity> Add(TEntity model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> Update(Guid id, TEntity model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task Upsert(IEnumerable<TEntity> itemList)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Delete(Guid modelId)
        {
            throw new NotImplementedException();
        }
        
    }
}
