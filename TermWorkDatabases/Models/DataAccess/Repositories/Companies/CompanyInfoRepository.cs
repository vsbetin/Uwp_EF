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
    public class CompanyInfoRepository : CompanyRepository, ICompaniesInfoRepository
    {
        public void ChangeCompanyMobileNumber(Company company, string mobileNumber)
        {
            company.MobileNumber = mobileNumber;
        }

        public void ChangeCompanyName(Company company, string name)
        {
            company.Name = name;
        }

        public bool ChangeCompanyPassword(Company company, string oldPassword, string newPassword)
        {
            CompanyAccessData companyAccessData = Context.CompanyAccessDatas.
                Include(compData => compData.Company).
                FirstOrDefault(compData => object.ReferenceEquals(compData.Company, company));
            if (companyAccessData.Password.Equals(oldPassword))
            {
                companyAccessData.Password = newPassword;
                return true;
            }
            return false;
        }

        public bool ChangeCompanyLogin(Company company, string login)
        {
            if (Context.CompanyAccessDatas.FirstOrDefault(compData => compData.Login.Equals(login)) == null)
            {
                Context.CompanyAccessDatas.
                    Include(compData => compData.Company).
                    FirstOrDefault(compData => object.ReferenceEquals(compData.Company, company)).Login = login;
                return true;
            }
            return false;
        }

        public int GetDuringOrdersCount(Company company)
        {
            Context.Orders.Load();
            return Context.Companies.
                    Include(comp => comp.Products).
                    FirstOrDefault(comp => object.ReferenceEquals(comp, company)).
                    Products.Sum(compProd => compProd.Orders.Where(order => order.IsStarted && !order.IsFinished).Count());
        }

        public int GetFinishedOrdersCount(Company company)
        {
            Context.Orders.Load();
            return Context.Companies.
                    Include(comp => comp.Products).
                    FirstOrDefault(comp => object.ReferenceEquals(comp, company)).
                    Products.Sum(compProd => compProd.Orders.Where(order => order.IsFinished).Count());
        }
    }
}
