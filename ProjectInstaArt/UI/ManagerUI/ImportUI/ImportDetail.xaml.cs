using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServiceImplements;
using ProjectInstaArt.Services.ServicesContracts;
using ProjectInstaArt.UI.ManagerUI.UnitUI;
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
    /// Interaction logic for ImportDetail.xaml
    /// </summary>
    public partial class ImportDetail : Window
    {
        public ImportDetail()
        {
            InitializeComponent();
            PrepareData();
        }
        public ProjectInstaArt.DAL.Model.ImportDetail importDetail  = null;
        List<Product> products;
        List<Category> categories;
        List<ProjectInstaArt.DAL.Model.ImportDetail> importDetails;
       
       public List<Unit> units;
        public Unit selectedUnit;
        private void PrepareData()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IProductService productService;
            ICategoryService categoryService;
            IUnitService unitService;
            
            productService = new ProductService(unitOfWork);
            products = productService.GetAllProducts();
            
            categoryService = new CategoryService(unitOfWork);
            categories = categoryService.GetCategories();

            unitService = new UnitService(unitOfWork);
            units = unitService.GetAllUnit();
            
            IImportDetailService importDetailService = new ImportDetailService(unitOfWork);
            importDetails = importDetailService.GetAllImportDetails();

        }


        private void txtProductCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string productCode = txtProductCode.Text;
            Product product = products.FirstOrDefault(pr => pr.ProductCode.Equals(productCode));
            if(product != null)
            {
                FullFillFildes(product);
            }
            

        }

        private void FullFillFildes(Product? product)
        {
            if (product != null)
            {
                txtProductCode.Text = product.ProductCode;
                txtProductName.Text = product.ProductName;
                AssignUnit(product);
              


            }
           
               
        }

        private void AssignUnit(Product product)
        {
            if(product != null)
            {
               var listUnit =  units.Where(x => x.ProductCode == product.ProductCode).ToList();
                cbUnit.ItemsSource = listUnit;
            }
        }

        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string productName = txtProductName.Text;
            List<Product> listProduct = products.Where(x => x.ProductName.Contains(productName)).ToList();
            lvViewProduct.Visibility = Visibility.Visible;
            lvViewProduct.ItemsSource = listProduct;


        }

        private void lvViewProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = (Product)lvViewProduct.SelectedItem;
            FullFillFildes(product);
            lvViewProduct.Visibility = Visibility.Hidden;
        }

        private void cbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var unit = (Unit)cbUnit.SelectedItem;
            if(unit != null)
            {
                selectedUnit = unit;
               
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ProjectInstaArt.DAL.Model.ImportDetail importDetail1 = GetImportDetail();
            if(CheckImportDetail(importDetail1))
            {
                importDetail = importDetail1;
                this.Close();
            }
        }

        private bool CheckImportDetail(DAL.Model.ImportDetail importDetail1)
        {
            if(importDetail1 != null)
            {
                if(products.FirstOrDefault(x => x.ProductCode == importDetail1.ProductCode) == null)
                {
                    MessageBox.Show("Sản Phẩm chưa tồn tại!");
                    return false;
                }
                if (importDetail1.UnitId == 0)
                {
                    MessageBox.Show("Chưa nhập đơn vị");
                    return false;
                }
                if (importDetail1.Quantity <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0");
                    return false;
                }
                if (importDetail1.Cost <= 0)
                {
                    MessageBox.Show("Giá phải lớn hơn 0");
                    return false;
                }
                if (importDetail1.ManufactureDate > DateTime.Now)
                {
                    MessageBox.Show("Ngày xản xuất không được lớn hơn ngày hiện tại");
                    return false;
                }
                if (importDetail1.ExpiredDate < DateTime.Now)
                {
                    MessageBox.Show("Sản phẩm đã hết hạn");
                    return false;
                }
                
               

                return true;

            }
            return false;
        }

        private DAL.Model.ImportDetail GetImportDetail()
        {
            ProjectInstaArt.DAL.Model.ImportDetail importDetail1 = new DAL.Model.ImportDetail();
            while (true)
            {
                importDetail1.ImportDetailId = GenerateId(50);
                if (importDetails.FirstOrDefault(x => x.ImportDetailId == importDetail1.ImportId) == null)
                    break;
            }
            importDetail1.ProductCode = txtProductCode.Text;
            importDetail1.BatchCode = "";
            importDetail1.ManufactureDate = (DateTime)dtMFGDate.SelectedDate == null?DateTime.Now.Date: (DateTime)dtMFGDate.SelectedDate;
            importDetail1.ExpiredDate = (DateTime)dtExpiredDate.SelectedDate == null ? DateTime.Now.Date : (DateTime)dtExpiredDate.SelectedDate;
            int quantity;
            if(int.TryParse(txtQuantity.Text, out quantity))
                importDetail1.Quantity = quantity;
            decimal cost;
            if (decimal.TryParse(txtQuantity.Text, out cost))
                importDetail1.Cost = cost;
            if (selectedUnit != null)
            {
                importDetail1.UnitId = selectedUnit.UnitId;
                
            }
                
           


            return importDetail1;
            
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
