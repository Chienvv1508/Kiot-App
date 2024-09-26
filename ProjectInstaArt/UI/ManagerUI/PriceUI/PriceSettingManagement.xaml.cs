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

namespace ProjectInstaArt.UI.ManagerUI.PriceUI
{
    /// <summary>
    /// Interaction logic for PriceSettingManagement.xaml
    /// </summary>
    public partial class PriceSettingManagement : Window
    {
        List<PriceSetting> priceSettings;
        Product product;
        List<Unit> units;
        bool isExisted;

        public PriceSettingManagement()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IPriceSettingSevices priceSettingSevices = new PriceSettingsSevices(unitOfWork);

            priceSettings = priceSettingSevices.GetAllPriceSettings(x => x.IsValid == true);

            lvPriceSettings.ItemsSource = null;
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                lvPriceSettings.ItemsSource = priceSettings;
            }else
                lvPriceSettings.ItemsSource = priceSettings.Where(x=> x.ProductCode.Contains(txtProductCode.Text)).ToList();
        }

        private void txtProductCode_SelectionChanged(object sender, RoutedEventArgs e)
        {
            isExisted = false;
            string productCode = txtProductCode.Text;
            if (productCode.Length == 15)
            {
                Product newproduct = GetProduct(productCode);
                if (newproduct != null)
                {
                    units = GetUnits(newproduct);
                    if (units != null)
                    {
                        if (units.Count != 0)
                        {
                            AssignUnit(units);
                            txtProductCode.Text = productCode;
                            lvPriceSettings.ItemsSource = null;
                            lvPriceSettings.ItemsSource = priceSettings.Where(x => x.ProductCode == newproduct.ProductCode);
                            product = newproduct;
                            isExisted = true;
                        }
                        else MessageBox.Show("Sản phẩm không đơn vị");
                    }
                    else MessageBox.Show("Sản phẩm chưa có đơn vị");
                }
                else MessageBox.Show("Sản phẩm không tồn tại");
            }
            else
            {
                if (string.IsNullOrEmpty(productCode))
                {
                    lvPriceSettings.ItemsSource = null;
                    lvPriceSettings.ItemsSource = priceSettings;
                }
                else
                {
                    lvPriceSettings.ItemsSource = null;
                    lvPriceSettings.ItemsSource = priceSettings.Where(x => x.ProductCode.Contains(productCode)).ToList();
                }

            }
        }

        private void AssignUnit(List<Unit> units)
        {
            if (units != null)
            {
                cbUnit.ItemsSource = units;
            }
        }

        private List<Unit> GetUnits(Product product)
        {
            if (product != null)
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IUnitService unitService = new UnitService(unitOfWork);

                return unitService.GetAllUnit(x => x.ProductCode == product.ProductCode);
            }
            return null;

        }

        private Product GetProduct(string productCode)
        {
            if (!string.IsNullOrEmpty(productCode))
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IProductService productService = new ProductService(unitOfWork);

                var product = productService.GetProduct(x => x.ProductCode == productCode && x.IsValid == true);
                return product;
            }
            return null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isExisted)
            {
                PriceSetting priceSetting = GetPriceSetting();
                if (CheckPriceSetting(priceSetting))
                {
                    InstaArtVer3Context context = new InstaArtVer3Context();
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    IPriceSettingSevices priceSettingSevices = new PriceSettingsSevices(unitOfWork);

                    while (true)
                    {
                        priceSetting.PriceRuleId = GenerateId(50);
                        if (priceSettingSevices.GetPriceSettings(x => x.PriceRuleId == priceSetting.PriceRuleId) == null)
                            break;
                    }
                    try
                    {
                        priceSettingSevices.CreatePriceSetting(priceSetting);
                        MessageBox.Show("Thêm giá thành công");
                        LoadData();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                    
                    
                }

            }

        }

        private bool CheckPriceSetting(PriceSetting priceSetting)
        {
            if(priceSetting != null)
            {
                if (priceSetting.UnitId <= 0) {
                    MessageBox.Show("Nhập đơn vị sai!");
                    return false;
                }
               
                if(priceSetting.Quantity <= 0)
                {
                    MessageBox.Show("Nhập số lượng > 0");
                    return false;
                }
                if (priceSetting.Price <= 0)
                {
                    MessageBox.Show("Nhập giá lớn hơn 0");
                    return false;
                }

                return true;
            }
            return false;
        }

        private PriceSetting GetPriceSetting()
        {
            if (isExisted)
            {
                PriceSetting priceSetting = new PriceSetting();
                priceSetting.ProductCode = product.ProductCode;
                priceSetting.Description = "";
                priceSetting.Date = DateTime.Now.Date;
                priceSetting.IsValid = true;

                var unit = cbUnit.SelectedItem as Unit;
                if (unit != null)
                {
                    priceSetting.UnitId = unit.UnitId;
                }
                else priceSetting.UnitId = -1;

                int quantity;
                decimal price;

                if(int.TryParse(txtQuantity.Text, out quantity))
                {
                    priceSetting.Quantity = quantity;
                }
                if(decimal.TryParse(txtPrice.Text, out price))
                {
                    priceSetting.Price = price;
                }


                return priceSetting;
               
            }
            return null;
        }

        private string GenerateId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {

           var result =  MessageBox.Show("Bạn có muốn xóa luật giá", "Giá", MessageBoxButton.YesNo);
           if(result == MessageBoxResult.Yes)
            {
                Button clickedButton = sender as Button;
                var priceSetting = clickedButton.DataContext as PriceSetting;


                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IPriceSettingSevices priceSettingSevices = new PriceSettingsSevices(unitOfWork);

                priceSetting = priceSettingSevices.GetPriceSettings(x => x.PriceRuleId == priceSetting.PriceRuleId);
                if (priceSetting != null)
                {
                    priceSetting.IsValid = false;
                    priceSettingSevices.UpdatePriceSetting(priceSetting);

                    LoadData();
                }
            } 
          


        }
    }
}