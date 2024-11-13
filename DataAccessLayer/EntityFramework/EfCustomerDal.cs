using Dapper;
using DataAccessLayer.Absract;
using DataAccessLayer.Concrete;
using DtoLayer.CustomerDto;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        private readonly BaseProjectContext _context;

        public EfCustomerDal(BaseProjectContext context)
        {
            _context = context;
        }

        public async Task<List<BalanceDto>> GetBalanceByRepresentativeAsync(string representativeCode)
        {
            return await _context.GetBalanceByRepresentativeAsync(representativeCode);
        }


    }
}

