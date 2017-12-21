using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerOrders
{
    class ConfirmOrderViewModel : ViewModelBase
    {
        public ConfirmOrderViewModel(Order order)
        {
            _order = order;
            _companyOrdersService = new CompanyOrdersService(order.CompanieProduct.Company);
            PlantsList = _companyOrdersService.GetPlants();
        }

        Order _order;
        CompanyOrdersService _companyOrdersService;

        INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get
            {
                return _navigationService ?? (_navigationService = new NavigationService());
            }
        }

        private (int Id, string PlantName) _plant;
        public (int Id, string PlantName) Plant
        {
            get { return _plant; }
            set
            {
                SetProperty(ref _plant, value, "Plant");
            }
        }

        private List<(int Id, string PlantName)> _plantsList;
        public List<(int Id, string PlantName)> PlantsList
        {
            get { return _plantsList; }
            set
            {
                SetProperty(ref _plantsList, value, "PlantsList");
            }
        }

        private DateTimeOffset _startPlantWorkDate;
        public DateTimeOffset StartPlantWorkDate
        {
            get { return _startPlantWorkDate; }
            set
            {
                SetProperty(ref _startPlantWorkDate, value, "StartPlantWorkDate");
            }
        }

        private DateTimeOffset _finishPlantWorkDate;
        public DateTimeOffset FinishPlantWorkDate
        {
            get { return _finishPlantWorkDate; }
            set
            {
                SetProperty(ref _finishPlantWorkDate, value, "FinishPlantWorkDate");
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

        RelayCommand _confirmOrder;
        public RelayCommand ConfirmOrder
        {
            get
            {
                return _confirmOrder ?? (_confirmOrder = new RelayCommand(ExecuteConfirmOrder));
            }
        }

        private void ExecuteConfirmOrder(object obj)
        {
            if (!Plant.Id.Equals(0) &&
                StartPlantWorkDate.Date.CompareTo(FinishPlantWorkDate.Date) < 0 &&
                StartPlantWorkDate.Date >= DateTime.Now)
            {
                _companyOrdersService.ConfirmNewOrder(_order.Id, Plant.Id, StartPlantWorkDate.Date, FinishPlantWorkDate.Date);
                NavigationService.GoBack();
            }
            else
                ErroreText = "Invalid data";
        }
    }
}
