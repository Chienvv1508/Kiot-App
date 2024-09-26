using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServiceImplements;
using ProjectInstaArt.Services.ServicesContracts;
using ProjectInstaArt.UI.ManagerUI;
using ProjectInstaArt.UI.ManagerUI.SaleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps;

namespace ProjectInstaArt.UI.CommonUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static User staticUser;
        public List<User> users = new List<User>();
        public Login()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            InstaArtVer3Context db = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(db);
            IUserServicecs userService = new UserService(unitOfWork);

            users = userService.GetAllUsers();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = GetUser();
            if (user != null)
            {
                if (CheckExistUser(user))
                {
                    if (CheckPassWord(user))
                    {
                        OpenHomePage();
                    }
                    else MessageBox.Show("Mật khẩu sai!");
                }
                else MessageBox.Show("Tên đăng nhập sai!");
            }
        }

        private void OpenHomePage()
        {
           if(staticUser != null)
            {
                InstaArtVer3Context db = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(db);
                RoleService roleService = new RoleService(unitOfWork);
                Role userRole = roleService.GetRoleById(staticUser.RoleId);
                if (userRole.RoleName.ToLower().Equals(RoleName.Saler.ToString().ToLower()))
                {
                    SaleHomePage saleHomePage = new SaleHomePage();
                    saleHomePage.Show();
                    this.Hide();
                    saleHomePage.Closed += OpenLogin;
                }
                else
                {
                    ManagerHomePage managerHomePage = new ManagerHomePage();
                    managerHomePage.Show();
                    this.Hide();
                    managerHomePage.Closed += OpenLogin;

                }
            }
        }

        private bool CheckPassWord(User user)
        {
           if(user != null && staticUser != null)
            {
                if (staticUser.Password == user.Password)
                {
                    return true;
                }
                else
                    staticUser = null;
            }
            return false;
        }

        private bool CheckExistUser(User user)
        {
            if(user != null && users != null)
            { staticUser = users.FirstOrDefault(x => x.UserName == user.UserName);
                if (staticUser != null)
                {
                    return true;
                }
                    
            }
            return false;
        }

        private User GetUser()
        {
            string userName = txtUserName.Text;
            string password = txtPassWord.Password;
            User user = new User();
            user.UserName = userName;
            user.Password = password;
            return user;
        }

       

        private void OpenLogin(object? sender, EventArgs e)
        {
            staticUser = null;
            txtUserName.Text = null;
            txtPassWord.Password = null;
            this.Show();
        }
    }
}
