using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    internal interface IStockService
    {
        List<Stock> GetAllStocks();
        Stock GetStock(Expression<Func<Stock,bool>> expression);
        void InserStock(Stock stock);
        void UpdateStock(Stock stock);
    }
}
