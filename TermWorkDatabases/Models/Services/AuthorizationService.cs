using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Context;
using TermWorkDatabases.Models.DataAccess.Repositories;
using TermWorkDatabases.Models.DataAccess.Repositories.Companies;
using TermWorkDatabases.Models.DataAccess.Repositories.Customers;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Interfaces;

namespace TermWorkDatabases.Models.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        ICompanyAuthorizationRepository _companyRepository;
        ICompanyAuthorizationRepository CompanyRepository
        {
            get
            {
                return _companyRepository ?? (_companyRepository = new CompanyAuthorizationRepository());
            }
        }

        ICustomerAuthorizationRepository _customerRepository;
        ICustomerAuthorizationRepository CustomerRepository
        {
            get
            {
                return _customerRepository ?? (_customerRepository = new CustomerAuthorizationRepository());
            }
        }

        public Company SignInCompany(string login, string password)
        {
            Company company = CompanyRepository.GetCompany(login);
            if (company != null && CompanyRepository.CheckPassword(company, password))
                return company;
            else
                return null;
        }

        public Customer SignInCustomer(string login, string password)
        {
            Customer customer = CustomerRepository.GetCustomer(login);
            if (customer != null && CustomerRepository.CheckPassword(customer, password))
                return customer;
            else
                return null;
        }

        public Company SignUpCompany(string name, string login, string mobilePhone, string email, string paswword)
        {
            Company company = new Company { Name = name, MobileNumber = mobilePhone, Email = email };
            CompanyAccessData compData = new CompanyAccessData { Login = login, Password = paswword, Company = company };

            if (CompanyRepository.AddCompany(company, compData))
            {
                CompanyRepository.SaveChages();
                return company;
            }
            else
                return null;
        }

        public Customer SignUpCustomer(string name, string login, string mobilePhone, string email, string paswword)
        {
            Customer customer = new Customer { Name = name, MobileNumber = mobilePhone, Email = email };
            CustomerAccessData custData = new CustomerAccessData { Login = login, Password = paswword, Customer = customer };

            if (CustomerRepository.AddCustomer(customer, custData))
            {
                CustomerRepository.SaveChages();
                return customer;
            }
            else
                return null;               
        }
    }
}
