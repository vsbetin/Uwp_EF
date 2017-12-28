using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;
using TermWorkDatabases.Models.Services.Interfaces.Companies;
using TermWorkDatabases.Views.ProducerView.ProducerNewOrders;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerOrders
{
    class NewOrdersViewModel : ViewModelBase
    {
        public NewOrdersViewModel(Company company)
        {
            _company = company;
            _companyOrdersService = new CompanyOrdersService(_company);
            NewOrders = _companyOrdersService.GetNewOrders();            
        }

        Company _company;
        ICompanyOrdersService _companyOrdersService;

        INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get
            {
                return _navigationService ?? (_navigationService = new NavigationService());
            }
        }

        private (int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price) _order;
        public (int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price) Order
        {
            get { return _order; }
            set
            {
                SetProperty(ref _order, value, "Order");
                CancelOrder.RaiseCanExecuteChanged();
                ConfirmOrder.RaiseCanExecuteChanged();
            }
        }

        private List<(int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price)> _newOrders;
        public List<(int OrderId, string ProductName, string CompanyName, string FinishDate, int Count, double Price)> NewOrders
        {
            get { return _newOrders; }
            set
            {
                SetProperty(ref _newOrders, value, "NewOrders");
            }
        }

        RelayCommand _cancelOrder;
        public RelayCommand CancelOrder
        {
            get
            {
                return _cancelOrder ?? (_cancelOrder = new RelayCommand(ExecuteCancelOrder, CanExecuteConfirmCancelOrder));
            }
        }

        private void ExecuteCancelOrder(object obj)
        {
            _companyOrdersService.DeleteOrder(Order.OrderId);
            NewOrders = _companyOrdersService.GetNewOrders();
        }

        RelayCommand _confirmOrder;
        public RelayCommand ConfirmOrder
        {
            get
            {
                return _confirmOrder ?? (_confirmOrder = new RelayCommand(ExecuteConfirmOrder, CanExecuteConfirmCancelOrder));
            }
        }

        private void ExecuteConfirmOrder(object obj)
        {
            NavigationService.Navigate(typeof(ConfirmOrder), _companyOrdersService.GetOrderById(Order.OrderId));
        }

        private bool CanExecuteConfirmCancelOrder(object obj)
        {
            return !Order.OrderId.Equals(0);

        }
    }
}
