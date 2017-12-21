using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Repositories;
using TermWorkDatabases.Models.DataAccess.Repositories.Companies;
using TermWorkDatabases.Models.DataAccess.Repositories.Customers;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Interfaces.Companies;

namespace TermWorkDatabases.Models.Services.Companies
{
    class CompanyInfoService : ICompanyInfoService
    {
        Company _company;
        ICompaniesInfoRepository _companyInfoRepository;
        protected ICompaniesInfoRepository CompanyInfoRepository
        {
            get
            {
                return _companyInfoRepository ?? (_companyInfoRepository = new CompanyInfoRepository());
            }
        }

        public CompanyInfoService(Company company)
        {
            _company = company;
        }

        public bool ChangeCompanyInfo(string login, string name, string mobilePhone)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(name))
                CompanyInfoRepository.ChangeCompanyName(_company, name);
            if (!string.IsNullOrWhiteSpace(mobilePhone))
                CompanyInfoRepository.ChangeCompanyMobileNumber(_company, mobilePhone);
            if (!string.IsNullOrWhiteSpace(login))
                result = CompanyInfoRepository.ChangeCompanyLogin(_company, login);
            CompanyInfoRepository.SaveChages();
            return result;
        }

        public bool ChangeCompanyPassword(string oldPassword, string newPassword)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                result = CompanyInfoRepository.ChangeCompanyPassword(_company, oldPassword, newPassword);
                CompanyInfoRepository.SaveChages();
                return true;
            }
            return result;
        }

        public (string Name, string MobileNumber, int DuringOrders, int CompletedOrders) GetCompanyInfo()
        {
            return (_company.Name, _company.MobileNumber,
                CompanyInfoRepository.GetDuringOrdersCount(_company),
                CompanyInfoRepository.GetFinishedOrdersCount(_company));                    
        }
    }
}
