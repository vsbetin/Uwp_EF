using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    interface ICustomerInfoRepository : ICustomerRepository
    {
        void ChangeCustomerName(Customer customer ,string name);
        bool ChangeCustomerLogin(Customer customer, string login);
        void ChangeCustomerMobileNumber(Customer customer, string mobileNumber);
        bool ChangeCustomerPassword(Customer customer, string OldPassword, string newPassword);
        int GetDuringOrdersCount(Customer customer);
        int GetFinishedOrdersCount(Customer customer);
    }
}
