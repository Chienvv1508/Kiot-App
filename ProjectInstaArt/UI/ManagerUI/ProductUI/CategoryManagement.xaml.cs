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

namespace ProjectInstaArt.UI.ManagerUI.ProductUI
{
    /// <summary>
    /// Interaction logic for CategoryManagement.xaml
    /// </summary>
    public partial class CategoryManagement : Window
    {
        List<Category> categories;

       
        public CategoryManagement()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            ICategoryService categoryService = new CategoryService(unitOfWork);

            categories = categoryService.GetCategories();
            lvCategory.ItemsSource = categories;
        }



        private void txtCategory_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            if (categories != null)
            {
                List<Category> lsCategories = categories.Where(x => x.CategoryName.Contains(txtCategory.Text)).ToList();
                lvCategory.ItemsSource = lsCategories;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = txtCategory.Text;
            if (PrimitiveValueValidation.CheckName(categoryName))
            {
                if (categories.FirstOrDefault(x => x.CategoryName.ToLower().Equals(categoryName.ToLower())) == null)
                {
                    InstaArtVer3Context context = new InstaArtVer3Context();
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    ICategoryService categoryService = new CategoryService(unitOfWork);

                    Category newCategory = new Category();
                    newCategory.CategoryName = categoryName;
                    newCategory.IsValid = true;

                    categoryService.AddCategory(newCategory);

                    LoadData();

                    RefreshData();


                    MessageBox.Show("Thêm thành công!");


                }
                else
                    MessageBox.Show("Tên đã tồn tại");
            }
            else
                MessageBox.Show("Tên sai định dạng");
        }

        private void RefreshData()
        {
            txtCategoryId.Text = "";
            txtCategory.Text = "";


        }

        private void lvCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var category = lvCategory.SelectedItem as Category;
            if (category != null)
            {
                txtCategory.Text = category.CategoryName;
                txtCategoryId.Text = category.CategoryId.ToString();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var categoryId = int.Parse(txtCategoryId.Text);
                var category = categories.FirstOrDefault(x => x.CategoryId == categoryId);

                if (category != null)
                {
                    string categoryName = txtCategory.Text;

                    if (PrimitiveValueValidation.CheckName(categoryName))
                    {
                        if (categories.FirstOrDefault(x => x.CategoryName.ToLower().Equals(categoryName.ToLower())) == null)
                        {
                            InstaArtVer3Context context = new InstaArtVer3Context();
                            IUnitOfWork unitOfWork = new UnitOfWork(context);
                            ICategoryService categoryService = new CategoryService(unitOfWork);

                            category.CategoryName = categoryName;

                            categoryService.UpdateCategory(category);

                            LoadData();

                            RefreshData();


                            MessageBox.Show("Thay đổi thành công!");

                          


                        }
                        else
                            MessageBox.Show("Tên đã tồn tại");

                    }
                    else
                        MessageBox.Show("Tên sai định dạng");

                }

            }
            catch(Exception ex)
            {

            }
            

           
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var categoryId = int.Parse(txtCategoryId.Text);
                var category = categories.FirstOrDefault(x => x.CategoryId == categoryId);

                if (category != null)
                {
                    InstaArtVer3Context context = new InstaArtVer3Context();
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    ICategoryService categoryService = new CategoryService(unitOfWork);
                    category.IsValid = false;

                    categoryService.UpdateCategory(category);

                    LoadData();

                    RefreshData();


                    MessageBox.Show("Xóa thành công!");

                }

            }
            catch (Exception ex)
            {

            }

        }
    }
}