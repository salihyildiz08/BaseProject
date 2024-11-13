using DtoLayer.CustomerDto;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService
    {
        Task<List<BalanceDto>> GetBalanceByRepresentativeAsync(string representativeCode);
    }
}
