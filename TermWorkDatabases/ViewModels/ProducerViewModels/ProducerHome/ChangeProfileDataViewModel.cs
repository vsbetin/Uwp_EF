using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;
using TermWorkDatabases.Models.Services.Interfaces.Companies;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerHome
{
    class ChangeProfileDataViewModel : ViewModelBase
    {
        public ChangeProfileDataViewModel(Company company)
        {
            _company = company;
            _companyInfoService = new CompanyInfoService(_company);
        }

        Company _company;
        ICompanyInfoService _companyInfoService;

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
            if (_companyInfoService.ChangeCompanyInfo(Login, Name, MobilePhone))
                NavigationService.GoBack();
            else
                ErroreText = "Login has already used";
        }
    }
}

