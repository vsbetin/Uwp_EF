using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Repositories.Orders;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Interfaces.Customers;

namespace TermWorkDatabases.Models.Services.Customers
{
    class CustomerOrdersService : CustomerProductsService, ICustomerOrdersService
    {
        Customer _customer;
        IOrderCustomerRepository _orderCustomerRepository;
        IOrderCustomerRepository OrderCustomerRepository
        {
            get
            {
                return _orderCustomerRepository ?? (_orderCustomerRepository = new OrderCustomerRepository());
            }
        }

        public CustomerOrdersService(Customer customer)
        {
            _customer = customer;
        }

        public bool CreateNewOrder(string companyName, string productName, int count, DateTime finishDate)
        {
            Company company = CompanyRepository.GetComapny(companyName);
            if (company == null)
                return false;
            CompanyProduct companyProduct = ProductsInfoRepository.GetCompanyProducts(company).
                FirstOrDefault(product => product.Product.Name.Equals(productName));
            if (companyProduct == null)
                return false;
            if (count <= 0)
                return false;
            Order order = new Order
            {
                Customer = _customer,
                CompanieProduct = companyProduct,
                Count = count,
                FinishDate = finishDate,
                IsFinished = false,
                IsStarted = false
            };
            OrderCustomerRepository.CreateNewOrder(order);
            OrderCustomerRepository.SaveChages();
            return true;
        }

        public void DeleteOrder(int orderId)
        {
            OrderCustomerRepository.CancelOrder(OrderCustomerRepository.GetOrder(orderId));
            OrderCustomerRepository.SaveChages();
        }

        public List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> GetCompletedOrders()
        {
            return OrderCustomerRepository.GetCustomerCompletedOrders(_customer).
                Select<Order, (int orderId, string companyName, string productName, int count, string finishDate, double price)>
                (order =>
                (
                    order.Id,
                    order.CompanieProduct.Company.Name,
                    order.CompanieProduct.Product.Name,
                    order.Count,
                    (order.FinishDate.Day.ToString() + "." + 
                    order.FinishDate.Month.ToString() + "." + 
                    order.FinishDate.Year.ToString()),
                    order.CompanieProduct.Cost * order.Count
                )).ToList();
        }

        public List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> GetCompletedOrdersByCompany(string companyName)
        {
            Company company = CompanyRepository.GetComapny(companyName);
            return OrderCustomerRepository.GetCustomerCompletedOrdersByCompany(_customer, company).
                 Select<Order, (int orderId, string companyName, string productName, int count, string finishDate, double price)>
                 (order =>
                 (
                     order.Id,
                    order.CompanieProduct.Company.Name,
                    order.CompanieProduct.Product.Name,
                    order.Count,
                    (order.FinishDate.Day.ToString() + "." +
                    order.FinishDate.Month.ToString() + "." +
                    order.FinishDate.Year.ToString()),
                    order.CompanieProduct.Cost * order.Count
                 )).ToList();
        }

        public List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> GetDuringOrders()
        {
            return OrderCustomerRepository.GetCustomerDuringOrders(_customer).
                 Select<Order, (int orderId, string companyName, string productName, int count, string finishDate, double price)>
                 (order =>
                 (
                     order.Id,
                    order.CompanieProduct.Company.Name,
                    order.CompanieProduct.Product.Name,
                    order.Count,
                    (order.FinishDate.Day.ToString() + "." +
                    order.FinishDate.Month.ToString() + "." +
                    order.FinishDate.Year.ToString()),
                    order.CompanieProduct.Cost * order.Count
                 )).ToList();
        }

        public List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> GetDuringOrdersByCompany(string companyName)
        {
            Company company = CompanyRepository.GetComapny(companyName);
            return OrderCustomerRepository.GetCustomerDuringOrdersByCompany(_customer, company).
                 Select<Order, (int orderId, string companyName, string productName, int count, string finishDate, double price)>
                 (order =>
                 (
                    order.Id,
                    order.CompanieProduct.Company.Name,
                    order.CompanieProduct.Product.Name,
                    order.Count,
                    (order.FinishDate.Day.ToString() + "." +
                    order.FinishDate.Month.ToString() + "." +
                    order.FinishDate.Year.ToString()),
                    order.CompanieProduct.Cost * order.Count
                 )).ToList();
        }
    }
}
