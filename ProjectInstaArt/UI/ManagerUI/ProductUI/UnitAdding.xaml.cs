using Microsoft.EntityFrameworkCore.Diagnostics;
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
    /// Interaction logic for UnitAdding.xaml
    /// </summary>
    public partial class UnitAdding : Window
    {
        public  List<Unit> newUnits;
        List<Unit> units = new List<Unit>();
        Unit baseUnit;

        public UnitAdding(List<Unit> _units)
        {
            InitializeComponent();
            units = _units;
            newUnits = new List<Unit>();
            LoadData();

            

           
        }

        private void LoadData()
        {
            List<dynamic> dynamicUnit = new List<dynamic>();
            baseUnit = units.FirstOrDefault(x => x.IsValid == true && x.IsBaseUnit == true);
            if(baseUnit == null)
            {
                baseUnit = newUnits.FirstOrDefault(x => x.IsValid == true && x.IsBaseUnit == true);
            }
          

            if (baseUnit != null)
            {
                foreach (Unit unit in units)
                {
                    if (unit.IsValid == true)
                    {
                        var item = new { UnitId = unit.UnitId, UnitName = unit.UnitName, Quantity = unit.Quantity, BaseUnit = baseUnit.UnitName };
                        dynamicUnit.Add(item);
                    }

                }
                foreach (Unit unit in newUnits)
                {
                    if (unit.IsValid == true)
                    {
                        var item = new { UnitId = 0, UnitName = unit.UnitName, Quantity = unit.Quantity, BaseUnit = baseUnit.UnitName };
                        dynamicUnit.Add(item);
                    }

                }
                lvUnitList.ItemsSource = dynamicUnit;
                txtBaseUnit.Text = baseUnit.UnitName;
            }
            else lvUnitList.ItemsSource = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Unit unit = GetUnit();
            if(unit != null)
            {
                
                newUnits.Add(unit);

                MessageBox.Show("Thêm thành công");
               

                LoadData();
            }
        }

        private Unit GetUnit()
        {
            Unit unit = new Unit();

            string unitName = txtUnitName.Text;
            if (PrimitiveValueValidation.CheckName(unitName))
            {
                if(units.FirstOrDefault(x => x.UnitName == unitName) == null && 
                    newUnits.FirstOrDefault(x => x.UnitName == unitName) == null)
                {

                }else
                {
                    MessageBox.Show("Tên đơn vị đã tồn tại!");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Tên đơn vị sai định dạng!");
                return null;
            }

            bool isBaseUnit = (bool)chkBaseUnit.IsChecked;
            if (units.Count==0 && newUnits.Count == 0)
            {
                if(isBaseUnit)
                {

                }
                else
                {
                    MessageBox.Show("Bạn phải điền đơn vị cơ bản trước");
                    return null;
                }
            }
            else
            {
                if (isBaseUnit)
                {
                    var messageBoxResult = MessageBox.Show("Đơn vị cơ bản đã có. Nếu bạn muốn thay đổi thì bộ đơn vị sẽ thay đổi!"
                    , "", MessageBoxButton.YesNo);

                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        ChangeUnits();
                    }
                    else
                    {
                        chkBaseUnit.IsChecked = false;
                        isBaseUnit = false;
                    }
                }
            }

            int quantity;
            if(int.TryParse(txtQuantity.Text, out quantity))
            {
                if(quantity <= 0)
                {
                    MessageBox.Show("Số lượng quy đổi phải lớn hơn 0");
                    return null;
                }
            }
            else
            {

                MessageBox.Show("Số lượng quy đổi > 0");
                return null;
            }

            unit.UnitName = unitName;
            unit.IsBaseUnit = isBaseUnit;
            unit.Quantity = quantity;
            unit.IsValid = true;

            return unit;
        }

        private void ChangeUnits()
        {
            
            DeleteUnits(units);
           newUnits.Clear();
            LoadData();
        }

        private void DeleteUnits(List<Unit> units)
        {
            if(units != null)
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IUnitService unitService = new UnitService(unitOfWork);
                foreach (Unit unit in units)
                {
                    unit.IsValid = false;
                    unitService.Update(unit);
                }

               

                

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var unit = units.FirstOrDefault(x => x.UnitName.Equals(txtUnitName.Text));
            var newUnit = newUnits.FirstOrDefault(x => x.UnitName.Equals(txtUnitName.Text));
            if(unit != null)
            {
                if (unit.IsBaseUnit)
                {
                    DeleteUnits(units);
                    newUnits.Clear() ;
                }
                else
                {
                    DeleteUnit(unit);
                    units[units.IndexOf(unit)].IsValid = false;
                }
                   
            }
            else
            {
                if(newUnit != null)
                {
                    if (newUnit.IsBaseUnit)
                    {
                        DeleteUnits(units);
                        newUnits.Clear();
                    }
                    else
                        newUnits.Remove(newUnit);
                }
            }

            LoadData();
        }

        private void DeleteUnit(Unit unit)
        {
            if(unit != null)
            { 
                
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IUnitService unitService = new UnitService(unitOfWork);

                unit.IsValid = false;

                unitService.Update(unit);
            }
           
        }
    }
}
