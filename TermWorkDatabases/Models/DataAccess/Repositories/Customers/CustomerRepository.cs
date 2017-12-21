using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Customers
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public Customer GetCustomer(string name)
        {
            return Context.Customers.FirstOrDefault(cust => cust.Name == name);
        }

        public Customer GetCustomer(int id)
        {
            return Context.Customers.FirstOrDefault(cust => cust.Id == id);
        }

        public List<Customer> GetCustomers()
        {
            return Context.Customers.ToList();
        }

        public void SaveChages()
        {
            Context.SaveChanges();
        }
    }
}
