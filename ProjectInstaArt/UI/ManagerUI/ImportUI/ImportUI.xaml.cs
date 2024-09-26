using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectInstaArt.Contracts;
using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServiceImplements;
using ProjectInstaArt.Services.ServicesContracts;
using ProjectInstaArt.UI.CommonUI;
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

namespace ProjectInstaArt.UI.ManagerUI.ImportUI
{
    /// <summary>
    /// Interaction logic for ImportUI.xaml
    /// </summary>
    public partial class ImportUI : Window
    {
        List<ProjectInstaArt.DAL.Model.ImportDetail> importDetails = new List<ProjectInstaArt.DAL.Model.ImportDetail>();
        List<Stock> stocks = new List<Stock>();
        List<Import> imports = new List<Import>();
        ImportDetail importDetail1;

        public ImportUI()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IStockService stockService = new StockService(unitOfWork);
            IImportService importService = new ImportService(unitOfWork);
            imports = importService.GetAllImport();
            stocks = stockService.GetAllStocks();
            lvImportDetail.ItemsSource = importDetails;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           ImportDetail importDetail = new ImportDetail();
            importDetail1 = importDetail;
            importDetail.Show();
            this.Hide();
            importDetail.Closed += OpenAgain;
        }

        private void OpenAgain(object? sender, EventArgs e)
        {
            if(importDetail1 != null)
            {
                if(importDetail1.importDetail != null)
                importDetails.Add(importDetail1.importDetail);
            }
            LoadData();
           this.Show();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Import import = GetImport();
            if(!CheckImport(import)) return;
            if(import != null)
            {
                if(importDetails.Count > 0)
                {
                    
                        if (AddNewImport(import, importDetails))
                        {
                            MessageBox.Show("Nhập hàng thành công!");
                            RfreshData();
                    }
                    else
                    {
                        MessageBox.Show("Nhập hàng không thành công!");
                    }
                   
                }
            }
        }

        private void RfreshData()
        {
            importDetails = new List<DAL.Model.ImportDetail>();
            LoadData();
        }

        private bool AddNewImport(Import import, List<ProjectInstaArt.DAL.Model.ImportDetail> importDetails)
        {
            
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            var transaction = context.Database.BeginTransaction();
            IImportService importService = new ImportService(unitOfWork);
            IImportDetailService importDetailService = new ImportDetailService(unitOfWork);
            IStockService stockService = new StockService(unitOfWork);
            try
            {
                importService.InsertImport(import);
                foreach(var item in importDetails)
                {
                    item.ImportId = import.ImportId;
                    importDetailService.InsertImportDetail(item);
                    Stock stock = GetStock(item);
                    stockService.InserStock(stock);
                }

                transaction.Commit();
                return true;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private Stock GetStock(DAL.Model.ImportDetail item)
        {
           if(item != null)
            {
                Stock stock = new Stock();
                while (true)
                {
                    stock.StockId = GenerateId(50);
                    if(stocks.FirstOrDefault(x => x.StockId == stock.StockId) == null)
                    {
                        break;
                    }
                }
               
                stock.ImportDetailId = item.ImportDetailId;
                stock.ProductCode = item.ProductCode;
                stock.UnitId = item.UnitId;
                stock.Quantity = item.Quantity;
                return stock;
            }
            return null;
        }

        private Import GetImport()
        {
            string description = txtImportDescription.Text;
            DateTime date = (DateTime)dtImportDate.SelectedDate == null? DateTime.Now.Date : (DateTime)dtImportDate.SelectedDate;
            string supplier = txtSupplierName.Text;
            string importId;
            while (true)
            {
                 importId = GenerateId(50);
                if (imports.FirstOrDefault(x => x.ImportId == importId) == null)
                    break;
            }
            long importer = Login.staticUser.UserId;

            Import import = new Import();
            import.ImportId = importId;
            import.Description = description;
            import.Supplier = supplier;
            import.ImportDate = date;
            import.Importer = importer;

            return import;
            
        }

        private string GenerateId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool CheckImport(Import import)
        {
            if(import != null)
            {
                if (!PrimitiveValueValidation.CheckText(import.Description))
                {
                    MessageBox.Show("Sai định dạng miêu tả");
                    return false;
                }
                if (!PrimitiveValueValidation.CheckText(import.Supplier))
                {
                    MessageBox.Show("Sai định dạng nhà cung cấp");
                    return false;
                }
               

            }
            
            

            return true;
        }
    }
}
