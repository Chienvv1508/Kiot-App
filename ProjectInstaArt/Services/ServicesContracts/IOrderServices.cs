using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    interface IOrderServices
    {
        Order GetOrder(Expression<Func<Order, bool>> expression);

        List<Order> GetOrders(Expression<Func<Order, bool>> expression);

        List<Order> GetOrders();

        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
