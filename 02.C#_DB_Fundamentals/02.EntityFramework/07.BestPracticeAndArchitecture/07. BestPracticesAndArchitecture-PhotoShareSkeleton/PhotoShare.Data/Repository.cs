using PhotoShare.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using EntityFramework.Extensions;

namespace PhotoShare.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> set;
        public Repository(DbSet<TEntity> set)
        {
            this.set = set;
        }
        public void Add(TEntity entity)
        {
            this.set.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.set.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            this.set.Delete(entities.AsQueryable());
        }

        public TEntity FirstOrDefault()
        {
            return this.set.FirstOrDefault();
        }

        public TEntity FirstOrDefaultWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.set;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.Where(predicate);
        }
    }
}
