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

namespace ProjectInstaArt.UI.ManagerUI.StockUI
{
    /// <summary>
    /// Interaction logic for TearUnit.xaml
    /// </summary>
    public partial class TearUnit : Window
    {
        string productCode, importDetailId;
        long unitId;
        public TearUnit()
        {
            InitializeComponent();
        }

      

        public TearUnit(string productCode, string importDetailId, long unitId) : this()
        {
            this.productCode = productCode;
            this.importDetailId = importDetailId;
            this.unitId = unitId;
            LoadDate(productCode);
        }

        private void LoadDate(string productCode)
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IUnitService unitService = new UnitService(unitOfWork);

            List<Unit> units = unitService.GetAllUnit(x => x.ProductCode == productCode);
            cbUnit.ItemsSource = units;
            txtUnit.Text = units.FirstOrDefault(x => x.UnitId == unitId) == null ? "" : units.FirstOrDefault(x => x.UnitId == unitId).UnitName ;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Stock stock = GetStock();
            if(stock != null)
            {
                int quantity;
                if (int.TryParse(txtQuantity.Text, out quantity))
                {
                    if (quantity <= stock.Quantity)
                    {
                        if (CheckChange(stock.UnitId))
                        {
                            if(ChangeUnit(stock, quantity))
                            {
                                MessageBox.Show("Xé Hàng Thành Công!");
                                this.Close();
                            }
                            else {
                                MessageBox.Show("Xé Hàng Lỗi!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hai đơn vị này không quy đổi được cho nhau");
                        }
                    }
                    else MessageBox.Show("Số đơn vị vượt quá trong kho");
                }
                else
                {
                    MessageBox.Show("Nhập đơn vị là số");

                }
            }
           
        }

        private bool ChangeUnit(Stock stock, int quantity)
        {
            if (stock != null)
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                var transaction = context.Database.BeginTransaction();
                try
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    IStockService stockService = new StockService(unitOfWork);
                    IUnitService unitService = new UnitService(unitOfWork);
                    stock = stockService.GetStock(x => x.StockId == stock.StockId);

                    if (stockService.GetStock(x => x.StockId == stock.StockId) != null)
                    {
                        Unit unitSelected = (Unit)cbUnit.SelectedItem;
                        if (unitSelected != null)
                        {
                            unitSelected = unitService.GetUnitById(unitSelected.UnitId);
                            if (unitSelected != null)
                            {
                                stock.Quantity -= quantity;
                                var stock2 = stockService.GetStock(x => x.ProductCode == stock.ProductCode
                                && x.ImportDetailId == stock.ImportDetailId && x.UnitId == unitSelected.UnitId);
                                if (stock2 != null)
                                {
                                    stock2.Quantity += quantity * unitService.GetUnitById(stock.UnitId).Quantity / unitSelected.Quantity;
                                    stockService.UpdateStock(stock);
                                    stockService.UpdateStock(stock2);

                                }
                                else
                                {
                                    Stock newStock = new Stock();
                                    newStock.StockId = GenerateStockId();
                                    newStock.ProductCode = stock.ProductCode;
                                    newStock.ImportDetailId = stock.ImportDetailId;
                                    newStock.UnitId = unitSelected.UnitId;
                                    newStock.Quantity = quantity * unitService.GetUnitById(stock.UnitId).Quantity / unitSelected.Quantity;
                                    stockService.UpdateStock(stock);
                                    stockService.InserStock(newStock);
                                }
                            }

                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch(Exception)
                {
                    transaction.Rollback();
                    return false;
                }
               
                
            }
            return false;

        }

        private string GenerateStockId()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IStockService stockService = new StockService(unitOfWork);
            string stockId;
            while (true)
            {
                stockId = GenerateId(50);
                if(stockService.GetStock(x => x.StockId == stockId) == null)
                {
                    break;
                }
            }
            return stockId;
        }
        private string GenerateId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool CheckChange(long unitId)
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IUnitService unitService = new UnitService(unitOfWork);

            var unit = unitService.GetUnitById(unitId);
            if(unit != null)
            {
                Unit unitSelected = (Unit)cbUnit.SelectedItem;
                if(unitSelected != null)
                {
                    unitSelected = unitService.GetUnitById(unitSelected.UnitId);
                    if (unit.Quantity == (unit.Quantity / unitSelected.Quantity) * unitSelected.Quantity)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            return false;
        }

        private Stock GetStock()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IStockService stockService = new StockService(unitOfWork);

            return stockService.GetStock(x => x.ProductCode == productCode && x.ImportDetailId == importDetailId && x.UnitId == unitId);

        }
    }
}
