using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPACStore.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
