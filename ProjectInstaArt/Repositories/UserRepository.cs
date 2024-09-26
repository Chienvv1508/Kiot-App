using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Repositories
{
    class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(InstaArtVer3Context dbContext) : base(dbContext)
        {
        }
    }
}
