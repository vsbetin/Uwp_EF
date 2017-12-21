using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Interfaces.Customers;

namespace TermWorkDatabases.Models.Services.Interfaces.Companies
{
    interface ICompanyProductsService : ICustomerProductsService
    {
        void ChangeProduct(int companyProductId, string newName, int? cost);
        void AddProduct(string productName, int cost);
        void DeleteProduct(int companyProductId);
        CompanyProduct GetCompanyProductByProductId(int companyProductId);
    }
}
