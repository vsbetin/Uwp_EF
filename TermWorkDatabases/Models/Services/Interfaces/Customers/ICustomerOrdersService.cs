using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Services.Interfaces.Customers
{
    interface ICustomerOrdersService : ICustomerProductsService
    {
        bool CreateNewOrder(string companyName, string productName, int count, DateTime finishDate);
        List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> GetCompletedOrders();
        List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> GetCompletedOrdersByCompany(string companyName);
        List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> GetDuringOrders();
        List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> GetDuringOrdersByCompany(string companyName);
        void DeleteOrder(int orderId);
    }
}
