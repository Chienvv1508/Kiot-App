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

namespace ProjectInstaArt.UI.ManagerUI.SaleUI
{
    /// <summary>
    /// Interaction logic for SaleHomePage.xaml
    /// </summary>
    public partial class SaleHomePage : Window
    {
        List<Customer> customers;
        List<Shelf> shelves;
        List<OrderDetail> orderDetails;
        bool isExistedCustomer;
        Customer existedCustomer;
        bool isExistedProductOnShelves;
        Product productOnShelf;

        List<Product> products;
        List<Unit> listUnit;
       
        public SaleHomePage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
           InstaArtVer3Context context = new InstaArtVer3Context();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            ICustomerServices customerServices = new CustomerServices(unitOfWork);
            IShelvesServices shelvesServices = new ShelvesServices(unitOfWork);
            IProductService productService = new ProductService(unitOfWork);
            IUnitService unitService = new UnitService(unitOfWork);

            customers = customerServices.GetCustomers();
            shelves = shelvesServices.GetShelves();
            listUnit = unitService.GetAllUnit();
            products = GetProducts(shelves);
            RefreshCustomerData();
            RefreshProductFiled();
            orderDetails = null;
            lvOrderDetail.ItemsSource = null;
            
        }

        private List<Product> GetProducts(List<Shelf> shelves)
        {
           if(shelves != null)
            {
                var groupByProductCode = shelves.GroupBy(x => x.ProductCodeNavigation).ToList();
                List<Product> lsProducts = new List<Product>();
                foreach(var item in groupByProductCode)
                {
                    lsProducts.Add(item.Key);
                }
                return lsProducts;
            }return null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = GetCustomer();
            Order order;
            if(customer != null)
            {
                if (!CheckExisted(customer))
                {
                    if (CheckCutomer(customer))
                    {
                        InsertCustomer(customer);
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại sai!");
                        return;
                       
                    }
                }

                

            }
            order = GenerateOrder(customer);
            if(orderDetails != null)
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                ICustomerServices customerServices = new CustomerServices(unitOfWork);
                IOrderServices orderServices = new OrderServices(unitOfWork);
                IOrderDetailServices orderDetailServices = new OrderDetailServices(unitOfWork);
                IShelvesServices shelvesServices = new ShelvesServices(unitOfWork);

                var transaction = context.Database.BeginTransaction();
                try
                {
                    orderServices.CreateOrder(order);
                    foreach(var item in orderDetails)
                    {
                        item.OrderId = order.OrderId;
                        while (true)
                        {
                            item.OrderDetailId = GenerateId(50);
                            if (orderDetailServices.GetOrderDetail(x => x.OrderDetailId == item.ImportDetailId) == null)
                                break;
                        }
                        item.Order = null;
                        item.ProductCodeNavigation = null;
                        item.UnitNavigation = null;
                        
                        orderDetailServices.CreateOrderDetail(item);
                        Shelf shelf = shelvesServices.GetShelf(x => x.ImportDetailId == item.ImportDetailId
                        && x.ProductCode == item.ProductCode && x.Unit == item.Unit);
                        if(shelf != null)
                        {
                            shelf.Quantity -= item.Quantity;
                            shelvesServices.Update(shelf);
                        }
                    }
                    transaction.Commit();
                    MessageBox.Show("Bán thành công");
                    LoadData();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }



            }

            
            
        }

        private void InsertCustomer(Customer customer)
        {
            if(customer != null)
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                ICustomerServices customerServices = new CustomerServices(unitOfWork);

                customerServices.CreateCustomer(customer);
            }
        }

        private bool CheckCutomer(Customer customer)
        {
            if(customer !=  null)
            {
                if (!PrimitiveValueValidation.CheckPhone(customer.Phone))
                    return false;
                if (!PrimitiveValueValidation.CheckName(customer.FirstName))
                    return false;
                if (!PrimitiveValueValidation.CheckName(customer.LastName))
                    return false;
                if (!PrimitiveValueValidation.CheckText(customer.Address))
                    return false;
                return true;
            }
            return false;
        }

        private bool CheckExisted(Customer customer)
        {
            return isExistedCustomer;
        }

        private Order GenerateOrder(Customer? customer)
        {
            Order order = new Order();
            order.Customer = customer != null ? customer.Phone : null;
            order.Date = DateTime.Now.Date;
            order.OrderTitle = "";
            return order;
            
        }
        private string GenerateId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Customer GetCustomer()
        {
            Customer customer = new Customer();
            if (!isExistedCustomer)
            {
                string phone = txtPhone.Text;
                if (string.IsNullOrEmpty(phone)) return null;
                string fName = txtFirstName.Text;
                string lName = txtLastName.Text;
                string address = txtAddress.Text;
                customer.Phone = phone;
                customer.FirstName = fName;
                customer.LastName = lName;
                customer.Address = address;

            }
            else
            {
                customer = existedCustomer;
            }
            return customer;

           
        }

        private void txtPhone_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string phone = txtPhone.Text;
            if(phone.Length == 10)
            {
                var customer = customers.FirstOrDefault(x => x.Phone == phone);
                if(customer != null)
                {
                    existedCustomer = customer;
                    isExistedCustomer = true;
                    FullFillCustomer(existedCustomer);
                }
            }
            else
            {
                isExistedCustomer = false;
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAddress.Text = "";
            }
        }

        private void RefreshCustomerData()
        {
            txtPhone.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
        }

        private void FullFillCustomer(Customer existedCustomer)
        {
            if(existedCustomer != null)
            {
                txtPhone.Text = existedCustomer.Phone;
                txtFirstName.Text = existedCustomer.FirstName;
                txtLastName.Text = existedCustomer.LastName;
                txtAddress.Text = existedCustomer.Address;
            }
        }

        private void txtProductCode_SelectionChanged(object sender, RoutedEventArgs e)
        {
            isExistedProductOnShelves = false;
            if(txtProductCode.Text.Length == 15)
            {
                productOnShelf = products.FirstOrDefault(x => x.ProductCode == txtProductCode.Text);
                if (productOnShelf != null)
                {
                    isExistedProductOnShelves = true;
                    AssignUnit(productOnShelf);
                }
                else MessageBox.Show("Sản phẩm không tồn tại!");
            }
            else
            {
                txtQuantity.Text = "";
                txtImportDetailId.Text = "";
                cbUnit.ItemsSource = null;

            }
            

        }

        private void AssignUnit(Product productOnShelf)
        {
            if(productOnShelf != null && isExistedProductOnShelves == true)
            {
                List<Unit> units = new List<Unit>();
                var groupByProduct = shelves.GroupBy(x => x.ProductCodeNavigation);
                foreach ( var item in groupByProduct )
                {
                    if(item.Key.ProductCode == productOnShelf.ProductCode)
                    {
                        foreach (var item2 in item)
                        {
                            if (units.FirstOrDefault(x => x.UnitId == item2.Unit) == null)
                            {
                                Unit newUnit = listUnit.FirstOrDefault(x => x.UnitId == item2.Unit);
                                units.Add(newUnit);

                            }

                        }
                    }
                   
                    
                }
                cbUnit.ItemsSource = null;
                cbUnit.ItemsSource = units;
            }
        }

        private void RefreshProductFiled()
        {
            txtProductCode.Text = "";
            txtQuantity.Text = "";
            txtImportDetailId.Text = "";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OrderDetail orderDetail = GetOrderDetail();
            if (!CheckExistedOrderDetail(orderDetail))
            {
                if (CheckOrderDetail(orderDetail))
                {
                    SetPriceToOrderDetail(orderDetail);
                    orderDetails = orderDetails ?? new List<OrderDetail>();

                    orderDetails.Add(orderDetail);
                   
                }
            }
            else
            {
                if (CheckOrderDetail(orderDetail))
                {
                    var existedOrderDetail = orderDetails.FirstOrDefault(x => x.ProductCode == orderDetail.ProductCode
                         && x.ImportDetailId == orderDetail.ImportDetailId && x.Unit == orderDetail.Unit
                         );
                    existedOrderDetail.Quantity += orderDetail.Quantity;
                }
            }
            LoadListView();

        }

        private bool CheckExistedOrderDetail(OrderDetail orderDetail)
        {
            if(orderDetail != null)
            {
                if(orderDetails != null)
                {
                    if(orderDetails.Count != 0)
                    {
                        if (orderDetails.FirstOrDefault(x => x.ProductCode == orderDetail.ProductCode
                         && x.ImportDetailId == orderDetail.ImportDetailId && x.Unit == orderDetail.Unit
                         ) != null)
                            return true;
                        else return false;
                    }
                    return false;

                }
                return false;
            }
            return false;
        }

        private void SetPriceToOrderDetail(OrderDetail orderDetail)
        {
            if(orderDetail != null)
            {
                InstaArtVer3Context context = new InstaArtVer3Context();
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                IPriceSettingSevices priceSettingSevices = new PriceSettingsSevices(unitOfWork);
                var priceRule = priceSettingSevices.GetLastPriceSetting(x => x.IsValid == true && x.ProductCode == orderDetail.ProductCode
                && x.UnitId == orderDetail.Unit && x.Quantity <=  orderDetail.Quantity);
                if (priceRule != null)
                    orderDetail.Price = priceRule.Price;
            }
        }

        private bool CheckOrderDetail(OrderDetail orderDetail)
        {
            if(orderDetail != null)
            {
                var selectedItemOnShelves = shelves.FirstOrDefault(x => x.ProductCode == orderDetail.ProductCode
                && x.Unit == orderDetail.Unit && x.ImportDetailId == orderDetail.ImportDetailId);
                if(selectedItemOnShelves != null)
                {
                    if(orderDetails != null)
                    {
                        var existedOrderDetail = orderDetails.FirstOrDefault(x => x.ProductCode == orderDetail.ProductCode
                        && x.ImportDetailId == orderDetail.ImportDetailId && x.Unit == orderDetail.Unit
                        );
                        if (existedOrderDetail != null)
                        {
                            if (orderDetail.Quantity + existedOrderDetail.Quantity > 0 && orderDetail.Quantity + existedOrderDetail.Quantity <= selectedItemOnShelves.Quantity)
                            {
                                return true;

                            }
                            else
                            {
                                MessageBox.Show("Số lượng phải lớn hơn 0 và nhỏ hơn số lượng đang có trong shelves");
                                return false;
                            }
                        }
                    }
                    if(orderDetail.Quantity > 0 && orderDetail.Quantity <= selectedItemOnShelves.Quantity)
                    {
                        return true;

                    }
                    MessageBox.Show("Số lượng phải lớn hơn 0 và nhỏ hơn số lượng đang có trong shelves");
                    return false;

                }
                MessageBox.Show("Không tồn tại sản phẩm trên kệ!");
                return false;
            }
            MessageBox.Show("Sản phẩm không tồn tại");
            return false;
        }

        private OrderDetail GetOrderDetail()
        {
            if(isExistedProductOnShelves)
            {
                var orderDetail = new OrderDetail();
                orderDetail.ProductCode = productOnShelf.ProductCode;
                orderDetail.ProductCodeNavigation = productOnShelf;
                var unit = cbUnit.SelectedItem as Unit;
                if (unit == null) return null;
                orderDetail.Unit = unit.UnitId;
                int quantity;
                if(int.TryParse(txtQuantity.Text, out quantity))
                {
                    orderDetail.Quantity = quantity;
                }
                orderDetail.ImportDetailId = txtImportDetailId.Text;
                return orderDetail;





            }return null;
        }

        private void LoadListView()
        {
            lvOrderDetail.ItemsSource = null;
            lvOrderDetail.ItemsSource = orderDetails;
            decimal total = 0;
            if(orderDetails != null)
            {
                foreach (var item in orderDetails)
                {
                    total += item.Price * item.Quantity;
                }
                txtTotalPirce.Text = total.ToString();
            }
            
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(orderDetails != null)
            {
                var unit = cbUnit.SelectedItem as Unit;
                if(unit != null)
                {
                    OrderDetail selectedOrderDetail = orderDetails.FirstOrDefault(x => x.ProductCode == txtProductCode.Text
                && x.ImportDetailId == txtImportDetailId.Text && x.Unit == unit.UnitId);
                    orderDetails.Remove(selectedOrderDetail);
                    LoadListView();
                }
                
            }
            
        }

        private void lvOrderDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var orderdetail = lvOrderDetail.SelectedItem as OrderDetail;
            //cbUnit.SelectedValue = orderdetail.Unit;
        }

        private void btnViewOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderSearchUI orderSearchUI = new OrderSearchUI();
            orderSearchUI.Show();
            this.Hide();
            orderSearchUI.Closed += OpenSaleUI;
        }

        private void OpenSaleUI(object? sender, EventArgs e)
        {
            this.Show();
        }
    }
}
