using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Customers;
using TermWorkDatabases.Models.Services.Interfaces.Customers;

namespace TermWorkDatabases.ViewModels.CustomerViewModels.CustomerOrders
{
    class CompletedOrdersViewModel : ViewModelBase
    {
        public CompletedOrdersViewModel(Customer customer)
        {
            _customer = customer;
            _customerOrdersService = new CustomerOrdersService(_customer);
            CompletedOrders = _customerOrdersService.GetCompletedOrders();
        }

        Customer _customer;
        ICustomerOrdersService _customerOrdersService;

        private List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> _completedOrders;
        public List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> CompletedOrders
        {
            get { return _completedOrders; }
            set
            {
                SetProperty(ref _completedOrders, value, "CompletedOrders");
            }
        }
    }
}
