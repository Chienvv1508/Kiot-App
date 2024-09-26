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
    class CustomerServices : ICustomerServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCustomer(Customer customer)
        {
           _unitOfWork.CustomerRepository.Add(customer);
            _unitOfWork.Commit();
        }

        public void DeleteCustomer(Customer customer)
        {
            _unitOfWork.CustomerRepository.Remove(customer);
            _unitOfWork.Commit();
        }

        public Customer GetCustomer(Expression<Func<Customer, bool>> predicate)
        {
            return _unitOfWork.CustomerRepository.Get(predicate);
        }

        public List<Customer> GetCustomerList(Expression<Func<Customer, bool>> predicate)
        {
            return _unitOfWork.CustomerRepository.GetAll(predicate).ToList();
        }

        public List<Customer> GetCustomers()
        {
            return _unitOfWork.CustomerRepository.GetAll().ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            _unitOfWork.CustomerRepository.Update(customer);
            _unitOfWork.Commit();
        }
    }
}
