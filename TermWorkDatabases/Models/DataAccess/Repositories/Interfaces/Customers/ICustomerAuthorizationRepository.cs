using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    interface ICustomerAuthorizationRepository : ISaveChanges
    {
        Customer GetCustomer(string login);
        bool CheckPassword(Customer company, string password);
        bool AddCustomer(Customer company, CustomerAccessData customerAccessData);
    }
}
