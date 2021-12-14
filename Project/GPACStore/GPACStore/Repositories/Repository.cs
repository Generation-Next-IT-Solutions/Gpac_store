using GPACStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPACStore.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DataContext context;

        public Repository()
        {
            context = new DataContext();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<TEntity>().Remove(this.Get(id));
            context.SaveChanges();
        }
    }
}
