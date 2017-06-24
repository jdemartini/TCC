using MongoDB.Driver;
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
        MongoClient client;
        IMongoDatabase db;
        IMongoCollection<TEntity> collection;

        public RepositoryBase()
        {
            var typeName = typeof(TEntity).Name;
            var collectionName = typeName.Substring(0,
                typeName.Length - "Model".Length);
            this.client = new MongoClient();
            this.db = this.client.GetDatabase("pilatesAccount");
            this.collection = db.GetCollection<TEntity>(collectionName);
        }

        public virtual async Task<TEntity> Add(TEntity model)
        {
            model.id = Guid.NewGuid();
            await collection.InsertOneAsync(model);
            return model;
        }

        public virtual async Task<TEntity> Update(Guid id, TEntity model)
        {
            var res = await collection.ReplaceOneAsync((e => e.id == id), model);

            return model;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var data = collection.Find(
                p => true).ToListAsync();

            return await data;
        }

        public virtual Task<TEntity> GetById(Guid id)
        {
            var data = collection.Find(
                p => p.id == id).FirstOrDefaultAsync();

            return data;
        }

        public virtual Task Upsert(IEnumerable<TEntity> itemList)
        {
            var options = new UpdateOptions { IsUpsert = true };
            var results = from item in itemList
                          select collection.ReplaceOneAsync(model => model.id == item.id, item, options);
            return Task.WhenAll(results);
        }

        public virtual async Task<bool> Delete(Guid modelId)
        {
            var result = await collection.DeleteOneAsync(
                p => p.id == modelId);

            return result.DeletedCount > 0;
        }

    }
}
