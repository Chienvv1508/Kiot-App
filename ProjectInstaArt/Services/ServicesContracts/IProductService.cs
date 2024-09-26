using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    interface IProductService
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(string id);
        void UpdateProduct(Product product);

        Product GetProduct (Expression<Func<Product, bool>> expression);    
    }
}
