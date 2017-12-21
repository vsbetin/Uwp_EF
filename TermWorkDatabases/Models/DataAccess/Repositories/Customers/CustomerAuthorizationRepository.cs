using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Context;
using TermWorkDatabases.Models.Enteties;
using Microsoft.EntityFrameworkCore;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Customers
{
    public class CustomerAuthorizationRepository : RepositoryBase, ICustomerAuthorizationRepository
    {
        public bool AddCustomer(Customer customer, CustomerAccessData customerAccessData)
        {
            if (Context.CustomerAccessDatas.
                FirstOrDefault(custData => custData.Login.Equals(customerAccessData.Login)) == null)
            {
                Context.Customers.Add(customer);
                Context.CustomerAccessDatas.Add(customerAccessData);
                return true;
            }
            else
                return false;
        }

        public bool CheckPassword(Customer customer, string password)
        {
            var customerData = Context.CustomerAccessDatas.
                Include(custData => custData.Customer).
                FirstOrDefault(custData => object.ReferenceEquals(custData.Customer, customer));
            if (customerData == null)
                return false;
            else
                return customerData.Password.Equals(password);
        }
       
        public Customer GetCustomer(string login)
        {
            var customerData = Context.CustomerAccessDatas.
                Include(custData => custData.Customer).
                Include(custData => custData.Customer.Orders).
                FirstOrDefault(custData => custData.Login.Equals(login));
            if (customerData == null)
                return null;
            else
                return customerData.Customer;
        }

        public void SaveChages()
        {
            Context.SaveChanges();
        }
    }
}
