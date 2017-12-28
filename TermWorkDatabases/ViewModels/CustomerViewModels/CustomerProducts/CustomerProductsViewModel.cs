using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Customers;
using TermWorkDatabases.Models.Services.Interfaces.Customers;

namespace TermWorkDatabases.ViewModels.CustomerViewModels.CustomerProducts
{
    class CustomerProductsViewModel : ViewModelBase
    {
        public CustomerProductsViewModel(Customer customer)
        {
            _customer = customer;
            _customerProductsService = new CustomerProductsService();
            ProductsList = _customerProductsService.GetProducts();
            CompanyList = _customerProductsService.GetCompaniesName();
            CompanyList.Insert(0, "Companies");
        }

        Customer _customer;
        ICustomerProductsService _customerProductsService;

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                SetProperty(ref _productName, value, "ProductName");
            }
        }

        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                SetProperty(ref _companyName, value, "CompanyName");
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

        private List<(int Id, string CompanyName, string ProductName, int Cost)> _productsList;
        public List<(int Id, string CompanyName, string ProductName, int Cost)> ProductsList
        {
            get { return _productsList; }
            set
            {
                SetProperty(ref _productsList, value, "ProductsList");
            }
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
            if (string.IsNullOrEmpty(CompanyName) || CompanyName.Equals("Companies"))
                productsByCompany = _customerProductsService.GetProducts();
            else
                productsByCompany = _customerProductsService.GetProductsByCompany(CompanyName);

            List<(int Id, string CompanyName, string ProductName, int Cost)> productsByName; 
            if (string.IsNullOrEmpty(ProductName))
                productsByName = _customerProductsService.GetProducts();
            else
                productsByName = _customerProductsService.GetProductsByName(ProductName);

            if (productsByCompany == null)
            {
                if (productsByName == null)
                    return;
                else
                    ProductsList = productsByName;
            }
            else if (productsByName == null)
                ProductsList = productsByCompany;
            else
                ProductsList = productsByCompany.Intersect(productsByName).ToList();
        }

    }
}
