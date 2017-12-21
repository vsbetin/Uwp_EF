using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    interface ICompanyRepository : ISaveChanges
    {
        List<Company> GetCompanies();
        Company GetComapny(string name);
        Company GetComapny(int id);
    }
}
