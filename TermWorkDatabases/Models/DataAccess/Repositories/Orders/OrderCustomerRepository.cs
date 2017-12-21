using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Context;
using TermWorkDatabases.Models.Enteties;
using Microsoft.EntityFrameworkCore;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Orders
{
    class OrderCustomerRepository : OrderRepository, IOrderCustomerRepository
    {
        public void CreateNewOrder(Order order)
        {
            Context.Orders.Add(order);
        }

        public List<Order> GetCustomerCompletedOrders(Customer customer)
        {
            return Context.Orders.
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Include(order => order.Customer).
                Where(order =>
                    object.ReferenceEquals(order.Customer, customer) &&
                    order.IsFinished).
                    ToList();
        }

        public List<Order> GetCustomerCompletedOrdersByCompany(Customer customer, Company company)
        {
            return Context.Orders.
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Include(order => order.Customer).
                Where(order =>
                    object.ReferenceEquals(order.Customer, customer) &&
                    order.IsFinished &&
                    object.ReferenceEquals(order.CompanieProduct.Company, company)).
                    ToList();
        }

        public List<Order> GetCustomerDuringOrders(Customer customer)
        {
            return Context.Orders.
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Include(order => order.Customer).
                Where(order => object.ReferenceEquals(order.Customer, customer) &&
                               !order.IsFinished).
                ToList();
        }

        public List<Order> GetCustomerDuringOrdersByCompany(Customer customer, Company company)
        {
            return Context.Orders.
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Include(order => order.Customer).
                Where(order => object.ReferenceEquals(order.Customer, customer) &&
                               !order.IsFinished &&
                               object.ReferenceEquals(order.CompanieProduct.Company, company)).
                ToList();
        }
    }
}
