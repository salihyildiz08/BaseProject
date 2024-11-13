using DataAccessLayer.Absract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfDepartmentDal : GenericRepository<Department>, IDepartmentDal
    {
        public EfDepartmentDal(BaseProjectContext projectContext) : base(projectContext)
        {
        }
    }
}