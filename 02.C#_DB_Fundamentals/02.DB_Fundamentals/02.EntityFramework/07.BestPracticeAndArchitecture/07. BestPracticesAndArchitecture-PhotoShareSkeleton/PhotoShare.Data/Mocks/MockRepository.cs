using PhotoShare.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace PhotoShare.Data.Mocks
{
    public class MockRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private List<TEntity> enteties;

        public MockRepository()
        {
            this.enteties = new List<TEntity>();
        }
        public void Add(TEntity entity)
        {
            this.enteties.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.enteties.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            this.enteties.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entety in enteties)
            {
                this.Delete(entety);
            }
        }

        public TEntity FirstOrDefault()
        {
            return this.enteties.FirstOrDefault();
        }

        public TEntity FirstOrDefaultWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return this.enteties.FirstOrDefault(predicate.Compile());
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.enteties;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.enteties.Where(predicate.Compile());
        }
    }
}
