using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Customers;
using TermWorkDatabases.Models.Services.Interfaces.Customers;

namespace TermWorkDatabases.ViewModels.CustomerViewModels.CustomerHome
{
    class ChangeProfileDataViewModel : ViewModelBase
    {
        public ChangeProfileDataViewModel(Customer customer)
        {
            _customer = customer;
            _customerInfoService = new CustomerInfoService(_customer);
        }

        Customer _customer;
        ICustomerInfoService _customerInfoService;

        INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get
            {
                return _navigationService ?? (_navigationService = new NavigationService());
            }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                SetProperty(ref _login, value, "Login");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value, "Name");
            }
        }

        private string _mobilePhone;
        public string MobilePhone
        {
            get { return _mobilePhone; }
            set
            {
                SetProperty(ref _mobilePhone, value, "MobilePhone");
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

        RelayCommand _changeData;
        public RelayCommand ChangeData
        {
            get
            {
                return _changeData ?? (_changeData = new RelayCommand(ExecuteChangeData));
            }
        }

        private void ExecuteChangeData(object obj)
        {
            if (_customerInfoService.ChangeCustomerInfo(Login, Name, MobilePhone))
                NavigationService.GoBack();
            else
                ErroreText = "Login has already used";
        }
    }
}
