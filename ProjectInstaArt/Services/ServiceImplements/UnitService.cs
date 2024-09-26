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
    internal class UnitService : IUnitService
    {
        private IUnitOfWork _unitOfWork;

        public UnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteUnit(Unit unit)
        {
            throw new NotImplementedException();
        }

        public List<Unit> GetAllUnit()
        {
            return _unitOfWork.UnitRepository.GetAll(x => x.IsValid == true).ToList();
        }

        public List<Unit> GetAllUnit(Expression<Func<Unit, bool>> expression)

        {
            
            var list = _unitOfWork.UnitRepository.GetAll(expression).ToList();
            if(list != null)
            {
                return list.Where(x => x.IsValid == true).ToList();
            }
            return null;
        }

        public List<Unit> GetAllUnitByProductCode(string productCode)
        {
            return _unitOfWork.UnitRepository.GetAll(x => x.ProductCode.Equals(productCode)).ToList();
        }

      

        public Unit GetUnitById(long id)
        {
            return _unitOfWork.UnitRepository.Get(x => x.UnitId == id);
        }

        public void InsertUnit(Unit unit)
        {
            _unitOfWork.UnitRepository.Add(unit);
            _unitOfWork.Commit();
        }

        public void Update(Unit unit)
        {
            _unitOfWork.UnitRepository.Update(unit);
            _unitOfWork.Commit();
        }
    }
}
