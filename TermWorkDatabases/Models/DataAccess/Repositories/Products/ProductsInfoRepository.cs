using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Context;
using TermWorkDatabases.Models.Enteties;
using Microsoft.EntityFrameworkCore;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Products
{
    class ProductsInfoRepository : RepositoryBase, IProductsInfoRepository
    {
        public List<CompanyProduct> GetCompanyProducts(Company company)
        {
            return Context.CompaniesProducts.
                   Include(compProd => compProd.Company).
                   Include(compProd => compProd.Product).
                   Where(compProd => object.ReferenceEquals(compProd.Company, company)).ToList();
        }

        public List<CompanyProduct> GetProducts()
        {
            return Context.CompaniesProducts.
                Include(compProd => compProd.Company).
                Include(compProd => compProd.Product).
                ToList();
        }

        public CompanyProduct GetProductById(int id)
        {
            return Context.CompaniesProducts.
                Include(compProd => compProd.Company).
                Include(compProd => compProd.Product).
                FirstOrDefault(compProd => compProd.Id.Equals(id));
        }

        public List<CompanyProduct> GetProductsByName(string name)
        {
            return Context.CompaniesProducts.
                Include(compProd => compProd.Company).
                Include(compProd => compProd.Product).
                Where(compProd => compProd.Product.Name.StartsWith(name)).ToList();
        }

        public void SaveChages()
        {
            Context.SaveChanges();
        }
    }
}
