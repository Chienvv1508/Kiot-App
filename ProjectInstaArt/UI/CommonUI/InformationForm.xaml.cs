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
    /// Interaction logic for InformationForm.xaml
    /// </summary>
    public partial class InformationForm : Window
    {
        public InformationForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AssignChangeInfo();
        }

        private void AssignChangeInfo()
        {
            if (Login.staticUser != null)
            {
                txtLastName.Text = Login.staticUser.LastName;
                txtFirstName.Text = Login.staticUser.FirstName;
                txtPhone.Text = Login.staticUser.Phone;
                //txtAdrress.Text = Login.staticUser.Adrress;
            }
        }
    }
}
