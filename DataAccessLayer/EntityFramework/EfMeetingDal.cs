using DataAccessLayer.Absract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfMeetingDal : GenericRepository<Meeting>, IMeetingDal
    {
        public EfMeetingDal(BaseProjectContext projectContext) : base(projectContext)
        {
        }
    }
}
