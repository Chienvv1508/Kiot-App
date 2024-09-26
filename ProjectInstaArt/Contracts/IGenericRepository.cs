using System.Linq.Expressions;

namespace ProjectInstaArt
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        void Add(T entity); 
        void Update(T entity); 
        void Remove(T entity);
        
        T GetLast(Expression<Func<T, bool>> expression);    
    }
}
