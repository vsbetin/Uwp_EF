using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Repositories.Products;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Customers;
using TermWorkDatabases.Models.Services.Interfaces.Companies;

namespace TermWorkDatabases.Models.Services.Companies
{
    public class CompanyProductsService : CustomerProductsService, ICompanyProductsService
    {
        Company _company;

        public CompanyProductsService(Company company)
        {
            _company = company;
        }

        IProductCompanyRepository _productCompanyRepository;
        IProductCompanyRepository ProductCompanyRepository
        {
            get
            {
                return _productCompanyRepository ?? (_productCompanyRepository = new ProductCompanyRepository());
            }
        }

        public void AddProduct(string productName, int cost)
        {
            ProductCompanyRepository.AddProduct(productName, cost, _company);
            ProductCompanyRepository.SaveChages();
        }

        public void ChangeProduct(int companyProductId, string newName, int? cost)
        {
            CompanyProduct companyProduct = ProductCompanyRepository.GetProductById(companyProductId);
            if (!string.IsNullOrWhiteSpace(newName))
                ProductCompanyRepository.ChangeProductName(companyProduct, newName);
            if (cost != null && cost > 0)
                ProductCompanyRepository.ChangeProductCost(companyProduct, (int)cost);
            ProductCompanyRepository.SaveChages();
        }

        public void DeleteProduct(int companyProductId)
        {
            ProductCompanyRepository.DeleteProduct(ProductCompanyRepository.GetProductById(companyProductId));
            ProductCompanyRepository.SaveChages();
        }

        public CompanyProduct GetCompanyProductByProductId(int companyProductId)
        {
            return ProductsInfoRepository.GetProductById(companyProductId);
        }
    }
}
