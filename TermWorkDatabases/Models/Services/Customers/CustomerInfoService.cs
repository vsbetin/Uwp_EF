using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Repositories;
using TermWorkDatabases.Models.DataAccess.Repositories.Customers;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Interfaces.Customers;

namespace TermWorkDatabases.Models.Services.Customers
{
    public class CustomerInfoService : ICustomerInfoService
    {
        Customer _customer;
        ICustomerInfoRepository _customerInfoRepository;
        protected ICustomerInfoRepository CustomerInfoRepository
        {
            get
            {
                return _customerInfoRepository ?? (_customerInfoRepository = new CustomerInfoRepository());
            }
        }

        public CustomerInfoService(Customer customer)
        {
            _customer = customer;
        }

        public bool ChangeCustomerInfo(string login, string name, string mobilePhone)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(name))
                CustomerInfoRepository.ChangeCustomerName(_customer, name);
            if (!string.IsNullOrWhiteSpace(mobilePhone))
                CustomerInfoRepository.ChangeCustomerMobileNumber(_customer, mobilePhone);
            if (!string.IsNullOrWhiteSpace(login))
                result = CustomerInfoRepository.ChangeCustomerLogin(_customer, login);
            CustomerInfoRepository.SaveChages();
            return result;
        }

        public bool ChangeCustomerPassword(string oldPassword, string newPassword)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                result = CustomerInfoRepository.ChangeCustomerPassword(_customer, oldPassword, newPassword);
                CustomerInfoRepository.SaveChages();
                return true;
            }
            return result;
        }

        public (string Name, string MobileNumber, int DuringOrders, int CompletedOrders) GetCustomerInfo()
        {
            return (_customer.Name, _customer.MobileNumber,
                CustomerInfoRepository.GetDuringOrdersCount(_customer),
                CustomerInfoRepository.GetFinishedOrdersCount(_customer));
        }
    }
}
