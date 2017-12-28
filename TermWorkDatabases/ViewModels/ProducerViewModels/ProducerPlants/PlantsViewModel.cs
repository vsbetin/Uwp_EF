using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Infrastructure;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Companies;
using TermWorkDatabases.Models.Services.Interfaces.Companies;
using TermWorkDatabases.Views.ProducerView.ProducerPlants;
using TermWorkDatabases.Views.ProducerView.ProducerProducts;

namespace TermWorkDatabases.ViewModels.ProducerViewModels.ProducerPlants
{
    class PlantsViewModel : ViewModelBase
    {
        public PlantsViewModel(Company company)
        {
            _company = company;
            _companyPlantsService = new CompanyPlantsService(_company);
            PlantsList = _companyPlantsService.GetCompanyPlants();
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

        private (int Id, string PlantName) _plant;
        public (int Id, string PlantName) Plant
        {
            get { return _plant; }
            set
            {
                SetProperty(ref _plant, value, "Plant");
                ChangePlant.RaiseCanExecuteChanged();
                DeletePlant.RaiseCanExecuteChanged();
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

        RelayCommand _deletePlant;
        public RelayCommand DeletePlant
        {
            get
            {
                return _deletePlant ?? (_deletePlant = new RelayCommand(ExecuteDeletePlant, CanExecuteDeleteChangePlant));
            }
        }

        private bool CanExecuteDeleteChangePlant(object obj)
        {
            return !Plant.Id.Equals(0);
        }

        private void ExecuteDeletePlant(object obj)
        {
            _companyPlantsService.DeletePlant(Plant.Id);
            PlantsList = _companyPlantsService.GetCompanyPlants();
        }

        RelayCommand _addPlant;
        public RelayCommand AddPlant
        {
            get
            {
                return _addPlant ?? (_addPlant = new RelayCommand(ExecuteAddPlant));
            }
        }

        private void ExecuteAddPlant(object obj)
        {
            NavigationService.Navigate(typeof(ProducerAddNewPlant), _company);
        }

        RelayCommand _changePlant;
        public RelayCommand ChangePlant
        {
            get
            {
                return _changePlant ?? (_changePlant = new RelayCommand(ExecuteChangePlant, CanExecuteDeleteChangePlant));
            }
        }

        private void ExecuteChangePlant(object obj)
        {
            NavigationService.Navigate(typeof(ProducerModifyPlant), _companyPlantsService.GetPLantById(Plant.Id));
        }
    }
}

