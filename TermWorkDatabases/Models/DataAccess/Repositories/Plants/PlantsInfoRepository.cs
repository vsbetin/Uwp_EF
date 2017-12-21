using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Context;
using TermWorkDatabases.Models.Enteties;
using Microsoft.EntityFrameworkCore;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Plants
{
    class PlantsInfoRepository : RepositoryBase, IPlantsInfoRepository
    {
        public bool AddPlant(Plant plant)
        {
            if (plant == null)
                return false;
            if (Context.Plants.
                Include(plnt => plnt.Company).
                FirstOrDefault(plnt => object.ReferenceEquals(plnt.Company, plant.Company) &&
                                       plnt.Name.Equals(plant.Name)) == null)
            {
                Context.Plants.Add(plant);
                return true;
            }
            return false;
        }

        public bool ChangePlantName(Plant plant, string name)
        {
            if (plant == null)
                return false;
            if (Context.Plants.FirstOrDefault(plnt => object.ReferenceEquals(plnt.Company, plant.Company) &&
                                                      plnt.Name.Equals(name)) == null)
            {
                plant.Name = name;
                return true;
            }
            return false;
        }

        public void DeletePlant(Plant plant)
        {
            Context.Plants.Remove(plant);
        }

        public List<Plant> GetCompanyPlants(Company company)
        {
            return Context.Plants.
                Include(plant => plant.Company).
                Where(plant => object.ReferenceEquals(plant.Company, company)).ToList();
        }

        public Plant GetPlantById(int id)
        {
            return Context.Plants.
                Include(plant => plant.Company).
                FirstOrDefault(plant => plant.Id.Equals(id));
        }

        public Plant GetPlantByName(string name)
        {
            return Context.Plants.
                Include(plant => plant.Company).
                FirstOrDefault(plant => plant.Name.Equals(name));
        }

        public void SaveChages()
        {
            Context.SaveChanges();
        }
    }
}
