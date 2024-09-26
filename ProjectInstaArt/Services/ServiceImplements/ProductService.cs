using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServicesContracts;
using ProjectInstaArt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ProjectInstaArt.Services.ServiceImplements
{
    class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddProduct(Product product)
        {
            unitOfWork.ProductRepository.Add(product);
            unitOfWork.Commit();
        }

        public List<Product> GetAllProducts()
        {
            return unitOfWork.ProductRepository.GetAll(x => x.IsValid == true ).ToList();
        }

        public Product GetProduct(Expression<Func<Product, bool>> expression)
        {
            return unitOfWork.ProductRepository.Get(expression);
        }

        public Product GetProductById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            var product = unitOfWork.ProductRepository.Get(x => x.ProductCode.Equals(id));
            return product;
        }

        public void UpdateProduct(Product product)
        {
            unitOfWork.ProductRepository.Update(product);
            unitOfWork.Commit();
        }
    }
}
