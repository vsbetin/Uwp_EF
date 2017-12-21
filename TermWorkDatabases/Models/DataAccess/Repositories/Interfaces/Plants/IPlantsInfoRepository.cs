using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    interface IPlantsInfoRepository : ISaveChanges
    {
        List<Plant> GetCompanyPlants(Company company);
        Plant GetPlantById(int id);
        Plant GetPlantByName(string name);
        bool ChangePlantName(Plant plant, string name);
        bool AddPlant(Plant plant);
        void DeletePlant(Plant plant);
    }
}
