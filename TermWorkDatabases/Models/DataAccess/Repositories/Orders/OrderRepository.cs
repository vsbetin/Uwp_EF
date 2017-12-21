using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermWorkDatabases.Models.DataAccess.Context;
using TermWorkDatabases.Models.Enteties;
using Microsoft.EntityFrameworkCore;

namespace TermWorkDatabases.Models.DataAccess.Repositories.Orders
{
    class OrderRepository : RepositoryBase, IOrderRepository
    {
        public void CancelOrder(Order order)
        {
            OrderDetail ordDet = Context.OrderDetails.
                Include(orderDet => orderDet.Order).
                FirstOrDefault(OrderDetail => object.ReferenceEquals(OrderDetail.Order, order));
            if (ordDet != null)
                Context.OrderDetails.Remove(ordDet);
            Context.Orders.Remove(order);
        }

        public Order GetOrder(int id)
        {
            return Context.Orders.
                Include(order => order.CompanieProduct).
                Include(order => order.CompanieProduct.Company).
                Include(order => order.Customer).
                FirstOrDefault(order => order.Id.Equals(id));
        }

        public void SaveChages()
        {
            Context.SaveChanges();
        }
    }
}
