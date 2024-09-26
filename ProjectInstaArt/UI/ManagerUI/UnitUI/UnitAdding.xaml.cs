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

namespace ProjectInstaArt.UI.ManagerUI.UnitUI
{
    /// <summary>
    /// Interaction logic for UnitAdding.xaml
    /// </summary>
    public partial class UnitAdding : Window
    {
        IUnitOfWork unitOfWork;
        IUnitService unitService;
        

      public  static List<Unit> units;
        Unit baseUnit;
        public UnitAdding(List<Unit> itemsSource)
        {

            
            InitializeComponent();
            units = itemsSource;
            if(units != null)
            {
                units.RemoveAt(units.Count - 1);
            }
            AssignToTxtBaseUnit();
        }

        private void AssignToTxtBaseUnit()
        {
            baseUnit = units.FirstOrDefault(x => x.IsValid == true && x.IsBaseUnit == true);

            if (baseUnit != null)
                {
                    txtBaseUnit.Text = baseUnit.UnitName;
                } 
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FullFillData();

        }

        private void FullFillData()
        {
            if (units != null)
            {
                List<dynamic> dynamicUnit = new List<dynamic>();

               
                if (baseUnit != null)
                {
                    foreach (Unit unit in units)
                    {
                        var item = new { UnitId = unit.UnitId, UnitName = unit.UnitName, Quantity = unit.Quantity, BaseUnit = baseUnit.UnitName };
                        dynamicUnit.Add(item);
                    }
                    lvUnitList.ItemsSource = dynamicUnit;
                }

            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Unit newUnit = GetUnit();
            bool checkUnit = CheckUnit(newUnit);
            if(checkUnit)
            {
                SaveUnit(newUnit);
            }
        }

        private void SaveUnit(Unit newUnit)
        {   if(newUnit != null)
            {
                units.Add(newUnit);
                FullFillData();
                MessageBox.Show("Thêm thành công!");
                
                RefreshData();
            }
           
            
        }

        private void RefreshData()
        {
            txtUnitName.Text = "";
            txtQuantity.Text = string.Empty;
            chkBaseUnit.IsChecked = false;
        }

        private bool CheckUnit(Unit newUnit)
        {
            if (newUnit != null)
            {
                if(units.FirstOrDefault(x => x.UnitName.ToLower().Equals(newUnit.UnitName.ToLower())) == null)
                {
                    if (PrimitiveValueValidation.CheckName(newUnit.UnitName))
                    {
                        if(newUnit.Quantity > 0)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Số lượng phải lớn hơn 0");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đơn sai định dạng");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Tên đơn vị đã tồn tại");
                    return false;
                    
                }

            }
            else

                MessageBox.Show("Bạn cần nhập các trường của đơn vị");

            return false;
        }

        private Unit GetUnit()
        {
           Unit newUnit = new Unit();
            newUnit.UnitName = txtUnitName.Text;
            newUnit.IsBaseUnit = (bool)chkBaseUnit.IsChecked;
            int quantity;
            if(int.TryParse(txtQuantity.Text, out quantity))
            {
                newUnit.Quantity = quantity;
            }
            return newUnit;

            
        }
        private void chkBaseUnit_Checked(object sender, RoutedEventArgs e)
        {
            if (baseUnit != null)
            {
                var messageBoxResult = MessageBox.Show("Đã Có Đơn Vị Cơ Bản. Nếu muốn thay đổi. Các đơn vị khác cũng phải thay đổi theo." +
                     "Bạn có ", "Thay Đổi", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.No)
                {
                    chkBaseUnit.IsChecked = false;
                }

            }
        }
    }
}
