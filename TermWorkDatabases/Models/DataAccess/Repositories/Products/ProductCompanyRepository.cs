using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Context;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Products
{
    public class ProductCompanyRepository : ProductsInfoRepository, IProductCompanyRepository
    {
        public void AddProduct(string productName, int cost, Company company)
        {
            Product product = Context.Products.FirstOrDefault(prod => prod.Name.Equals(productName));
            if (product == null)
            {
                product = new Product { Name = productName };
                Context.Products.Add(product);
            }

            CompanyProduct companyProduct = Context.CompaniesProducts.
                                            FirstOrDefault(compProd => compProd.Company == company &&
                                            compProd.Product == product);
            if (companyProduct == null)
                Context.CompaniesProducts.Add(
                    new CompanyProduct { Company = company, Cost = cost, Product = product });
            else
                companyProduct.Cost = cost;
        }

        public void AddProduct(Product product, int cost, Company company)
        {
            if (product == null)
                return;
            AddProduct(product.Name, cost, company);
        }

        public void ChangeProductCost(CompanyProduct companyProduct, int cost)
        {
            Context.CompaniesProducts.FirstOrDefault(compProd => compProd == companyProduct).Cost = cost;
        }

        public void ChangeProductName(CompanyProduct companyProduct, string name)
        {
            if (companyProduct == null)
                return;
            Product product = companyProduct.Product;
            if (product.Companies.Count <= 1)
                product.Name = name;
            else
            {
                Product newProduct = Context.Products.FirstOrDefault(prod => prod.Name.Equals(name));
                if (newProduct == null)
                {
                    newProduct = new Product { Name = name };
                    Context.Products.Add(newProduct);
                }
                companyProduct.Product = newProduct;
            }
        }

        public void DeleteProduct(CompanyProduct companyProduct)
        {
            if (companyProduct == null)
                return;
            Product product = companyProduct.Product;
            Context.CompaniesProducts.Remove(companyProduct);
            if (product.Companies.Count <= 1)
                Context.Products.Remove(product);
        }
    }
}
