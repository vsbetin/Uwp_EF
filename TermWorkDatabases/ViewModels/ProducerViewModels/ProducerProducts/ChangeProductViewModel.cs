using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerProducts
{
    class ChangeProductViewModel : ViewModelBase
    {
        public ChangeProductViewModel(CompanyProduct companyProduct)
        {
            _companyProduct = companyProduct;
            _companyProductsService = new CompanyProductsService(companyProduct.Company);
        }

        CompanyProduct _companyProduct;
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

        private int _cost;
        public int Cost
        {
            get { return _cost; }
            set
            {
                SetProperty(ref _cost, value, "Cost");
            }
        }
        RelayCommand _changeProduct;
        public RelayCommand ChangeProduct
        {
            get
            {
                return _changeProduct ?? (_changeProduct = new RelayCommand(ExecuteChangeProduct));
            }
        }

        private void ExecuteChangeProduct(object obj)
        {
            _companyProductsService.ChangeProduct(_companyProduct.Id,ProductName, Cost);
            NavigationService.GoBack();
        }
    }
}
