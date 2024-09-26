using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServiceImplements;
using ProjectInstaArt.Validatation;
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

namespace ProjectInstaArt.UI.ManagerUI
{
    /// <summary>
    /// Interaction logic for ImportDetail.xaml
    /// </summary>
    public partial class ImportDetail : Window
    {
        private UnitOfWork unitOfWork;
        private List<Product> products;
        private List<Category> categories;
        private List<Unit> units;
        private bool isExisted;
      
        public ImportDetail()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    InstaArtVer2Context db = new InstaArtVer2Context();
            //    unitOfWork = new UnitOfWork(db);
            //    CategoryService categoryService = new CategoryService(unitOfWork);
            //    ProductService productService = new ProductService(unitOfWork);
            //    UnitService unitService = new UnitService(unitOfWork);
               

            //    units = unitService.GetAllUnit();
            //     products = productService.GetAllProducts();
            //    categories = categoryService.GetCategories();
              

                

            //}
            //catch (Exception ex)
            //{

            //}
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        { var checkImportDetail = CheckImportDetail();
            if (checkImportDetail.Item1)
            {
                if (isExisted)
                {
                    var importDetail = checkImportDetail.Item2;
                    Unit unit = units.Where(x => x.ProductCode == importDetail.ProductCode).FirstOrDefault(x => x.UnitName.ToLower().Equals(cbUnit.Text.ToLower()));
                    importDetail.ProductCodeNavigation = products.FirstOrDefault(x => x.ProductCode == importDetail.ProductCode);
                    if (unit != null)
                    {
                        importDetail.UnitId = unit.UnitId;
                        importDetail.Unit = unit;
                       
                        if (!UserControl1.listImportDetail.ContainsKey(importDetail.ProductCode))
                        {
                            UserControl1.listImportDetail.Add(importDetail.ProductCode, (importDetail, true, null, null));
                        }
                       
                    }
                    else
                    {
                        unit = new Unit();
                        unit.UnitName = cbUnit.Text;
                        importDetail.Unit = unit;
                        if (!UserControl1.listImportDetail.ContainsKey(importDetail.ProductCode))
                        {
                            UserControl1.listImportDetail.Add(importDetail.ProductCode, (importDetail, true, null, unit));
                        }
                    }
                    
                    
                }
                else
                {
                    var importDetail = checkImportDetail.Item2;
                    Unit newUnit = new Unit();
                    newUnit.ProductCode = importDetail.ProductCode;
                    newUnit.IsValid = true;
                    newUnit.UnitName = cbUnit.Text;
                    Category category = new Category();
                    category.CategoryName = cbProductCategory.Text;
                    importDetail.ProductCodeNavigation = checkImportDetail.Item3;
                    importDetail.Unit = newUnit;
                    if (!UserControl1.listImportDetail.ContainsKey(importDetail.ProductCode))
                    {
                        UserControl1.listImportDetail.Add(importDetail.ProductCode, (importDetail, false, category, newUnit));
                    }
                }
                this.Close();
            }
            
          
        }

