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
    class ShelvesServices : IShelvesServices
    {
        private IUnitOfWork _unitOfWork;
        public ShelvesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Shelf GetShelf(Expression<Func<Shelf, bool>> expression)
        {
            return _unitOfWork.ShelvesRepository.Get(expression);
        }

        public List<Shelf> GetShelves()
        {
            var x = _unitOfWork.ShelvesRepository.GetAll(x => x.Quantity > 0).ToList();
            foreach(var shelf in x)
            {
                shelf.ProductCodeNavigation = _unitOfWork.ProductRepository.Get(x => x.ProductCode == shelf.ProductCode);



            }
            return x;
        }

        public List<Shelf> GetShelves(Expression<Func<Shelf, bool>> expression)
        {
            return _unitOfWork.ShelvesRepository.GetAll(expression).ToList();
        }

        public void Insert(Shelf shelf)
        {
            _unitOfWork.ShelvesRepository.Add(shelf);
            _unitOfWork.Commit();
        }

        public void Update(Shelf existedShelf)
        {
            _unitOfWork.ShelvesRepository.Update(existedShelf);
            _unitOfWork.Commit();
        }
    }
}
