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
    public class CustomerInfoRepository : CustomerRepository, ICustomerInfoRepository
    {
        public bool ChangeCustomerLogin(Customer customer, string login)
        {
            if (Context.CustomerAccessDatas.FirstOrDefault(custData => custData.Login.Equals(login)) == null)
            {
                Context.CustomerAccessDatas.
                    Include(custData => custData.Customer).
                    FirstOrDefault(custData => object.ReferenceEquals(custData.Customer, customer)).Login = login;
                return true;
            }
            return false;
        }

        public void ChangeCustomerMobileNumber(Customer customer, string mobileNumber)
        {
            customer.MobileNumber = mobileNumber;
        }

        public void ChangeCustomerName(Customer customer, string name)
        {
            customer.Name = name;
        }

        public bool ChangeCustomerPassword(Customer customer, string oldPassword, string newPassword)
        {
            CustomerAccessData customerAccessData = Context.CustomerAccessDatas.
                Include(custData => custData.Customer).
                FirstOrDefault(custData => object.ReferenceEquals(custData.Customer, customer));
            if (customerAccessData.Password.Equals(oldPassword))
            {
                customerAccessData.Password = newPassword;
                return true;
            }
            return false;
        }

        public int GetDuringOrdersCount(Customer customer)
        {
            return Context.Customers.
                     Include(cust => cust.Orders).
                     FirstOrDefault(cust => object.ReferenceEquals(cust, customer)).
                     Orders.Where(order => order.IsStarted && !order.IsFinished).Count();
        }

        public int GetFinishedOrdersCount(Customer customer)
        {
            return Context.Customers.
                     Include(cust => cust.Orders).
                     FirstOrDefault(cust => object.ReferenceEquals(cust, customer)).
                     Orders.Where(order => order.IsFinished).Count();
        }
    }
}
