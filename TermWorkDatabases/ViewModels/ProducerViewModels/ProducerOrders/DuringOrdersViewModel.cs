using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;
using TermWorkDatabases.Models.Services.Interfaces.Companies;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerOrders
{
    class DuringOrdersViewModel : ViewModelBase
    {
        public DuringOrdersViewModel(Company company)
        {
            _company = company;
            _companyOrdersService = new CompanyOrdersService(_company);
            DuringOrders = _companyOrdersService.GetDuringOrders();
        }

        Company _company;
        ICompanyOrdersService _companyOrdersService;

        private List<(int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price)> _duringOrders;
        public List<(int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price)> DuringOrders
        {
            get { return _duringOrders; }
            set
            {
                SetProperty(ref _duringOrders, value, "DuringOrders");
            }
        }

        private (int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price) _order;
        public (int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price) Order
        {
            get { return _order; }
            set
            {
                SetProperty(ref _order, value, "Order");
                FinishOrder.RaiseCanExecuteChanged();
                CancelOrder.RaiseCanExecuteChanged();
            }
        }

        RelayCommand _cancelOrder;
        public RelayCommand CancelOrder
        {
            get
            {
                return _cancelOrder ?? (_cancelOrder = new RelayCommand(ExecuteCancelOrder, CanExecuteCancelOrder));
            }
        }

        private void ExecuteCancelOrder(object obj)
        {
            _companyOrdersService.DeleteOrder(Order.OrderId);
            DuringOrders = _companyOrdersService.GetDuringOrders();
        }

        private bool CanExecuteCancelOrder(object obj)
        {
            return !Order.OrderId.Equals(0);

        }

        RelayCommand _finishOrder;
        public RelayCommand FinishOrder
        {
            get
            {
                return _finishOrder ?? (_finishOrder = new RelayCommand(ExecuteFinishOrder, CanExecuteFinishOrder));
            }
        }

        private bool CanExecuteFinishOrder(object obj)
        {
            return !Order.OrderId.Equals(0);

        }

        private void ExecuteFinishOrder(object obj)
        {
            _companyOrdersService.FinishOrder(Order.OrderId);
            DuringOrders = _companyOrdersService.GetDuringOrders();
        }
    }
}
