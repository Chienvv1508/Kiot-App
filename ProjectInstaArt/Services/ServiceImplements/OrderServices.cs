using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectInstaArt.Services.ServiceImplements
{
    class OrderServices : IOrderServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateOrder(Order order)
        {
            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.Commit();
        }

        public void DeleteOrder(Order order)
        {
            _unitOfWork.OrderRepository.Remove(order);
            _unitOfWork.Commit();
        }

        public Order GetOrder(Expression<Func<Order, bool>> expression)
        {
            var order = _unitOfWork.OrderRepository.Get(expression);
            if(order != null)
            {
                if (!string.IsNullOrEmpty(order.Customer))
                {
                    var customer = _unitOfWork.CustomerRepository.Get(x => x.Phone == order.Customer);
                    if(customer != null)
                    order.CustomerNavigation = customer;
                }
                
            }
            return order;
            
        }

        public List<Order> GetOrders(Expression<Func<Order, bool>> expression)
        {
            var listOrder = _unitOfWork.OrderRepository.GetAll(expression).ToList();
            if(listOrder != null)
            {
                foreach(var order in listOrder)
                {
                    if (!string.IsNullOrEmpty(order.Customer))
                    {
                        order.CustomerNavigation = _unitOfWork.CustomerRepository.Get(x => x.Phone == order.Customer);

                    }
                }
            }
            return listOrder;
        }

        public List<Order> GetOrders()
        {
            var listOrder = _unitOfWork.OrderRepository.GetAll().ToList();
            if (listOrder != null)
            {
                foreach (var order in listOrder)
                {
                    if (!string.IsNullOrEmpty(order.Customer))
                    {
                        order.CustomerNavigation = _unitOfWork.CustomerRepository.Get(x => x.Phone == order.Customer);

                    }
                }
            }
            return listOrder;
        }

        public void UpdateOrder(Order order)
        {
            _unitOfWork.OrderRepository.Update(order);
            _unitOfWork.Commit();
        }
    }
}
