using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Orders
{
    public interface IOrderCompanyRepository : IOrderRepository
    {
        List<Order> GetCompanyNewOrders(Company company);
        List<Order> GetCompanyNewOrdersByCustomer(Company company, Customer customer);
        List<Order> GetCompanyDuringOrders(Company company);
        List<Order> GetCompanyDuringOrdersByCustomer(Company company, Customer customer);
        List<Order> GetCompanyCompletedOrders(Company company);
        List<Order> GetCompanyCompletedOrdersByCustomer(Company company, Customer customer);
        void ConfirmNewOrder(Order order, OrderDetail orderDetail);
        void FinishOrder(Order order);
    }
}
