using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
