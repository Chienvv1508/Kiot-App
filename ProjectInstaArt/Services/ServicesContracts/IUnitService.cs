using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    internal interface IUnitService
    {
        List<Unit> GetAllUnitByProductCode(string productCode);
        List<Unit> GetAllUnit();

        Unit GetUnitById(long id);

        void InsertUnit(Unit unit);
        void Update(Unit unit);
        void DeleteUnit(Unit unit);
        List<Unit> GetAllUnit(Expression<Func<Unit, bool>> expression);
    }
}
