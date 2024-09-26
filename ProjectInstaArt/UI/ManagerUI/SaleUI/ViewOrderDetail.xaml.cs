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
    /// Interaction logic for ViewOrderDetail.xaml
    /// </summary>
    public partial class ViewOrderDetail : Window
    {
        long orderId;
        List<OrderDetail> orderDetails;
        

        public ViewOrderDetail(long _orderId)
        {
            this.orderId = _orderId;
            InitializeComponent();
            LoadData();
        }

        public ViewOrderDetail()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IOrderDetailServices orderDetailServices = new OrderDetailServices(unitOfWork);
            orderDetails = orderDetailServices.GetOrders(x => x.OrderId == orderId);

            lvOrderDetail.ItemsSource = null;
            lvOrderDetail.ItemsSource = orderDetails;

            decimal total = 0;

            foreach (OrderDetail detail in orderDetails)
            {
                total += detail.Price * detail.Quantity;
            }
            txtTotal.Text = "Tổng tiền:   " + total.ToString();

            
            
                 
        }
    }
}
