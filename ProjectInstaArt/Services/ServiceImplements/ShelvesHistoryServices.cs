using ProjectInstaArt.Contracts;
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
    public class ShelvesHistoryServices : IShelvesHistoryServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShelvesHistoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ShelvesHistory GetShelfHistory(Expression<Func<ShelvesHistory, bool>> expression)
        {
            return _unitOfWork.ShelvesHistoryRepository.Get(expression);
        }

        public void Insert(ShelvesHistory shelvesHistory)
        {
            _unitOfWork.ShelvesHistoryRepository.Add(shelvesHistory);
            _unitOfWork.Commit();
        }
    }
}
