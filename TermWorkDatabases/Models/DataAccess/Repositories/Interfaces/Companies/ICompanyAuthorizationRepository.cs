using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    interface ICompanyAuthorizationRepository : ISaveChanges
    {
        Company GetCompany(string login);
        bool CheckPassword(Company company, string password);
        bool AddCompany(Company company, CompanyAccessData companyAccessData);
    }
}
