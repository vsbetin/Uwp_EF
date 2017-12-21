using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Customers;

namespace TermWorkDatabases.ViewModels.CustomerViewModels.CustomerOrders
{
    class DuringOrdersViewModel : ViewModelBase
    {
        public DuringOrdersViewModel(Customer customer)
        {
            _customer = customer;
            _customerOrdersService = new CustomerOrdersService(_customer);
            DuringOrders = _customerOrdersService.GetDuringOrders();
        }

        Customer _customer;
        CustomerOrdersService _customerOrdersService;

        private List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> _duringOrders;
        public List<(int OrderId, string CompanyName, string ProductName, int Count, string FinishDate, double Price)> DuringOrders
        {
            get { return _duringOrders; }
            set
            {
                SetProperty(ref _duringOrders, value, "DuringOrders");
            }
        }
    }
}
