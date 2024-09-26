using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServiceImplements;
using ProjectInstaArt.Services.ServicesContracts;
using ProjectInstaArt.UI.ManagerUI.ShelvesUI;
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

namespace ProjectInstaArt.UI.ManagerUI.StockUI
{
    /// <summary>
    /// Interaction logic for StockManagement.xaml
    /// </summary>
    public partial class StockManagement : Window
    {
        List<Tuple<Stock, bool>> stocks = new List<Tuple<Stock, bool>>();

        public StockManagement()
        {
            InitializeComponent();
            ProcessData();
            LoadData();
        }

        private void LoadData()
        {
            lvStock.ItemsSource = stocks;
        }

        private void ProcessData()
        {
           InstaArtVer3Context context = new InstaArtVer3Context();
           IUnitOfWork unitOfWork = new UnitOfWork(context);
           IStockService stockService = new StockService(unitOfWork);
          
           var stocksLocalParameter = stockService.GetAllStocks();
            foreach(var stock in stocksLocalParameter)
            {
                var timeSpan = stock.ImportDetail.ExpiredDate - stock.ImportDetail.ManufactureDate;
                var timeSpanNow = DateTime.Now - stock.ImportDetail.ManufactureDate;
                
                if (timeSpanNow/timeSpan > 0.8)
                {
                    

                    stocks.Add(new Tuple<Stock, bool>(stock, true));
                }else
                    stocks.Add(new Tuple<Stock, bool>(stock, false));

            }


        }

        private void AdjustShelves(object sender, RoutedEventArgs e)
        {
            Tuple<Stock, bool> selectedStock = (Tuple<Stock, bool>)lvStock.SelectedItem;
            if(selectedStock != null)
            {
                MessageBox.Show($"{selectedStock.Item1.ProductCode}");
            }
            
        }

       

      

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            string productText = txtSearch.Text;
            bool isIsExpiringSoon = (bool)ckIsExpiringSoon.IsChecked;

            if (productText == "" && isIsExpiringSoon == false)
            {
                lvStock.ItemsSource = stocks;
            }
            if (productText == "" && isIsExpiringSoon == true)
            {
                
                lvStock.ItemsSource = stocks.Where(x => x.Item2 == true);
                return;
            }
            if (isIsExpiringSoon == false)
            {
                
                lvStock.ItemsSource = stocks.Where(x => x.Item1.ProductCodeNavigation.ProductCode.Contains(productText) ||
                x.Item1.ProductCodeNavigation.ProductName.Contains(productText));
            }
            else
            {
                
                lvStock.ItemsSource = stocks.Where(x => x.Item1.ProductCodeNavigation.ProductCode.Contains(productText) ||
                x.Item1.ProductCodeNavigation.ProductName.Contains(productText) && x.Item2 == true);
            }
        }

        private void btnPrice_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            
            Tuple<Stock, bool> selectedItem = clickedButton.DataContext as Tuple<Stock, bool>;
            
            if (selectedItem != null)
            {
                MessageBox.Show($"{selectedItem.Item1.ProductCode}");
            }
        }

        private void btnShelves_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;


            Tuple<Stock, bool> selectedItem = clickedButton.DataContext as Tuple<Stock, bool>;

            if (selectedItem != null)
            {
                ShelvesManagement shelvesManagement = new ShelvesManagement(selectedItem.Item1.ProductCode, selectedItem.Item1.ImportDetailId,selectedItem.Item1.Unit);
                this.Hide();
                shelvesManagement.Show();
                shelvesManagement.Closed += OpenStockManagement;
            }
        }

        private void OpenStockManagement(object? sender, EventArgs e)
        {
            lvStock.ItemsSource = null;
            stocks.Clear();
            ProcessData();
            LoadData();
            this.Show();
        }

        private void btnTear_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;


            Tuple<Stock, bool> selectedItem = clickedButton.DataContext as Tuple<Stock, bool>;

            if (selectedItem != null)
            {
                TearUnit tearUnit = new TearUnit(selectedItem.Item1.ProductCode, selectedItem.Item1.ImportDetailId,selectedItem.Item1.UnitId);
                this.Hide();
                tearUnit.Show();
                tearUnit.Closed += OpenStockManagement;
            }
        }
    }
}
