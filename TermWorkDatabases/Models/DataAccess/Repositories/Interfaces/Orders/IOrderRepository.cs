using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.Enteties;

namespace TermWorkDatabases.Models.DataAccess.Repositories
{
    interface IOrderRepository : ISaveChanges
    {
        void CancelOrder(Order order);
        Order GetOrder(int id);
    }
}
