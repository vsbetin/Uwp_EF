using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Context;
using TermWorkDatabases.Models.Enteties;
using Microsoft.EntityFrameworkCore;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Companies
{
    class CompanyAuthorizationRepository :RepositoryBase, ICompanyAuthorizationRepository
    {       
        public bool AddCompany(Company company, CompanyAccessData companyAccessData)
        {
            if (Context.CompanyAccessDatas.FirstOrDefault(compData => compData.Login.Equals(companyAccessData.Login)) == null)
            {
                Context.Companies.Add(company);
                Context.CompanyAccessDatas.Add(companyAccessData);
                return true;
            }
            else
                return false;
        }

        public bool CheckPassword(Company company, string password)
        {
            var companyData = Context.CompanyAccessDatas.
                Include(compData => compData.Company).
                FirstOrDefault(compData => object.ReferenceEquals(compData.Company, company));
            if (companyData == null)
                return false;
            else
                return companyData.Password.Equals(password);
        }

        public Company GetCompany(string login)
        {            
            var companyData = Context.CompanyAccessDatas.
                Include(compData => compData.Company).
                Include(compData => compData.Company.Products).
                FirstOrDefault(compData => compData.Login.Equals(login));
            if (companyData == null)
                return null;
            else
                return companyData.Company;
        }

        public void SaveChages()
        {
            Context.SaveChanges();
        }
    }
}
