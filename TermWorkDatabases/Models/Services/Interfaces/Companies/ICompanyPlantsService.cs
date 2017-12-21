using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.Services.Interfaces.Companies
{
    interface ICompanyPlantsService
    {
        List<(int PlantId, string PlantName)> GetCompanyPlants();
        bool ChangePlantName(int plantId, string newName);
        bool AddPlant(string plantName);
        void DeletePlant(int plantId);
        Plant GetPLantById(int PlantId);
    }
}
