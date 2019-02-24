using System.Collections.Generic;
using Stock.Models;

namespace Stock.Repositories
{
    public interface ICompanyDetailRepository
    {
        bool Add(CompanyDetailVm companyDetail);
        bool Edit(CompanyDetailVm companyDetail);
        bool Delete(string securityId);
        CompanyDetailVm Get(string securityId);
        List<CompanyDetailVm> Get();
    }
}