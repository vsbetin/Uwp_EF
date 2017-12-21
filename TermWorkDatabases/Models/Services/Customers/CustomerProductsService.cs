using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Repositories;
using TermWorkDatabases.Models.DataAccess.Repositories.Companies;
using TermWorkDatabases.Models.DataAccess.Repositories.Products;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Interfaces.Customers;
using Microsoft.EntityFrameworkCore;

namespace TermWorkDatabases.Models.Services.Customers
{
    class CustomerProductsService : ICustomerProductsService
    {
        IProductsInfoRepository _productsInfoRepository;
        protected IProductsInfoRepository ProductsInfoRepository
        {
            get
            {
                return _productsInfoRepository ?? (_productsInfoRepository = new ProductsInfoRepository());
            }
        }

        ICompanyRepository _companyRepository;
        protected ICompanyRepository CompanyRepository
        {
            get
            {
                return _companyRepository ?? (_companyRepository = new CompanyRepository());
            }
        }

        public List<string> GetCompaniesName()
        {
            return CompanyRepository.GetCompanies().Select(comp => comp.Name).ToList();
        }

        public List<(int Id, string ProductName, string CompanyName, int Cost)> GetProducts()
        {
            return ProductsInfoRepository.GetProducts().
                Select<CompanyProduct, (int Id, string productName, string companyName, int cost)>
                (compProd => (compProd.Id ,compProd.Product.Name, compProd.Company.Name, compProd.Cost)).
                ToList();
        }

        public List<(int Id, string ProductName, string CompanyName, int Cost)> GetProductsByCompany(string companyName)
        {
            return ProductsInfoRepository.GetCompanyProducts(CompanyRepository.GetComapny(companyName)).
                Select<CompanyProduct, (int Id, string ProductName, string CompanyName, int Cost)>
                (compProd => (compProd.Id, compProd.Product.Name, compProd.Company.Name, compProd.Cost)).
                ToList();
        }

        public List<(int Id, string ProductName, string CompanyName, int Cost)> GetProductsByName(string productName)
        {
            return ProductsInfoRepository.GetProductsByName(productName).
                Select<CompanyProduct, (int Id, string ProductName, string CompanyName, int Cost)>
                (compProd => (compProd.Id, compProd.Product.Name, compProd.Company.Name, compProd.Cost)).
                ToList();
        }
    }
}
