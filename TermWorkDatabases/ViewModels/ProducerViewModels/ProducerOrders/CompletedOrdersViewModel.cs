using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerOrders
{
    class CompletedOrdersViewModel : ViewModelBase
    {
        public CompletedOrdersViewModel(Company company)
        {
            _company = company;
            _companyOrdersService = new CompanyOrdersService(_company);
            CompletedOrders = _companyOrdersService.GetCompletedOrders();
        }

        Company _company;
        CompanyOrdersService _companyOrdersService;

        private List<(int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price)> _completedOrders;
        public List<(int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price)> CompletedOrders
        {
            get { return _completedOrders; }
            set
            {
                SetProperty(ref _completedOrders, value, "CompletedOrders");
            }
        }
    }
}
