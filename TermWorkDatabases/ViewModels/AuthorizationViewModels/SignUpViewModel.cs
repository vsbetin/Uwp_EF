using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.DataAccess.Context;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services;
using TermWorkDatabases.Views.CustomerView;
using TermWorkDatabases.Views.ProducerView;

namespace TermWorkDatabases.ViewModels.AuthorizationViewModels
{
    class SignUpViewModel : ViewModelBase
    {
        public SignUpViewModel()
        {
            Login = String.Empty;
            Password = String.Empty;
            service = new AuthorizationService();
            ProductAccountingDbContext context = new ProductAccountingDbContext();
        }

        INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get
            {
                return _navigationService ?? (_navigationService = new NavigationService());
            }
        }

        AuthorizationService service;

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                SetProperty(ref _login, value, "Login");
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

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value, "Name");
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

        private string _repeatPassword;
        public string RepeatPassword
        {
            get { return _repeatPassword; }
            set
            {
                SetProperty(ref _repeatPassword, value, "RepeatPassword");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value, "Email");
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

        RelayCommand _signUp;
        public RelayCommand SignUp
        {
            get
            {
                return _signUp ?? (_signUp = new RelayCommand(ExecuteSignUp));
            }
        }

        private void ExecuteSignUp(object obj)
        {
            bool isCustomer = (bool)obj;
            AuthorizationService authorization = new AuthorizationService();
            if (isCustomer)
            {
                if(CheckFields())
                {
                    var customer = authorization.SignUpCustomer(Name, Login, MobilePhone, Email, Password);
                    if (customer != null)
                        NavigationService.Navigate(typeof(CustomerMain), customer);
                    else
                        ErroreText = "Login has already used";
                }
                else
                    ErroreText = "Incorrect data";
            }
            else
            {
                if (CheckFields())
                {
                    var company = authorization.SignUpCompany(Name, Login, MobilePhone, Email, Password);
                    if (company != null)
                        NavigationService.Navigate(typeof(ProducerMain), company);
                    else
                        ErroreText = "Login has already used";
                }
                else
                    ErroreText = "Incorrect data";
            }
        }
        
        private bool CheckFields()
        {
            return Password.Equals(RepeatPassword) && Password.Length >= 8 &&
                !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Login) &&
                !string.IsNullOrWhiteSpace(MobilePhone);
        }
    }
}
