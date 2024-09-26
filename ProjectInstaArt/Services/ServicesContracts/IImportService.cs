using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    internal interface IImportService
    {
        List<Import> GetAllImport();

        void InsertImport(Import import);

       
       
    }
}
