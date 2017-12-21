using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.Services.Interfaces
{
    interface IAuthorizationService
    {
        Company SignInCompany(string login, string password);
        Company SignUpCompany(string name, string login, string mobilePhone, string email, string paswword);
        Customer SignInCustomer(string login, string password);
        Customer SignUpCustomer(string name, string login, string mobilePhone, string email, string paswword);
    }
}
