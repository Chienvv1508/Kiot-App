using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServicesContracts;
using ProjectInstaArt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServiceImplements
{
    internal class ImportService : IImportService
    {
        private readonly IUnitOfWork _unitOfWork;

       


        public ImportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Import> GetAllImport()
        {
            return _unitOfWork.ImportRepository.GetAll().ToList();
        }

       

        public void InsertImport(Import import)
        {
                    _unitOfWork.ImportRepository.Add(import);
                    _unitOfWork.Commit();
           
        }

       
    }
}
