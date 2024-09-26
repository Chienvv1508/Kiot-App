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

namespace ProjectInstaArt.UI.ManagerUI.SaleUI
{
    /// <summary>
    /// Interaction logic for OrderSearchUI.xaml
    /// </summary>
    public partial class OrderSearchUI : Window
    {
        List<Order> orders;
        public OrderSearchUI()
        {
            InitializeComponent();
            LoadData();

        }



        private void LoadData()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IOrderServices orderServices = new OrderServices(unitOfWork);
            orders = orderServices.GetOrders();
            lvOrders.ItemsSource = null;
            lvOrders.ItemsSource = orders;

        }

        private void txtPhone_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string phone = txtPhone.Text;
            List<Order> orderList = orders.Where(x => x.Customer == phone).ToList();
            lvOrders.ItemsSource = null;
            lvOrders.ItemsSource = orderList;

        }

        private void btnViewOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Order order = button.DataContext as Order;
            if(order != null)
            {
                ViewOrderDetail viewOrderDetail = new ViewOrderDetail(order.OrderId);
                viewOrderDetail.Show();
                this.Hide();
                viewOrderDetail.Closed += OpenOrderSearch;
            }
        }

        private void OpenOrderSearch(object? sender, EventArgs e)
        {
            this.Show();
        }
    }
}
