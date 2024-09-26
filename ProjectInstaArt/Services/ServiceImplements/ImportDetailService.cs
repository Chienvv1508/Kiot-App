using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServicesContracts;
using ProjectInstaArt;
using ProjectInstaArt.Validatation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServiceImplements
{
    class ImportDetailService : IImportDetailService
    {
        private IUnitOfWork _unitOfWork;

        public ImportDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ImportDetail> GetAllImportDetails()
        {
            return _unitOfWork.ImportDetailRepository.GetAll().ToList();
        }

        public void InsertImportDetail(ImportDetail importDetail)
        {
            
                _unitOfWork.ImportDetailRepository.Add(importDetail);
                _unitOfWork.Commit();
                
        }
    }
}