        private (bool,ProjectInstaArt.DAL.Model.ImportDetail, Product) CheckImportDetail()
        {
           // string productCode = txtProductCode.Text;
           // string productName = txtProductName.Text;
           // string productCategory = cbProductCategory.Text;
           // string productUnit = cbUnit.Text;
           // string quantity = txtQuantity.Text;
           // int quantity2;
           // string cost = txtCost.Text;
           //decimal cost2;
           // DateTime mfgDate;
           // DateTime expDate;
           // if (!ValidateProduct.CheckProductCode(productCode))
           // {
           //     MessageBox.Show("Mã sản phẩm không phù hợp!");
           //     return (false,null,null);
           // }
           // if (!Validatation.ValidateProduct.CheckName(productName))
           // {
           //     MessageBox.Show("Tên sản phẩm không phù hợp!");
           //     return (false, null, null);
           // }
           // if (!Validatation.ValidateProduct.CheckName(productCategory))
           // {
           //     MessageBox.Show("Loại sản phẩm không phù hợp!");
           //     return (false, null, null);
           // }
           // if (!ValidateProduct.CheckName(productUnit))
           // {
           //     MessageBox.Show("Đơn vị tính chưa phù hợp!");
           //     return (false, null, null);
           // }
           // if(!int.TryParse(quantity,out quantity2))
           // {
                
           //     MessageBox.Show("Số lượng phải nhập số!");
           //     return (false, null, null);
           // }
           // else if(quantity2 <= 0)
           // {
           //     MessageBox.Show("Số lượng phải > 0!");
           //     return (false, null, null);
           // }
           // if (!decimal.TryParse(cost, out cost2))
           // {

           //     MessageBox.Show("Giá nhập phải nhập số!");
           //     return (false, null, null);
           // }
           // else if (cost2 <= 0)
           // {
           //     MessageBox.Show("Giá nhập phải > 0!");
           //     return (false, null, null);
           // }
           // if(dtMFGDate.SelectedDate == null)
           // {
           //     MessageBox.Show("Chưa nhập ngày sản xuất");
           //     return (false, null, null);
           // }
           // else
           // {
           //     mfgDate = (DateTime)dtMFGDate.SelectedDate;
           // }
           // if(mfgDate > DateTime.Now.Date)
           // {
           //     MessageBox.Show("Ngày sản xuất <= ngày hiện tại");
           //     return (false, null, null);
           // }
           // if (dtExpiredDate.SelectedDate == null)
           // {
           //     MessageBox.Show("Chưa nhập ngày hết hạn");
           //     return (false, null, null);
           // }
           // else
           // {
           //     expDate = (DateTime)dtExpiredDate.SelectedDate;
           // }
           // if (expDate < mfgDate)
           // {
           //     MessageBox.Show("Ngày hết hạn >= ngày sản xuất");
           //     return (false, null, null);
           // }

           // ProjectInstaArt.DAL.Models.ImportDetail importDetail = new DAL.Models.ImportDetail();
           // importDetail.ProductCode = productCode;
           // importDetail.Cost = cost2;
           // importDetail.Quantity = quantity2;
           // importDetail.Mfgdate = mfgDate;
           // importDetail.ExpiredDate = expDate;
           // Product product = null;
           // if (!isExisted)
           // {
           //      product = new Product();
           //     product.ProductCode = productCode;
           //     product.ProductName = productName;
           // }
           

            return /*(true,importDetail,product)*/ (true,null,null);
        }

       

        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                cbUnit.ItemsSource = null;
                cbProductCategory.ItemsSource = null;
                
                string productName = txtProductName.Text.ToLower();
                var items = products.Where(x => x.ProductName.ToLower().Contains(productName)).ToList();
                lvView.Visibility = Visibility.Visible; 
                lvView.ItemsSource = items;

            }
            catch (Exception ex)
            {

            }
        }

        private void txtProductCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
               

                string productCode = txtProductCode.Text;
                Product product =  products.FirstOrDefault(x => x.ProductCode.Equals(productCode));
                if(product != null)
                {
                    isExisted = true;
                    AssignProductName(product);
                    AssignCategory(product);
                    AssignUnit(product);
                  
                }
                else isExisted = false;

            }
            catch (Exception ex)
            {

            }

        }

      

        private void AssignProductName(Product product)
        {
            if(product != null)
            {
                txtProductName.Text = product.ProductName;
                lvView.Visibility = Visibility.Hidden;
            }
        }

        private void lvView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var product = (Product)lvView.SelectedItem;
            txtProductCode.Text = product.ProductCode;
            lvView.Visibility = Visibility.Hidden;
            lvViewProductCode.Visibility = Visibility.Hidden;
            AssignCategory(product);
            AssignUnit(product);
            isExisted = true;
            

        }

        private void AssignUnit(Product product)
        {
            var unitsOfProduct = units.Where(x => x.ProductCode == product.ProductCode);
            cbUnit.ItemsSource = unitsOfProduct.ToList();
        }

        private void AssignCategory(Product product)
        {
            var c = categories.FirstOrDefault(x => x.CategoryId == product.CategoryId);
            cbProductCategory.SelectedValue = c.CategoryId;
            cbProductCategory.Text = c.CategoryName;
        }
    }
}
