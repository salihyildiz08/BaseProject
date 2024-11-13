using DtoLayer.CustomerDto;

namespace DataAccessLayer.Absract
{
    public interface ICustomerDal
    {
        Task<List<BalanceDto>> GetBalanceByRepresentativeAsync(string representativeCode);
    }
}
