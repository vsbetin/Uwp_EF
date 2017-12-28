using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;
using TermWorkDatabases.Models.Services.Interfaces.Companies;
using TermWorkDatabases.Views.ProducerView.ProducerHome;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerHome
{
    class ProducerHomeViewModel : ViewModelBase
    {
        public ProducerHomeViewModel(Company company)
        {
            _company = company;
            _companyInfoService = new CompanyInfoService(_company);
            GetCustomerData();
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

        private int _duringOrders;
        public int DuringOrders
        {
            get { return _duringOrders; }
            set
            {
                SetProperty(ref _duringOrders, value, "DuringOrders");
            }
        }

        private int _completedOrders;
        public int CompletedOrders
        {
            get { return _completedOrders; }
            set
            {
                SetProperty(ref _completedOrders, value, "CompletedOrders");
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
            NavigationService.Navigate(typeof(ChangeProfileData), _company);
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
            NavigationService.Navigate(typeof(ChangeProducerPassword), _company);
        }

        private void GetCustomerData()
        {
            var info = _companyInfoService.GetCompanyInfo();
            Name = info.Name;
            MobilePhone = info.MobileNumber;
            DuringOrders = info.DuringOrders;
            CompletedOrders = info.CompletedOrders;
        }
    }
}

