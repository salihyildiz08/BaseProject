using DataAccessLayer.Absract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly BaseProjectContext _projectContext;

        public GenericRepository(BaseProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public void Add(T entity)
        {
            _projectContext.Add(entity);
            _projectContext.SaveChanges();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _projectContext.Set<T>().AnyAsync(expression);
        }

        public void Delete(T entity)
        {
            _projectContext.Remove(entity);
            _projectContext.SaveChanges();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await _projectContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _projectContext.Set<T>().AsNoTracking().Where(expression).AsQueryable();
        }

        public void Update(T entity)
        {
            _projectContext.Update(entity);
            _projectContext.SaveChanges();
        }
    }
}
