using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Repositories
{
    public class ImportRepository : GenericRepository<Import>, IImportRepository
    {
        public ImportRepository(InstaArtVer3Context dbContext) : base(dbContext)
        {
        }
    }
}
