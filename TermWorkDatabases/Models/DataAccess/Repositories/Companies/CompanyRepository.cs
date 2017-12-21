using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Companies
{
    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        public Company GetComapny(string name)
        {
            return Context.Companies.FirstOrDefault(comp => comp.Name.Equals(name));
        }

        public Company GetComapny(int id)
        {
            return Context.Companies.FirstOrDefault(comp => comp.Id.Equals(id));
        }

        public List<Company> GetCompanies()
        {
            return Context.Companies.ToList();
        }

        public void SaveChages()
        {
            Context.SaveChanges();
        }
    }
}
