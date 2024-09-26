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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Role GetRoleById(int id)
        {
            return unitOfWork.RoleRepository.Get(x => x.RoleId == id);
        }
    }
}
