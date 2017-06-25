using System;
using System.Threading.Tasks;
using Pilates.Domain.Interfaces;
using Pilates.Domain.Entities;
using System.Collections.Generic;

namespace Pilates.Agenda.Tests
{
    public class InMemoryRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        private readonly Dictionary<Guid, TEntity> Data = new Dictionary<Guid, TEntity>();
        
        public Task<TEntity> Add(TEntity model)
        {
            if (!model.id.HasValue)
            {
                model.id = Guid.NewGuid();
            }
            // TODO: this is __NOT__ thread safe!
            Data[model.id.Value] = model;
            return Task.FromResult(model);
        }

        public Task<bool> Delete(Guid modelId)
        {
            Data.Remove(modelId);
            return Task.FromResult(true);
        }

        public Task<System.Collections.Generic.IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> values = Data.Values;
            return Task.FromResult(values);
        }

        public Task<TEntity> GetById(Guid id)
        {
            return Task.FromResult(Data.ContainsKey(id) ? Data[id] : null);
        }

        public Task<TEntity> Update(Guid id, TEntity model)
        {
            Data[id] = model;
            return Task.FromResult(model);
        }

        public void Clear()
        {
            this.Data.Clear();
            
        }
    }
}