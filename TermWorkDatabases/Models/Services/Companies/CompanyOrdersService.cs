using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Repositories;
using TermWorkDatabases.Models.DataAccess.Repositories.Customers;
using TermWorkDatabases.Models.DataAccess.Repositories.Orders;
using TermWorkDatabases.Models.DataAccess.Repositories.Plants;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Interfaces.Companies;

namespace TermWorkDatabases.Models.Services.Companies
{
    public class CompanyOrdersService : ICompanyOrdersService
    {
        Company _company;

        public CompanyOrdersService(Company company)
        {
            _company = company;
        }

        IPlantsInfoRepository _plantsInfoRepository;
        public IPlantsInfoRepository PlantsInfoRepository
        {
            get
            {
                return _plantsInfoRepository ?? (_plantsInfoRepository = new PlantsInfoRepository());
            }

        }

        IOrderCompanyRepository _orderCompanyRepository;
        IOrderCompanyRepository OrderCompanyRepository
        {
            get
            {
                return _orderCompanyRepository ?? (_orderCompanyRepository = new OrderCompanyRepository());
            }
        }

        ICustomerRepository _customerRepository;
        ICustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository ?? (_customerRepository = new CustomerRepository());
            }
        }

        public List<(int PlantId, string PlantName)> GetPlants()
        {
            return PlantsInfoRepository.GetCompanyPlants(_company).
                Where(plant => plant.IsFree).
                Select<Plant, (int PlantId, string PlantName)>
                (plant => (plant.Id, plant.Name)).
                ToList();
        }

        public void ConfirmNewOrder(int OrderId, int PlantId, DateTime StartPlantWork, DateTime FinishPlantWork)
        {
            Order order = OrderCompanyRepository.GetOrder(OrderId);
            Plant plant = PlantsInfoRepository.GetPlantById(PlantId);
            OrderDetail orderDetail = new OrderDetail
            {
                Order = order,
                Plant = plant,
                StartWorkPlantDate = StartPlantWork,
                FinishWorkPlantDate = FinishPlantWork
            };
            OrderCompanyRepository.ConfirmNewOrder(order, orderDetail);
            OrderCompanyRepository.SaveChages();


            string messageBody = $"Order #{order.Id}" + Environment.NewLine +
                                 $"Product: {order.CompanieProduct.Product.Name}" + Environment.NewLine +
                                 $"Count: {order.Count}" + Environment.NewLine +
                                 $"Price: {order.Count * order.CompanieProduct.Cost}" + Environment.NewLine +
                                 $"Finish date: {order.FinishDate.ToString()}" + Environment.NewLine +
                                 $"Company: {order.CompanieProduct.Company.Name}" + Environment.NewLine +
                                 $"Company number: {order.CompanieProduct.Company.MobileNumber}" + Environment.NewLine +
                                 $"Company email: {order.CompanieProduct.Company.Email}" + Environment.NewLine;
            string messageSubject = "Order #" + order.Id;
            var from = new MailAddress("vladyslavbetin@gmail.com");
            var to = new MailAddress(order.Customer.Email);
            string password = "31071998mandarin";
            var mail = new MailMessage();
            mail.From = from;
            mail.To.Add(to);
            mail.Subject = messageSubject;
            mail.Body = messageBody;
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(from.Address, password);
            client.Send(mail);
        }

        public void DeleteOrder(int orderId)
        {
            OrderCompanyRepository.CancelOrder(OrderCompanyRepository.GetOrder(orderId));
            OrderCompanyRepository.SaveChages();
        }

        public List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetCompletedOrders()
        {
            return OrderCompanyRepository.GetCompanyCompletedOrders(_company).
                Select<Order, (int orderId, string productName, string customerName, string finishDate, int count, double cost)>
                (order =>
                (
                    order.Id,
                    order.CompanieProduct.Product.Name,
                    order.Customer.Name,
                    (order.FinishDate.Day.ToString() + "." +
                    order.FinishDate.Month.ToString() + "." +
                    order.FinishDate.Year.ToString()),
                    order.Count,
                    order.CompanieProduct.Cost * order.Count
                )).ToList();
        }

        public List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetCompletedOrdersByCustomer(string customerName)
        {
            Customer customer = CustomerRepository.GetCustomer(customerName);
            return OrderCompanyRepository.GetCompanyCompletedOrdersByCustomer(_company, customer).
                Select<Order, (int orderId, string productName, string customerName, string finishDate, int count, double cost)>
                (order =>
                (
                    order.Id,
                    order.CompanieProduct.Product.Name,
                    order.Customer.Name,
                    (order.FinishDate.Day.ToString() + "." +
                    order.FinishDate.Month.ToString() + "." +
                    order.FinishDate.Year.ToString()),
                    order.Count,
                    order.CompanieProduct.Cost * order.Count
                )).ToList();
        }

        public List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetDuringOrders()
        {
            return OrderCompanyRepository.GetCompanyDuringOrders(_company).
                Select<Order, (int orderId, string productName, string customerName, string finishDate, int count, double cost)>
                (order =>
                (
                    order.Id,
                    order.CompanieProduct.Product.Name,
                    order.Customer.Name,
                    (order.FinishDate.Day.ToString() + "." +
                    order.FinishDate.Month.ToString() + "." +
                    order.FinishDate.Year.ToString()),
                    order.Count,
                    order.CompanieProduct.Cost * order.Count
                )).ToList();
        }

        public List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetDuringOrdersByCustomer(string customerName)
        {
            Customer customer = CustomerRepository.GetCustomer(customerName);
            return OrderCompanyRepository.GetCompanyDuringOrdersByCustomer(_company, customer).
                Select<Order, (int orderId, string productName, string customerName, string finishDate, int count, double cost)>
                (order =>
                (
                    order.Id,
                    order.CompanieProduct.Product.Name,
                    order.Customer.Name,
                    (order.FinishDate.Day.ToString() + "." +
                    order.FinishDate.Month.ToString() + "." +
                    order.FinishDate.Year.ToString()),
                    order.Count,
                    order.CompanieProduct.Cost * order.Count
                )).ToList();
        }

        public List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetNewOrders()
        {
            return OrderCompanyRepository.GetCompanyNewOrders(_company).
                Select<Order, (int orderId, string productName, string customerName, string finishDate, int count, double cost)>
                (order =>
                (
                    order.Id,
                    order.CompanieProduct.Product.Name,
                    order.Customer.Name,
                    (order.FinishDate.Day.ToString() + "." +
                    order.FinishDate.Month.ToString() + "." +
                    order.FinishDate.Year.ToString()),
                    order.Count,
                    order.CompanieProduct.Cost * order.Count
                )).ToList();
        }

        public List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetNewOrdersByCustomer(string customerName)
        {
            Customer customer = CustomerRepository.GetCustomer(customerName);
            return OrderCompanyRepository.GetCompanyNewOrdersByCustomer(_company, customer).
                Select<Order, (int orderId, string productName, string customerName, string finishDate, int count, double cost)>
                (order =>
                (
                    order.Id,
                    order.CompanieProduct.Product.Name,
                    order.Customer.Name,
                    (order.FinishDate.Day.ToString() + "." +
                    order.FinishDate.Month.ToString() + "." +
                    order.FinishDate.Year.ToString()),
                    order.Count,
                    order.CompanieProduct.Cost * order.Count
                )).ToList();
        }

        public void FinishOrder(int OrderId)
        {
            Order order = OrderCompanyRepository.GetOrder(OrderId);
            OrderCompanyRepository.FinishOrder(order);
            OrderCompanyRepository.SaveChages();
        }

        public Order GetOrderById(int id)
        {
            return OrderCompanyRepository.GetOrder(id);
        }
    }
}
