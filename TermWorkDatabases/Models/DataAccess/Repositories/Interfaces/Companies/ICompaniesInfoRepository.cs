
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    public interface ICompaniesInfoRepository : ICompanyRepository
    {        
        bool ChangeCompanyLogin(Company company, string login);
        void ChangeCompanyName(Company company, string name);
        void ChangeCompanyMobileNumber(Company company, string mobileNumber);
        bool ChangeCompanyPassword(Company company, string oldPassword, string newPassword);
        int GetDuringOrdersCount(Company company);
        int GetFinishedOrdersCount(Company company);
    }
}
