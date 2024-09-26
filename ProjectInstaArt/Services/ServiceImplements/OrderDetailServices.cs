using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServiceImplements
{
    class OrderDetailServices : IOrderDetailServices
    {
        private IUnitOfWork _unitOfWork;

        public OrderDetailServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            _unitOfWork.OrderDetailRepository.Add(orderDetail);
            _unitOfWork.Commit();
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetOrderDetail(Expression<Func<OrderDetail, bool>> expression)
        {
            return _unitOfWork.OrderDetailRepository.Get(expression);
        }

        public List<OrderDetail> GetOrders(Expression<Func<OrderDetail, bool>> expression)
        {
            var x = _unitOfWork.OrderDetailRepository.GetAll(expression).ToList();
            if (x != null)
            {
                foreach (var item in x)
                {
                    item.ProductCodeNavigation = _unitOfWork.ProductRepository.Get(x => x.ProductCode == item.ProductCode);
                    item.UnitNavigation = _unitOfWork.UnitRepository.Get(x => x.UnitId == item.Unit);
                    item.Order = _unitOfWork.OrderRepository.Get(x => x.OrderId == item.OrderId);
                }
                return x;
            }
            return null;
        }

        public List<OrderDetail> GetOrders()
        {
            var x = _unitOfWork.OrderDetailRepository.GetAll().ToList();
            if(x != null)
            {
                foreach(var item in x)
                {
                    item.ProductCodeNavigation = _unitOfWork.ProductRepository.Get(x => x.ProductCode == item.ProductCode);
                    item.UnitNavigation = _unitOfWork.UnitRepository.Get(x => x.UnitId == item.Unit);
                    item.Order = _unitOfWork.OrderRepository.Get(x => x.OrderId == item.OrderId);
                }
                return x;
            }
            return null;
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
