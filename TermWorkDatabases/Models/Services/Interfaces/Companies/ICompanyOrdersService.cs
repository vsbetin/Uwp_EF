using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.Services.Interfaces.Companies
{
    interface ICompanyOrdersService
    {
        void ConfirmNewOrder(int OrderId, int PlantId, DateTime StartPlantWork, DateTime FinishPlantWork);
        void FinishOrder(int OrderId);
        List<(int PlantId, string PlantName)> GetPlants();
        List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetNewOrders();
        List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetNewOrdersByCustomer(string customerName);
        List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetDuringOrders();
        List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetDuringOrdersByCustomer(string customerName);
        List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetCompletedOrders();
        List<(int OrderId, string ProductName, string CustomerName, string FinishDate, int Count, double Cost)> GetCompletedOrdersByCustomer(string customerName);
        void DeleteOrder(int OorderId);
        Order GetOrderById(int id);
    }
}
