using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    public interface IShelvesHistoryServices
    {
        ShelvesHistory GetShelfHistory(Expression<Func<ShelvesHistory,bool>> expression);
        void Insert(ShelvesHistory shelvesHistory);
    }
}
