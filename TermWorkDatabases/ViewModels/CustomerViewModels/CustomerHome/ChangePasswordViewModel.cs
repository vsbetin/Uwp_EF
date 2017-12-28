﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Customers;
using TermWorkDatabases.Models.Services.Interfaces.Customers;
using TermWorkDatabases.Views.CustomerView;

namespace TermWorkDatabases.ViewModels.CustomerViewModels.CustomerHome
{
    class ChangePasswordViewModel : ViewModelBase
    {
        public ChangePasswordViewModel(Customer customer)
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

        private string _oldPassword;
        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                SetProperty(ref _oldPassword, value, "OldPassword");
            }
        }

        private string _newPassword;
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                SetProperty(ref _newPassword, value, "NewPassword");
            }
        }

        private string _repeatNewPassword;
        public string RepeatNewPassword
        {
            get { return _repeatNewPassword; }
            set
            {
                SetProperty(ref _repeatNewPassword, value, "RepeatNewPassword");
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

        RelayCommand _changePassword;
        public RelayCommand ChangePassword
        {
            get
            {
                return _changePassword ?? (_changePassword = new RelayCommand(ExecuteChangePassword));
            }
        }

        private void ExecuteChangePassword(object obj)
        {
            if (CheckFields())
            {
                if (_customerInfoService.ChangeCustomerPassword(OldPassword, NewPassword))
                    NavigationService.GoBack();
                else
                    ErroreText = "Wrong old password";
            }
            else
                ErroreText = "Invalid new password";
        }

        private bool CheckFields()
        {
            return !string.IsNullOrWhiteSpace(OldPassword) && !string.IsNullOrWhiteSpace(NewPassword) &&
                   !string.IsNullOrWhiteSpace(RepeatNewPassword) && NewPassword.Length >= 8 &&
                   NewPassword.Equals(RepeatNewPassword);
        }
    }
}
