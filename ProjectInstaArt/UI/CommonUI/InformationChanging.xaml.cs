using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServiceImplements;
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
    /// Interaction logic for InformationChanging.xaml
    /// </summary>
    public partial class InformationChanging : Window
    {
        
        public InformationChanging()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            this.Hide();
            changePassword.Show();
            changePassword.Closed += OpenInFormationChanging;
        }

        private void OpenInFormationChanging(object? sender, EventArgs e)
        {
            this.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AssignChangeInfo();
        }

        private void AssignChangeInfo()
        {
            if(Login.staticUser != null)
            {
                txtLastName.Text = Login.staticUser.LastName;
                txtFirstName.Text = Login.staticUser.FirstName;
                txtPhone.Text = Login.staticUser.Phone;
                //txtAdrress.Text = Login.staticUser.Adrress;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //User oldUser = Login.staticUser;
            //User newInfo = GetInfoFromForm();
            //if(newInfo != null)
            //{
            //    oldUser.FirstName = newInfo.FirstName;
            //    oldUser.LastName = newInfo.LastName;
            //    oldUser.Phone = newInfo.Phone;
            //    oldUser.Adrress = newInfo.Adrress;
            //    InstaArtVer2Context db = new InstaArtVer2Context();
            //    IUnitOfWork unitOfWork = new UnitOfWork(db);
            //    UserService userService = new UserService(unitOfWork);
            //    try
            //    {
            //        userService.UpdateUser(oldUser);
            //        MessageBox.Show("Thay đổi thành công!");
            //        Login.staticUser = oldUser;
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show("Chưa thay đổi được");
            //    }
               
                
            //}

        }

        private User GetInfoFromForm()
        {
            User newUser = null;
           //if(!PrimitiveValueValidation.CheckName(txtLastName.Text)) 
           // {
           //     MessageBox.Show("Họ chưa đúng định dạng");
           //     return null;
           // }
           // if (!PrimitiveValueValidation.CheckName(txtFirstName.Text))
           // {
           //     MessageBox.Show("Tên chưa đúng định dạng");
           //     return null;
           // }
           // if (!PrimitiveValueValidation.CheckPhone(txtPhone.Text))
           // {
           //     MessageBox.Show("Số điện thoại chưa đúng định dạng");
           //     return null;
           // }
           // if (!PrimitiveValueValidation.CheckAddress(txtAdrress.Text))
           // {
           //     MessageBox.Show("Địa chỉ chưa đúng định dạng");
           //     return null;
           // }
           // newUser = new User();
           // newUser.LastName = txtLastName.Text;
           // newUser.FirstName = txtFirstName.Text;
           // newUser.Phone = txtPhone.Text;
           // newUser.Adrress = txtAdrress.Text;

            return newUser;
        }
    }
}
