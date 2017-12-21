
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Context
{
    public class ProductAccountingDbContext : DbContext
    {
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyProduct> CompaniesProducts { get; set; }
        public virtual DbSet<CompanyAccessData> CompanyAccessDatas { get; set; }
        public virtual DbSet<CustomerAccessData> CustomerAccessDatas { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=ProductsAccounting.db");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
