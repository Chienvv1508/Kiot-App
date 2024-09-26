using Microsoft.EntityFrameworkCore;
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

namespace ProjectInstaArt.UI.ManagerUI.ProductUI
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        List<Product> products;
        List<Category> categories;
        List<Unit> newUnits;
        

        UnitAdding unitAdding1 ;
        bool isUpdate = false;


        public AddProduct()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IProductService productService = new ProductService(unitOfWork);
            ICategoryService categoryService = new CategoryService(unitOfWork);

            products = productService.GetAllProducts();
            categories = categoryService.GetCategories();

            AssignCategory();

            List<dynamic> dynamics = new List<dynamic>();
            foreach (Product product in products)
            {
                var category = categories.FirstOrDefault(x => x.CategoryId == product.CategoryId);
                var x = new
                {
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    Company = product.Company,
                    Description = product.Description,
                    CategoryName = category != null ? category.CategoryName : ""
                };

                dynamics.Add(x);


            }
            
            
            lvProducts.ItemsSource = dynamics;
        }

        private void AssignCategory()
        {
            Category category = new Category();
            category.CategoryId = -1;
            category.CategoryName = "Thêm Loại Hàng";
            if(categories.FirstOrDefault(x=> x.CategoryId == -1) == null)
            {
                categories.Add(category);
            }
           

            cbCategory.ItemsSource = categories;
        }

        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isUpdate)
            {
                isUpdate = false;
                return;
            }
            string productCode = txtProductCode.Text;
            var categoryId = products.FirstOrDefault(x => x.ProductCode == productCode).CategoryId;

            var category = categories.FirstOrDefault(x => x.CategoryId == categoryId);

            if(category != null)
            {
                cbCategory.Text = category.CategoryName;
            }

           


        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var selectedItem = (Category)cbCategory.SelectedItem;
            if (selectedItem != null)
            {
                if (selectedItem.CategoryId == -1)
                {
                    this.Hide();
                    CategoryManagement categoryManagement = new CategoryManagement();
                    categoryManagement.Show();
                    categoryManagement.Closed += ShowProductManagementFromCategory;

                }
            }
        }



        private void ShowProductManagementFromCategory(object? sender, EventArgs e)
        {
            this.Show();
            LoadData();
        }

        private void btnAddUnit_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IUnitService unitService = new UnitService(unitOfWork);
            List<Unit> units = unitService.GetAllUnit(x => x.ProductCode == txtProductCode.Text && x.IsValid == true);
            UnitAdding unitAdding = new UnitAdding(units);
           

            unitAdding.Show();

            unitAdding.Closed += ShowProductManagement;

            unitAdding1 = unitAdding;
        }

        private void ShowProductManagement(object? sender, EventArgs e)
        {
            this.Show();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = GetProduct();
            if (CheckNewProduct(product))
            {
                if (product != null)
                {
                    InstaArtVer3Context context = new InstaArtVer3Context();
                    var transaction =  context.Database.BeginTransaction();
                    try
                    {
                       
                        product = AddNewProduct(product,context);

                        AddUnit(product, unitAdding1.newUnits,context);

                        MessageBox.Show("Thêm sản phẩm thành công!");
                        transaction.Commit();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
           

           
        }

        private bool CheckNewProduct(Product product)
        {
           if(product != null)
            {
                if (!PrimitiveValueValidation.CheckName(product.ProductName))
                {
                    MessageBox.Show("Tên sản phẩm sai định dạng");
                    return false;
                }

                if(products.FirstOrDefault(x => x.ProductCode == product.ProductCode) != null)
                {
                    MessageBox.Show("Sản phẩm đã tồn tại");
                    return false;
                }
                if (!PrimitiveValueValidation.CheckName(product.Company))
                {
                    MessageBox.Show("Tên công ty sai định dạng");
                    return false;
                }
                if(unitAdding1 != null)
                {
                    newUnits = unitAdding1.newUnits;
                    if (newUnits.Count == 0)
                    {
                        MessageBox.Show("Phải nhập đơn vị cho sản phẩm");
                        return false;
                    }
                }else
                {
                    MessageBox.Show("Phải nhập đơn vị cho sản phẩm");
                    return false;
                }
                

                return true;

            }
            MessageBox.Show("Hãy nhập các trường!");
            return false;
        }

        private Product GetProduct()
        {
           string productCode = txtProductCode.Text;
           string productName = txtProductName.Text;
           string description = txtDescription.Text;
           string company = txtCompany.Text;
           var category = (Category)cbCategory.SelectedItem;

            Product product = new Product();
            product.ProductCode = productCode;
            product.ProductName = productName;
            product.Description = description;
            product.Company = company;
            product.IsValid = true;
            if (category != null)
            {
               
                product.CategoryId = category.CategoryId;

                return product;
            }
            

            return null;
            
        }

        private void AddUnit(Product product, List<Unit> newUnits, InstaArtVer3Context context)
        {
            if(product != null && newUnits != null)
            {
               
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IUnitService unitService = new UnitService(unitOfWork);

                foreach (var item in newUnits)
                {
                    item.ProductCode = product.ProductCode;
                    unitService.InsertUnit(item);
                }
               
            }
        }

        private Product AddNewProduct(Product product, InstaArtVer3Context context)
        {
            if(product != null)
            {
                
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IProductService productService = new ProductService(unitOfWork);

                productService.AddProduct(product);
            }

            return product;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
               var product = GetProduct();
                if(CheckUpdateProduct(product)) 
                {
                try
                {
                    UpdateProduct(product);
                    MessageBox.Show("Sửa thành công");
                    isUpdate = true;
                    LoadData();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                   
                }
           
        }

        private void UpdateProduct(Product product)
        {
            if (product != null)
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IProductService productService = new ProductService(unitOfWork);

                productService.UpdateProduct(product);
            }
        }

        private bool CheckUpdateProduct(Product product)
        {
            if (product != null)
            {
                if (!PrimitiveValueValidation.CheckName(product.ProductName))
                {
                    MessageBox.Show("Tên sản phẩm sai định dạng");
                    return false;
                }

                if (products.FirstOrDefault(x => x.ProductCode == product.ProductCode) == null)
                {
                    MessageBox.Show("Mã sp sai");
                    return false;
                }
                if (!PrimitiveValueValidation.CheckName(product.Company))
                {
                    MessageBox.Show("Tên công ty sai định dạng");
                    return false;
                }
               


                return true;

            }
            MessageBox.Show("Hãy nhập các trường!");
            return false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Product prodduct = GetProductByProductCode();
            if(prodduct != null)
            {
                try
                {
                    DeleteProduct(prodduct);
                    MessageBox.Show("Xóa thành công");
                    isUpdate = true;
                    LoadData();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
            }
            else
            {
                MessageBox.Show("Chưa chọn sản phẩm");
            }

        }

        private Product GetProductByProductCode()
        {
            string productCode = txtProductCode.Text;
            var product = products.FirstOrDefault(x => x.ProductCode == productCode);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        private void DeleteProduct(Product prodduct)
        {
            if(prodduct != null)
            {
                prodduct.IsValid = false;
                UpdateProduct(prodduct);
            }
            
        }
    }
}
