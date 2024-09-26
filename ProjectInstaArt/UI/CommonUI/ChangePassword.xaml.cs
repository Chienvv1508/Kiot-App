using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServiceImplements;
using ProjectInstaArt.Services.ServicesContracts;
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

namespace ProjectInstaArt.UI.CommonUI
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {  
        }

        private void UpdateUser(User user)
        {
            try
            {
                InstaArtVer3Context db = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(db);
                IUserServicecs userService = new UserService(unitOfWork);
                userService.UpdateUser(user);
                MessageBox.Show("Thay đổi mật khẩu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thay đổi mật khẩu thất bại!");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string oldPass = txtPassWord.Password;
            string newPass = txtNewPassWord.Password;
            string confirmPass = txtConfirmPassWord.Password;
            User user = Login.staticUser;
            if (PrimitiveValueValidation.CheckPassword(txtPassWord.Password))
            {
                if (oldPass.Equals(user.Password))
                {

                    if (PrimitiveValueValidation.CheckPassword(newPass))
                    {
                        if (confirmPass.Equals(newPass))
                        {
                            user.Password = newPass;
                            UpdateUser(user);
                        }
                        else MessageBox.Show("Nhập lại mật khẩu mới không đúng!");
                    }
                    else MessageBox.Show("Mật khẩu mới nhập không đúng định dạng:\n+ Độ dài > 8\n+ Chứa ít nhất 1 chữ viết thường, 1 chữ viết hoa, 1 số, 1 ký tự đặc biệt!");
                   
                }
                else MessageBox.Show("Mật khẩu cũ nhập không đúng!");
            }
            else
                MessageBox.Show("Mật khẩu cũ nhập không đúng định dạng:\n+ Độ dài > 8\n+ Chứa ít nhất 1 chữ viết thường, 1 chữ viết hoa, 1 số, 1 ký tự đặc biệt!");

        }
    }
}
