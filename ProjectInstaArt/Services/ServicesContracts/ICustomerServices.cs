using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    interface ICustomerServices
    {
        Customer GetCustomer(Expression<Func<Customer, bool>> predicate);
        /// <summary>
        /// Search by expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<Customer> GetCustomerList(Expression<Func<Customer, bool>> predicate);

        List<Customer> GetCustomers();

        void CreateCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);
    }
}
