using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;
using TermWorkDatabases.Models.Services.Interfaces.Companies;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerPlants
{
    class AddPlantViewModel : ViewModelBase
    {
        public AddPlantViewModel(Company company)
        {
            _company = company;
            _companyPlantsService = new CompanyPlantsService(_company);
        }

        Company _company;
        ICompanyPlantsService _companyPlantsService;

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
                AddPlant.RaiseCanExecuteChanged();
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

        RelayCommand _addPlant;
        public RelayCommand AddPlant
        {
            get
            {
                return _addPlant ?? (_addPlant = new RelayCommand(ExecuteAddPlant, CanExecuteAddPlant));
            }
        }

        private bool CanExecuteAddPlant(object obj)
        {
            return !string.IsNullOrWhiteSpace(PlantName);
        }

        private void ExecuteAddPlant(object obj)
        {
            if (_companyPlantsService.AddPlant(PlantName))
                NavigationService.GoBack();
            else
                ErroreText = "You already have plant with same name";
        }
    }
}
