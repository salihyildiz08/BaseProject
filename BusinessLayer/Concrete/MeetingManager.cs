using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MeetingManager : GenericManager<Meeting>, IMeetingService
    {
        public MeetingManager(IGenericDal<Meeting> dal) : base(dal)
        {
        }
    }
}
