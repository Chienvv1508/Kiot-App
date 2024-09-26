using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(InstaArtVer3Context dbContext) : base(dbContext)
        {
        }
    }
}
