using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Customers;

namespace TermWorkDatabases.ViewModels.CustomerViewModels.CustomerOrders
{
    class NewOrderViewModel : ViewModelBase
    {
        public NewOrderViewModel(Customer customer)
        {
            _customer = customer;
            _customerOrdersService = new CustomerOrdersService(_customer);
            ProductsList = _customerOrdersService.GetProducts();
            CompanyList = _customerOrdersService.GetCompaniesName();
            CompanyList.Insert(0, "Companies");
        }
        Customer _customer;
        CustomerOrdersService _customerOrdersService;

        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                SetProperty(ref _companyName, value, "CompanyName");
            }
        }

        private (int Id, string ProductName, string CompanyName, int Cost) _product;
        public (int Id, string ProductName, string CompanyName, int Cost) Product
        {
            get { return _product; }
            set
            {
                SetProperty(ref _product, value, "Product");
            }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                SetProperty(ref _count, value, "Count");
            }
        }

        private DateTimeOffset _date;
        public DateTimeOffset Date
        {
            get { return _date; }
            set
            {
                SetProperty(ref _date, value, "Date");
            }
        }

        private int _allPrice;
        public int AllPrice
        {
            get { return _allPrice; }
            set
            {
                SetProperty(ref _allPrice, value, "AllPrice");
            }
        }

        private List<string> _companyList;
        public List<string> CompanyList
        {
            get { return _companyList; }
            set
            {
                SetProperty(ref _companyList, value, "CompanyList");
            }
        }

        private List<(int Id, string ProductName, string CompanyName, int Cost)> _productsList;
        public List<(int Id, string ProductName, string CompanyName, int Cost)> ProductsList
        {
            get { return _productsList; }
            set
            {
                SetProperty(ref _productsList, value, "ProductsList");
            }
        }

        private string _erroreText;
        public string ErroreText
        {
            get { return _erroreText; }
            set
            {
                SetProperty(ref _erroreText, value, "ErroreText");
            }
        }

        RelayCommand _countAllPrice;
        public RelayCommand CountAllPrice
        {
            get
            {
                return _countAllPrice ?? (_countAllPrice = new RelayCommand(ExecuteCountAllPrice));
            }
        }

        private void ExecuteCountAllPrice(object obj)
        {
            AllPrice = Count * Product.Cost;
        }

        RelayCommand _createOrder;
        public RelayCommand CreateOrder
        {
            get
            {
                return _createOrder ?? (_createOrder = new RelayCommand(ExecuteCreateOrder));
            }
        }

        private void ExecuteCreateOrder(object obj)
        {
            if (_customerOrdersService.CreateNewOrder(Product.CompanyName, Product.ProductName, Count, Date.Date))
                ErroreText = "Order created";
            else
                ErroreText = "Wrong data";

        }

        RelayCommand _changeFilter;
        public RelayCommand ChangeFilter
        {
            get
            {
                return _changeFilter ?? (_changeFilter = new RelayCommand(ExecuteChangeFilter));
            }
        }

        private void ExecuteChangeFilter(object obj)
        {
            List<(int Id, string CompanyName, string ProductName, int Cost)> productsByCompany;
            if (CompanyName.Equals("Companies"))
            {
                ProductsList = _customerOrdersService.GetProducts();
                return;
            }
            else
                productsByCompany = _customerOrdersService.GetProductsByCompany(CompanyName);

            if (productsByCompany == null)
            {
                return;
            }
            else
                ProductsList = productsByCompany;            
        }
    }
}

