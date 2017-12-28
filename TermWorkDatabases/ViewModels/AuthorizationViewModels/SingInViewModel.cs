using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services;
using TermWorkDatabases.Models.Services.Interfaces;
using TermWorkDatabases.Views.CustomerView;
using TermWorkDatabases.Views.ProducerView;

namespace TermWorkDatabases.ViewModels.AuthorizationViewModels
{
    class SingInViewModel : ViewModelBase
    {
        public SingInViewModel()
        {
            Login = String.Empty;
            Password = String.Empty;
            service = new AuthorizationService();
        }

        INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get
            {
                return _navigationService ?? (_navigationService = new NavigationService());
            }
        }

        IAuthorizationService service;

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                SetProperty(ref _login, value, "Login");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value, "Password");
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

        RelayCommand _signIn;
        public RelayCommand SignIn
        {
            get
            {
                return _signIn ?? (_signIn = new RelayCommand(ExecuteSignIn));
            }
        }

        private void ExecuteSignIn(object obj)
        {
            bool isCustomer = (bool)obj;
            AuthorizationService authorization = new AuthorizationService();
            if (isCustomer)
            {

                Customer customer = authorization.SignInCustomer(Login, Password);
                if (customer != null)
                    NavigationService.Navigate(typeof(CustomerMain), customer);
                else
                    ErroreText = "Wrong customer login or password";
            }
            else
            {
                Company company = authorization.SignInCompany(Login, Password);
                if (company != null)
                    NavigationService.Navigate(typeof(ProducerMain), company);
                else
                    ErroreText = "Wrong producer login or password";
            }
        }
    }
}
