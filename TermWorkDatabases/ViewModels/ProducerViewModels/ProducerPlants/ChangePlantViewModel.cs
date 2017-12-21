using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerPlants
{
    class ChangePlantViewModel : ViewModelBase
    {
        public ChangePlantViewModel(Plant plant)
        {
            _plant = plant;
            _companyPlantsService = new CompanyPlantsService(_plant.Company);
        }

        Plant _plant;
        CompanyPlantsService _companyPlantsService;

        INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get
            {
                return _navigationService ?? (_navigationService = new NavigationService());
            }
        }

        private string _plantName;
        public string PlantName
        {
            get { return _plantName; }
            set
            {
                SetProperty(ref _plantName, value, "PlantName");
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

        RelayCommand _changePlantName;
        public RelayCommand ChangePlantName
        {
            get
            {
                return _changePlantName ?? (_changePlantName = new RelayCommand(ExecuteChangePlantName));
            }
        }

        private void ExecuteChangePlantName(object obj)
        {
            if (_companyPlantsService.ChangePlantName(_plant.Id, PlantName))
                NavigationService.GoBack();
            else
                ErroreText = "You already have plant with same name";
        }
    }
}
