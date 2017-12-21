using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    public interface ICustomerRepository : ISaveChanges
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(string name);
        Customer GetCustomer(int id);
    }
}
