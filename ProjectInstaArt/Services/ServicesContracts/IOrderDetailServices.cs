using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    interface IOrderDetailServices
    {
        OrderDetail GetOrderDetail(Expression<Func<OrderDetail, bool>> expression);
        List<OrderDetail> GetOrders(Expression<Func<OrderDetail, bool>> expression);

        List<OrderDetail> GetOrders();

        void CreateOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
    }
}
