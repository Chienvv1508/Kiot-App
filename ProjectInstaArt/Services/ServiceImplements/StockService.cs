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
    internal class StockService : IStockService
    {
        private IUnitOfWork _unitOfWork;

        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Stock> GetAllStocks()
        {
            List<Stock> result = _unitOfWork.StockRepository.GetAll( x => x.Quantity > 0).ToList();
               
            foreach(var item in result)
            {
                item.ImportDetail = _unitOfWork.ImportDetailRepository.Get( x=> x.ImportDetailId == item.ImportDetailId );
                item.ProductCodeNavigation = _unitOfWork.ProductRepository.Get(x => x.ProductCode == item.ProductCode);
                item.Unit = _unitOfWork.UnitRepository.Get(x => x.UnitId == item.UnitId);
            }

            return result;
        }

        public Stock GetStock(Expression<Func<Stock, bool>> expression)
        {
           return _unitOfWork.StockRepository.Get(expression);
           
        }

        public void InserStock(Stock stock)
        {
            _unitOfWork.StockRepository.Add(stock);
            _unitOfWork.Commit();
        }

        public void UpdateStock(Stock stock)
        {
            _unitOfWork.StockRepository.Update(stock);
            _unitOfWork.Commit();
        }
    }
}
