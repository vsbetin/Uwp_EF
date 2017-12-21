using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Products
{
    public interface IProductCompanyRepository : IProductsInfoRepository
    {
        void ChangeProductName(CompanyProduct companyProduct, string name);
        void ChangeProductCost(CompanyProduct companyProduct, int cost);
        void AddProduct(string productName, int cost, Company company);
        void AddProduct(Product product, int cost, Company company);
        void DeleteProduct(CompanyProduct companyProduct);
    }
}
