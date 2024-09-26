using Microsoft.EntityFrameworkCore;
using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly InstaArtVer3Context _dbContext;
        private readonly DbSet<T> _entitySet;

        public GenericRepository(InstaArtVer3Context dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {

            _dbContext.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _entitySet.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _entitySet.AsEnumerable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _entitySet.Where(expression).AsEnumerable();
        }

        public T GetLast(Expression<Func<T, bool>> expression)
        {
            var x = _entitySet.Where(expression).ToList();
            if(x != null)
            {
                if (x.Count == 0) return x[0];
                return x[x.Count - 1];
            }
            return null;
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
