using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Services.Interfaces.Companies
{
    interface ICompanyInfoService
    {
        (string Name, string MobileNumber, int DuringOrders, int CompletedOrders) GetCompanyInfo();
        bool ChangeCompanyPassword(string oldPassword, string newPassword);
        bool ChangeCompanyInfo(string login, string name, string mobilePhone);
    }
}
