using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database.Repositories
{
    public interface IRepository<TModel, TKey> 
        where TKey : struct
        where TModel : BaseModel<TKey>
    {
        void Add(TModel entity);
        List<TModel> GetAll();
        TModel Get(TKey id);
        void Remove(TKey id);
        void Remove(TModel entity);
    }
}
