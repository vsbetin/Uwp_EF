using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Repositories;
using TermWorkDatabases.Models.DataAccess.Repositories.Plants;
using TermWorkDatabases.Models.Enteties;
using TermWorkDatabases.Models.Services.Interfaces.Companies;

namespace TermWorkDatabases.Models.Services.Companies
{
    public class CompanyPlantsService : ICompanyPlantsService
    {
        Company _company;

        public CompanyPlantsService(Company company)
        {
            _company = company;
        }

        IPlantsInfoRepository _plantsInfoRepository;
        IPlantsInfoRepository PlantsInfoRepository
        {
            get
            {
                return _plantsInfoRepository ?? (_plantsInfoRepository = new PlantsInfoRepository());
            }
        }

        public bool AddPlant(string plantName)
        {
            Plant plant = new Plant { Name = plantName, Company = _company, IsFree = true };
            var result = PlantsInfoRepository.AddPlant(plant);
            PlantsInfoRepository.SaveChages();
            return result;
        }

        public bool ChangePlantName(int plantId, string newName)
        {
            var result = PlantsInfoRepository.ChangePlantName(PlantsInfoRepository.GetPlantById(plantId), newName);
            PlantsInfoRepository.SaveChages();
            return result;
        }

        public void DeletePlant(int plantId)
        {
            PlantsInfoRepository.DeletePlant(PlantsInfoRepository.GetPlantById(plantId));
            PlantsInfoRepository.SaveChages();
        }

        public List<(int PlantId, string PlantName)> GetCompanyPlants()
        {
            return PlantsInfoRepository.GetCompanyPlants(_company).
                Select<Plant, (int PlantId, string PlantName)>
                (plant => (plant.Id, plant.Name)).
                ToList();                
        }

        public Plant GetPLantById(int PlantId)
        {
            return PlantsInfoRepository.GetPlantById(PlantId);
        }
    }
}
