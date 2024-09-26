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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectInstaArt.UI.ManagerUI.RevenueStatistic
{
    /// <summary>
    /// Interaction logic for RevenueStatistics.xaml
    /// </summary>

   
    public partial class RevenueStatistics : UserControl
    {
        List<OrderDetail> orderDetails;
        public RevenueStatistics()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IOrderDetailServices orderDetailServices = new OrderDetailServices(unitOfWork);

            orderDetails = orderDetailServices.GetOrders();
            dtFrom.SelectedDate = DateTime.MinValue.Date;
            dtTo.SelectedDate = DateTime.MaxValue.Date;
            FillStatistics(orderDetails, DateTime.MinValue.Date, DateTime.MaxValue.Date);
        }

        private void FillStatistics(List<OrderDetail> orderDetails, DateTime date1, DateTime date2)
        {
            if(orderDetails != null)
            {
                if(date1 <= date2)
                {
                    var localOrderDetails = orderDetails.Where(x => x.Order.Date >= date1 && x.Order.Date <= date2).ToList();
                    if (localOrderDetails != null)
                    {
                        decimal total = 0;
                        int quantity = 0;
                        foreach (var orderDetail in localOrderDetails)
                        {
                            total += orderDetail.Quantity * orderDetail.Price;
                            quantity += orderDetail.Quantity;
                        }
                        txtTotal.Text = "Tổng doang thu: " + total.ToString();
                        txtItem.Text = "Tổng sản phẩm bán được: " + quantity.ToString();

                    }
                }
                else
                {
                    txtTotal.Text = "Tổng doang thu: 0";
                    txtItem.Text = "Tổng sản phẩm bán được: 0";
                }
            }
            else
            {
                txtTotal.Text = "Tổng doang thu: 0" ;
                txtItem.Text = "Tổng sản phẩm bán được: 0";
            }
        }

        private void dtFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date1 = (DateTime)dtFrom.SelectedDate;
            DateTime date2 = (DateTime)(dtTo.SelectedDate == null? DateTime.MaxValue.Date: dtTo.SelectedDate);
            FillStatistics(orderDetails, date1, date2);
        }

        private void dtTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date1 = (DateTime)dtFrom.SelectedDate;
            DateTime date2 = (DateTime)dtTo.SelectedDate;
            FillStatistics(orderDetails, date1, date2);
        }
    }
}
