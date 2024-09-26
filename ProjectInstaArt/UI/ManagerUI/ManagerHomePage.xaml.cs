                using ProjectInstaArt.UI.CommonUI;
using ProjectInstaArt.UI.ManagerUI.PriceUI;
using ProjectInstaArt.UI.ManagerUI.ProductUI;
using ProjectInstaArt.UI.ManagerUI.RevenueStatistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace ProjectInstaArt.UI.ManagerUI
{
    /// <summary>
    /// Interaction logic for ManagerHomePage.xaml
    /// </summary>
    public partial class ManagerHomePage : Window
    {
        public ManagerHomePage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AssignOptions();
            child.Children.Add( new RevenueStatistics());
        }

        private void AssignOptions()
        {
            List<dynamic> options = new List<dynamic>();
            options.Add(new { Id = 0, Name = "Options" });
            options.Add(new { Id = 1, Name = "Thông Tin" });
            options.Add(new { Id = 2, Name = "Thay Đổi Thông Tin" });
            options.Add(new { Id = 3, Name = "Đăng Xuất" });
            cbOptions.SelectedValuePath = "Id";
            cbOptions.DisplayMemberPath = "Name";
            cbOptions.ItemsSource = options;
            cbOptions.SelectedIndex = 0;
        }

        private void cbOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int option = (int)cbOptions.SelectedValue;
            switch (option)
            {
                case 1:
                    InformationForm informationForm = new InformationForm();
                    this.Hide();
                    informationForm.Show();
                    informationForm.Closed += OpenManagerHomePage;
                    break;
                case 2:
                    InformationChanging informationChanging = new InformationChanging();
                    this.Hide();
                    informationChanging.Show();
                    informationChanging.Closed += OpenManagerHomePage;
                    break;
                case 3:
                    this.Close();
                    Login.staticUser = null;
                    break;


            }
        }

        private void OpenManagerHomePage(object? sender, EventArgs e)
        {
            this.Show();
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            StockUI.StockManagement stockUI = new ManagerUI.StockUI.StockManagement();
            stockUI.Show();
            this.Hide();
            stockUI.Closed += OpenManagerHomPage;
        }

       

        private void btnImport_Click_1(object sender, RoutedEventArgs e)
        {
            ImportUI.ImportUI importUI = new ImportUI.ImportUI();
            importUI.Show();
            this.Hide();
            importUI.Closed += OpenManagerHomPage;
        }

        private void OpenManagerHomPage(object? sender, EventArgs e)
        {
            this.Show();
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            AddProduct productManagement = new AddProduct();
            productManagement.Show();
            productManagement.Closed += OpenManagerHomePage;
        }

        private void btnPriceSetting_Click(object sender, RoutedEventArgs e)
        {
            PriceSettingManagement priceManagementUI = new PriceSettingManagement();
            priceManagementUI.Show();
            priceManagementUI.Closed += OpenManagerHomePage;
        }
    }
}
