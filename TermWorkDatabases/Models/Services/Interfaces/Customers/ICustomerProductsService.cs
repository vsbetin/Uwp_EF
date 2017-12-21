using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Services.Interfaces.Customers
{
    interface ICustomerProductsService
    {
        List<string> GetCompaniesName();
        List<(int Id, string ProductName, string CompanyName, int Cost)> GetProducts();
        List<(int Id, string ProductName, string CompanyName, int Cost)> GetProductsByCompany(string companyName);
        List<(int Id, string ProductName, string CompanyName, int Cost)> GetProductsByName(string productName);
    }
}
