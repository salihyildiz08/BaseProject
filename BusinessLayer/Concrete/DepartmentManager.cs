using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DepartmentManager : GenericManager<Department>, IDepartmentService
    {
        public DepartmentManager(IGenericDal<Department> dal) : base(dal)
        {
        }
    }
}