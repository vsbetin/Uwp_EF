using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Orders
{
    interface IOrderCustomerRepository : IOrderRepository
    {
        void CreateNewOrder(Order order);
        List<Order> GetCustomerDuringOrders(Customer customer);
        List<Order> GetCustomerDuringOrdersByCompany(Customer customer, Company company);
        List<Order> GetCustomerCompletedOrders(Customer customer);
        List<Order> GetCustomerCompletedOrdersByCompany(Customer customer, Company company);
    }
}
