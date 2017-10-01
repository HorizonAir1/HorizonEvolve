using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Database.Repositories
{
    public class Repository<TModel, TKey> : IRepository<TModel, TKey>
        where TKey : struct
        where TModel : BaseModel<TKey>
    {
        DataSource context;

        public Repository(DataSource context)
        {
            this.context = context;
        }

        public void Add(TModel entity)
        {
            context.Set<TModel>().Add(entity);
        }

        public TModel Get(TKey id)
        {
            TModel entity = context.Set<TModel>().Find(id);

            return entity;
        }

        public List<TModel> GetAll()
        {
            List<TModel> entities = context.Set<TModel>().ToList();

            return entities;
        }

        public void Remove(TKey id)
        {
            TModel entity = Get(id);
            context.Set<TModel>().Remove(entity);
        }

        public void Remove(TModel entity)
        {
            context.Set<TModel>().Remove(entity);
        }
    }
}
