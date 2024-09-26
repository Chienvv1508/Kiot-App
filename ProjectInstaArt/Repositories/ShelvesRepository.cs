using ProjectInstaArt.Contracts;
using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Repositories
{
  public  class ShelvesRepository : GenericRepository<Shelf>, IShelvesRepository
    {
        public ShelvesRepository(InstaArtVer3Context dbContext) : base(dbContext)
        {
        }
    }
}
