using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    public interface IProductsInfoRepository : ISaveChanges
    {
        List<CompanyProduct> GetProducts();
        List<CompanyProduct> GetCompanyProducts(Company company);
        List<CompanyProduct> GetProductsByName(string name);
        CompanyProduct GetProductById(int id);
    }
}
