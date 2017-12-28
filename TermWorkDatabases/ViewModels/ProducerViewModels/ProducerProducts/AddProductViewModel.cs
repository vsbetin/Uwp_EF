using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;
using TermWorkDatabases.Models.Services.Interfaces.Companies;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerProducts
{
    class AddProductViewModel : ViewModelBase
    {
        public AddProductViewModel(Company company)
        {
            _company = company;
            _companyProductsService = new CompanyProductsService(_company);
        }

        Company _company;
        ICompanyProductsService _companyProductsService;

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

        private int _cost;
        public int Cost
        {
            get { return _cost; }
            set
            {
                SetProperty(ref _cost, value, "Cost");
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
            if (CheckFields())
            {
                _companyProductsService.AddProduct(ProductName, Cost);
                NavigationService.GoBack();
            }
            else
                ErroreText = "Invalid data";
        }

        private bool CheckFields()
        {
            return !string.IsNullOrWhiteSpace(ProductName) &&
                   Cost > 0;
        }
    }
}
