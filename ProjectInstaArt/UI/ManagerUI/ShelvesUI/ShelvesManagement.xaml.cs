using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectInstaArt.Contracts;
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

namespace ProjectInstaArt.UI.ManagerUI.ShelvesUI
{
    /// <summary>
    /// Interaction logic for ShelvesManagement.xaml
    /// </summary>
    public partial class ShelvesManagement : Window
    {
        private string importDetailId;
        private string productCode;
        Unit unit;
          
        public ShelvesManagement()
        {
            InitializeComponent();
            AssignUnit();
            LoadData();
        }

        private void LoadData()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IShelvesServices shelvesServices = new ShelvesServices(unitOfWork);

            var shelves = shelvesServices.GetShelves();


            if(shelves != null)
            {
                lvShelves.ItemsSource = null;
                lvShelves.ItemsSource = shelves;
            }
        }

        private void AssignUnit()
        {
           if(unit != null)
            {
                txtUnit.Text = unit.UnitName;
            }
        }

        public ShelvesManagement(string productCode, string importDetailId, Unit unit) : this()
        {
            this.importDetailId = importDetailId;
            this.productCode = productCode;
            this.unit = unit;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Shelf shelf = GetShelf();
            if (CheckShelf(shelf))
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);

                var transaction = context.Database.BeginTransaction();
                IShelvesServices shelvesServices = new ShelvesServices(unitOfWork);
                IShelvesHistoryServices shelvesHistoryServices = new ShelvesHistoryServices(unitOfWork);
                IStockService stockService = new StockService(unitOfWork);
                
                if(shelvesServices.GetShelf(x => x.ProductCode == shelf.ProductCode && x.ImportDetailId == shelf.ImportDetailId
                && x.Unit == shelf.Unit) != null)
                {
                    var existedShelf = shelvesServices.GetShelf(x => x.ProductCode == shelf.ProductCode && x.ImportDetailId == shelf.ImportDetailId
                && x.Unit == shelf.Unit);
                    existedShelf.Quantity += shelf.Quantity;
                    try
                    {
                        ShelvesHistory shelvesHistory = GetShelfHistory(shelf);
                        shelvesHistoryServices.Insert(shelvesHistory);
                        shelvesServices.Update(existedShelf);
                        Stock st = stockService.GetStock(x => x.ProductCode == shelf.ProductCode &&
                        x.ImportDetailId == shelf.ImportDetailId && x.UnitId == shelf.Unit);
                        st.Quantity -= shelf.Quantity;
                        stockService.UpdateStock(st);
                        transaction.Commit();
                        MessageBox.Show("Thêm hàng lên kệ thành công");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Thêm hàng lên kệ thất bại");
                    }
                }
                else
                {
                    while (true)
                    {
                        shelf.ShelvesId = GenerateId(50);
                        if (shelvesServices.GetShelf(x => x.ShelvesId == shelf.ShelvesId) == null)
                            break;
                    }

                    try
                    {
                        ShelvesHistory shelvesHistory = GetShelfHistory(shelf);
                        shelvesHistoryServices.Insert(shelvesHistory);
                        shelvesServices.Insert(shelf);
                        Stock st = stockService.GetStock(x => x.ProductCode == shelf.ProductCode &&
                        x.ImportDetailId == shelf.ImportDetailId && x.UnitId == shelf.Unit);
                        st.Quantity -= shelf.Quantity;
                        stockService.UpdateStock(st);
                        transaction.Commit();

                        MessageBox.Show("Thêm hàng lên kệ thành công");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Thêm hàng lên kệ thất bại");
                    }

                }
                
            }
        }

        private ShelvesHistory GetShelfHistory(Shelf shelf)
        {
            if(shelf != null)
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IShelvesHistoryServices shelvesHistoryServices = new ShelvesHistoryServices(unitOfWork);

                ShelvesHistory shelvesHistory = new ShelvesHistory();
                while (true)
                {
                    shelvesHistory.ShelvesHistoryId = GenerateId(50);
                    if(shelvesHistoryServices.GetShelfHistory(x => x.ShelvesHistoryId == shelvesHistory.ShelvesHistoryId) == null)
                    {
                        break;
                    }
                }
                shelvesHistory.ProductCode = shelf.ProductCode;
                shelvesHistory.ImportDetailId = shelf.ImportDetailId;
                shelvesHistory.Unit = shelf.Unit;
                shelvesHistory.Quantity = shelf.Quantity;
                shelvesHistory.Date = DateTime.Now.Date;
                shelvesHistory.Description = "";

                return shelvesHistory;
            }
            return null;
        }

        private bool CheckShelf(Shelf shelf)
        {
            if(shelf != null)
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IStockService stockService = new StockService(unitOfWork);

                var stock = stockService.GetStock(x => x.ProductCode == shelf.ProductCode
                                                        && x.ImportDetailId == shelf.ImportDetailId
                                                        && x.UnitId == shelf.Unit
                                                        && x.Quantity > 0);
                if(stock != null)
                {
                    if(shelf.Quantity <= stock.Quantity && shelf.Quantity > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Số lượng vượt quá trong kho hoặc chưa nhập số lượng");
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm chưa tồn tại trong kho");
            }
            return false;
        }

        private Shelf GetShelf()
        {
            Shelf shelf = new Shelf();
            shelf.ProductCode = productCode;
            shelf.ImportDetailId = importDetailId;
            shelf.Unit = unit.UnitId;
            int quantity;
            if(int.TryParse(txtQuantity.Text, out quantity))
            {
                shelf.Quantity = quantity;
            }
            return shelf;
        }
        private string GenerateId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
