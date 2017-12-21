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
    public class OrderCompanyRepository : OrderRepository, IOrderCompanyRepository
    {
        public void ConfirmNewOrder(Order order, OrderDetail orderDetail)
        {
            Context.OrderDetails.Add(orderDetail);
            order.IsStarted = true;
        }

        public void FinishOrder(Order order)
        {
            order.IsFinished = true;
            Context.OrderDetails.
                Include(ordDet => ordDet.Order).
                Include(ordDet => ordDet.Plant).
                FirstOrDefault(orderDet => object.ReferenceEquals(orderDet.Order, order)).Plant.IsFree = true;
        }

        public List<Order> GetCompanyCompletedOrders(Company company)
        {
            return Context.Orders.
                Include(order => order.Customer).
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Where(order =>
            object.ReferenceEquals(order.CompanieProduct.Company, company) &&
            order.IsFinished).
            ToList();
        }

        public List<Order> GetCompanyCompletedOrdersByCustomer(Company company, Customer customer)
        {
            return Context.Orders.
                Include(order => order.Customer).
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Where(order =>
            object.ReferenceEquals(order.CompanieProduct.Company, company) &&
            order.IsFinished &&
            object.ReferenceEquals(order.Customer, customer)).
            ToList();
        }

        public List<Order> GetCompanyDuringOrders(Company company)
        {
            return Context.Orders.
                Include(order => order.Customer).
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Where(order =>
            object.ReferenceEquals(order.CompanieProduct.Company, company) &&
            !order.IsFinished &&
            order.IsStarted).
            ToList();
        }

        public List<Order> GetCompanyDuringOrdersByCustomer(Company company, Customer customer)
        {
            return Context.Orders.
                Include(order => order.Customer).
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Where(order =>
            object.ReferenceEquals(order.CompanieProduct.Company, company) &&
            !order.IsFinished &&
            order.IsStarted &&
            object.ReferenceEquals(order.Customer, customer)).
            ToList();
        }

        public List<Order> GetCompanyNewOrders(Company company)
        {
            return Context.Orders.
                Include(order => order.Customer).
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Where(order =>
            object.ReferenceEquals(order.CompanieProduct.Company, company) &&
            !order.IsFinished &&
            !order.IsStarted).
            ToList();
        }

        public List<Order> GetCompanyNewOrdersByCustomer(Company company, Customer customer)
        {
            return Context.Orders.
                Include(order => order.Customer).
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.CompanieProduct.Product).
                Where(order =>
            object.ReferenceEquals(order.CompanieProduct.Company, company) &&
            !order.IsFinished &&
            !order.IsStarted &&
            object.ReferenceEquals(order.Customer, customer)).
            ToList();
        }
    }
}
