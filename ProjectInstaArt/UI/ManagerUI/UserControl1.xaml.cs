using ProjectInstaArt.Contracts;
using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services;
using ProjectInstaArt.Services.ServiceImplements;
using ProjectInstaArt.Services.ServicesContracts;
using ProjectInstaArt;
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

namespace ProjectInstaArt.UI.ManagerUI
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private IUnitOfWork unitOfWork;
        public static Dictionary<string, (ProjectInstaArt.DAL.Model.ImportDetail,bool,Category,Unit)> listImportDetail = new Dictionary<string, (ProjectInstaArt.DAL.Model.ImportDetail, bool,Category,Unit)>();
        
        public UserControl1()
        {
            InitializeComponent();
        }

       

        private Import GetImport()
        {
            Import im = new Import();
            //im.Description = txtImportDescription.Text;
            //im.Supplier = txtSupplierName.Text;
            //im.ImportDate = dtImportDate.SelectedDate;
            return im;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImportDetail importDetail = new ImportDetail();
            importDetail.Show();
            importDetail.Closed += UpdateListImportDetail;
        }

        private void UpdateListImportDetail(object? sender, EventArgs e)
        {
            List<ProjectInstaArt.DAL.Model.ImportDetail> importDetails = new List<DAL.Model.ImportDetail>();
            foreach(var item in listImportDetail)
            {
                importDetails.Add(item.Value.Item1);
                
            }
            lvImportDetail.ItemsSource = importDetails;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Import import = GetImport();
            //try
            //{
            //    InstaArtVer2Context db = new InstaArtVer2Context();
            //    unitOfWork = new UnitOfWork(db);
                
            //    ImportService importService = new ImportService(unitOfWork);
            //    var importResult = importService.InsertImport(import);
            //    if (importResult.Item3)
            //    {
            //        // Nếu đã tồn tại sản phẩm ==> insert category || unit mới nếu có|| Thêm  thêm importDetail, thêm Stock
            //         foreach(var item in listImportDetail)
            //        {
            //            if(item.Value.Item2 == true)
            //            {
            //                if(item.Value.Item4 != null)
            //                {
                                
            //                }
            //                else
            //                {
            //                    IImportDetailService importDetailService = new ImportDetailService(unitOfWork);
            //                    item.Value.Item1.ImportId = importResult.Item2;
                                
            //                    IStockService stockService = new StockService(unitOfWork);
            //                    Stock stock = new Stock();
            //                    stock.ImportId = importResult.Item2;
            //                    stock.ProductCode = item.Value.Item1.ProductCode;
            //                    stock.UnitId = item.Value.Item1.UnitId;
            //                    string productCode = item.Value.Item1.ProductCodeNavigation.ProductCode;
            //                    item.Value.Item1.ProductCodeNavigation = null;
            //                    item.Value.Item1.ProductCode = productCode;
            //                    long unitId = item.Value.Item1.UnitId;
            //                    item.Value.Item1.Unit = null;
            //                    item.Value.Item1.UnitId = unitId;


            //                    importDetailService.InsertImportDetail(item.Value.Item1);
            //                    stockService.InserStock(stock);
            //                    RefeshWindow();
                                
            //                }
            //            }
            //            else
            //            {

            //            }
            //        }

            //        // Nếu chưa ==> thêm cate, thêm unit, thêm product, thêm importDetail, thêm Stock
            //    }
            //    else MessageBox.Show(importResult.Item1);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi");
            //}
        }

        private void RefeshWindow()
        {
            lvImportDetail.ItemsSource = null;
            txtImportDescription.Text = "";
            txtSupplierName.Text = "";
            dtImportDate.Text = "";
        }
    }
}
