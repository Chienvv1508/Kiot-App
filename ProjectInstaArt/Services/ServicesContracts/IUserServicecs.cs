using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    public interface IUserServicecs
    {
        List<User> GetAllUsers();
        User GetUserByUserName(string userName);
        void UpdateUser(User user);
    }
}
