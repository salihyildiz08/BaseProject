using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
       private readonly IGenericDal<T> _dal;
        public GenericManager(IGenericDal<T> dal)
        {
            _dal = dal;
        }

        public void Add(T entity)
        {
            _dal.Add(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dal.AnyAsync(expression);
        }

        public void Delete(T entity)
        {
            _dal.Delete(entity);
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await _dal.GetByIdAsync(expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _dal.GetWhere(expression);
        }

        public void Update(T entity)
        {
            _dal.Update(entity);
        }
    }
}
