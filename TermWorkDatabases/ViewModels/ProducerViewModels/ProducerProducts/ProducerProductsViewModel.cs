using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;
using TermWorkDatabases.Views.ProducerView;
using TermWorkDatabases.Views.ProducerView.ProducerProducts;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerProducts
{
    class ProducerProductsViewModel : ViewModelBase
    {
        public ProducerProductsViewModel(Company company)
        {
            _company = company;
            _companyProductsService = new CompanyProductsService(_company);
            ProductsList = _companyProductsService.GetProducts();
            CompanyList = _companyProductsService.GetCompaniesName();
            CompanyList.Insert(0, "Companies");
        }

        Company _company;
        CompanyProductsService _companyProductsService;

        INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get
            {
                return _navigationService ?? (_navigationService = new NavigationService());
            }
        }

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

        private (int Id, string CompanyName, string ProductName, int Cost) _product;
        public (int Id, string CompanyName, string ProductName, int Cost) Product
        {
            get { return _product; }
            set
            {
                SetProperty(ref _product, value, "Product");
                ChangeProduct.RaiseCanExecuteChanged();
                DeleteProduct.RaiseCanExecuteChanged();
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
                productsByCompany = _companyProductsService.GetProducts();
            else
                productsByCompany = _companyProductsService.GetProductsByCompany(CompanyName);

            List<(int Id, string CompanyName, string ProductName, int Cost)> productsByName;
            if (string.IsNullOrEmpty(ProductName))
                productsByName = _companyProductsService.GetProducts();
            else
                productsByName = _companyProductsService.GetProductsByName(ProductName);

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


        RelayCommand _deleteProduct;
        public RelayCommand DeleteProduct
        {
            get
            {
                return _deleteProduct ?? (_deleteProduct = new RelayCommand(ExecuteDeleteProduct, CanExecuteDeleteProduct));
            }
        }

        private bool CanExecuteDeleteProduct(object obj)
        {
            return !(Product.CompanyName == null);
        }

        private void ExecuteDeleteProduct(object obj)
        {
            _companyProductsService.DeleteProduct(Product.Id);
            ExecuteChangeFilter(null);
        }

        RelayCommand _addProduct;
        public RelayCommand AddProduct
        {
            get
            {
                return _addProduct ?? (_addProduct = new RelayCommand(ExecuteAddProduct));
            }
        }

        private void ExecuteAddProduct(object obj)
        {
            NavigationService.Navigate(typeof(ProducerAddNewProduct), _company);
        }

        RelayCommand _changeProduct;
        public RelayCommand ChangeProduct
        {
            get
            {
                return _changeProduct ?? (_changeProduct = new RelayCommand(ExecuteChangeProduct, CanExecuteChangeProduct));
            }
        }

        private bool CanExecuteChangeProduct(object obj)
        {
            return !(Product.CompanyName == null);
        }

        private void ExecuteChangeProduct(object obj)
        {
            NavigationService.Navigate(typeof(ProducerModifyProduct), _companyProductsService.GetCompanyProductByProductId(Product.Id));
        }
    }
}
