using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Services.Interfaces.Customers
{
    interface ICustomerInfoService
    {
        (string Name, string MobileNumber, int DuringOrders, int CompletedOrders) GetCustomerInfo();
        bool ChangeCustomerPassword(string oldPassword, string newPassword);
        bool ChangeCustomerInfo(string login, string name, string mobilePhone);
    }
}
