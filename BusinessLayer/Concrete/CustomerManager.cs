using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using DtoLayer.CustomerDto;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task<List<BalanceDto>> GetBalanceByRepresentativeAsync(string representativeCode)
        {
            return await _customerDal.GetBalanceByRepresentativeAsync(representativeCode);
        }
    }
}
