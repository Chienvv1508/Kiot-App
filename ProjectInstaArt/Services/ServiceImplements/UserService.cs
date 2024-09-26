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
    class UserService : IUserServicecs
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUserByUserName(string userName)
        {
            return _unitOfWork.UserRepository.Get(x => x.UserName == userName);
        }
        public void UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();
        }

     

        List<User> IUserServicecs.GetAllUsers()
        {
            return _unitOfWork.UserRepository.GetAll(x => x.IsValid == true).ToList();
        }
    }
}
