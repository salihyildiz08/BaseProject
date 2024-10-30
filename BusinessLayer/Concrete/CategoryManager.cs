using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        public CategoryManager(IGenericDal<Category> dal) : base(dal)
        {
        }
    }
}
