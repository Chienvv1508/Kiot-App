   M S B A M L   `   `   `  ����J  FProjectInstaArt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ProjectInstaArt.UI.ManagerUI.ProductUI&ProjectInstaArt.UI.ManagerUI.ProductUI  5   	   7    1ProjectInstaArt.UI.ManagerUI.ProductUI.AddProduct   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:ProjectInstaArt.UI.ManagerUI.ProductUI     5   	     � Title$  
AddProduct��5   	   $	��600��6   $	��800��6)   .��5	      �� $
��Auto=�6   $
��Auto=�66   .��5
   
   � .+�5      �� $��15q�6   .+�5      �� $��Thêm Sản Phẩm��6   $��30(�61   
����  �$��Center=�6Q   �� 5      -   5         ��Name$ stForm��5      $��0,20,0,0q�6-   .+�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��Mã Sản Phẩm:��6    $	��120��67   �� 5      -   5         ��Name$ txtProductCode��5   "   $	��300��6:   $��20,0,0,0q�6F   ��5      ��  �� Path$ ProductCode� �� Mode$ OneWay=� � DataContext 5      ��  �� ElementName$ 
lvProducts��$ SelectedItem�5      �� 5      $ 
Horizontal=�6!   $��0,10,0,0q�6:   .+�5      �� $��Tên Sản Phẩm:��6    $	��120��69   �� 5      -   5        $ txtProductName��5   "   $	��300��6:   $��20,0,0,0q�6F   ��5      �� $ ProductName�$ OneWay=� 5      �� $ 
lvProducts��$ SelectedItem�5      �� 5      $ 
Horizontal=�6!   $��0,10,0,0q�6:   .+�5      �� $��Công Ty Sx:��6    $	��120��66   �� 5       -   5        $ 
txtCompany��5    "   $	��300��66   $��20,0,0,0q�6B   ��5!      �� $ Company�$ OneWay=� 5"      �� $ 
lvProducts��$ SelectedItem�5&      �� 5'      $ 
Horizontal=�6!   $��0,10,0,0q�6:   .+�5(      �� $��Mô Tả Sản Phẩm:��6    $	��120��6:   �� 5)      -   5        $ txtDescription��5)   "   $	��300��6:   $��20,0,0,0q�6F   ��5*      �� $ Description�$ OneWay=� 5+      �� $ 
lvProducts��$ SelectedItem�5/      �� 50      $ 
Horizontal=�6!   $��0,10,0,0q�6:   .+�51      �� $��Loại Sản Phẩm:��6    $	��120��69   �� 52      -   5        $��
cbCategory��52   #    �� 
IsEditable$
 True��65   $	��300��6G   $��20,0,0,0q�6S   	 �� DisplayMemberPath$	 CategoryName��53      
 �� SelectedValuePath$
 
CategoryId��54      6>   57      5:      �� 5;      -   5        $��
btnAddUnit��5;   l   $��Thêm Bộ Đơn Vị��6   $	��200��62   $��	0,20,0,20q�6>   $
��Left=�6Q   6~   �� 5<      $ 
Horizontal=�6   $��0,10,0,0q�66   .+�5=      �� -   5        $��btnAddProduct��5=   8   $��Thêm��6   $	��150��6,   6M   �� 5>      -	   5        $��Sửa��5>      $	��150��6+   $��	30,0,30,0q�67   6J   �� 5?      -
   5        $��	btnDelete��5?   7   $
��Xóa��6   $	��150��6+   6H   5A      �� 5B      -   5         ��Name$ 
lvProducts��5B      $��0,30,0,0q�6/   $	��750��6A    �� View 5C      �� 5D      .P�5E      �� $��Mã sản phẩm��6-    �� Width$	 150��6B    �� DisplayMemberBinding 6N   �� $ ProductCode��� 5F      $��Tên sản phẩm��6-   $	 150��6C    6O   �� $ ProductName��� 5G      $��Loại sản phẩm��6-   $	 150��6D    6P   �� $ CategoryName��� 5H      $��Công ty sản xuất��6-   $	 150��6G    6S   �� $ Company��� 5I      $��Mô tả sản phẩm��6-   $	 150��6E    6Q   �� $ Description��� 5J      $��	Giá Bán��6-   $	 150��6>    6J   �� $ Description�5K      5M      5O      5S      5T      5U      