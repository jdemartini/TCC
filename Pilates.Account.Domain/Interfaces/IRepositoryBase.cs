﻿using Pilates.Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pilates.Account.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : IEntity
    {
        Task<TEntity> Add(TEntity model);
        Task<bool> Delete(Guid modelId);
        Task<TEntity> Update(Guid id, TEntity model);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
    }
}
