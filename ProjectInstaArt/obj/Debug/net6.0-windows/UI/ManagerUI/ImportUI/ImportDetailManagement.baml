   M S B A M L   `   `   `  ����J  FProjectInstaArt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:ProjectInstaArt.UI.ManagerUI.ImportUI%ProjectInstaArt.UI.ManagerUI.ImportUI  5   	   B    <ProjectInstaArt.UI.ManagerUI.ImportUI.ImportDetailManagement   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:ProjectInstaArt.UI.ManagerUI.ImportUI     5   	     � Title$  ImportDetailManagement��5   	   $	��700��6(   $	��800��65   .��5	      � .+�5
   
   �� $��15q�6   .+�5      �� $#��Quản Lý Lần Nhập Hàng��6   $��30(�65   
����  �$��Center=�6U   �� 5      $	��430��6   $��	10,40,0,0q�6%   $
��Left=�68   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Mã Sản Phẩm: ��6   $��0,0,20,0q�64   $	��100��6F   �� 5      -   5         ��Name$ txtProductCode��5      $	��300��66   5      �� 5      $ 
Horizontal=�6   $��0,10,0,0q�66   .+�5      �� $��Tên Sản Phẩm: ��6   $	��100��65   $��0,0,20,0q�6A   �� 5      -   5        $ txtProductName��5      $	��300��66   5      �� 5      -   5         ��Name$ lvViewProduct��5      $	��300��63   $��0,0,10,0q�6?   $��Right=�6Q   $y�Hidden=�6m    �� View 5      �� 5      .P�5      �� $��Tên Sản Phẩm��6-    �� DisplayMemberBinding 6C   ��  �� Path$ ProductName�5      5!      �� 5"      $ 
Horizontal=�6   $��0,10,0,0q�66   .+�5#      �� $��Loại Sản Phẩm: ��6   $��0,0,20,0q�66   $	��100��6H   �� 5$      -   5        $��cbProductCategory��5$      $	��300��68    �� 
IsEditable$
 True��6D    �� DisplayMemberPath$ CategoryName��5%      	 �� SelectedValuePath$	 
CategoryId��5&      5(      �� 5)      $ 
Horizontal=�6   $��0,10,0,0q�66   .+�5*      �� $��Đơn Vị Tính: ��6   $��0,0,20,0q�64   $	��100��6F   �� 5+      -   5        $��cbUnit��5+      $	��300��6-   $
 True��69   $ UnitName��5,      $	 UnitId��5-      5/      �� 51      $ 
Horizontal=�6   $��0,10,0,0q�66   .+�52      �� $��Giá ��6   $	��100��6+   $��0,0,20,0q�67   �� 53      -   5        $��txtCost��53      $	��300��6-   55      �� 56      $ 
Horizontal=�6   $��0,10,0,0q�66   .+�57      �� $��Số Lương: ��6   $	��100��61   $��0,0,20,0q�6=   �� 58      -   5        $��txtQuantity��58      $	��300��61   5:      �� 5;      $ 
Horizontal=�6   $��0,10,0,0q�66   .+�5<      �� $��Ngày Sản Xuất ��6   $	��100��65   $��0,0,20,0q�6A   (  "System.Windows.Controls.DatePicker  5=      -   5        $��	dtMFGDate��5=   !   $	��300��63   5?      �� 5@      $ 
Horizontal=�6   $��0,10,0,0q�66   .+�5A      �� $��Ngày Hết Hạn ��6   $	��100��64   $��0,0,20,0q�6@     5B      -	   5        $��dtExpiredDate��5B   !   $	��300��67   5D      5H      �� 5I      -
   5        $ 
lvProducts��5I      $��0,30,0,0q�6+   $	��750��6=    5J      �� 5K      .P�5L      �� $��Mã sản phẩm��6)   
 �� Width$	
 150��6>    6J   �� $ ProductCode��� 5M      $��Tên sản phẩm��6)   $	
 150��6?    6K   �� $ ProductName��� 5N      $��Loại sản phẩm��6)   $	
 150��6@    6L   �� $ CategoryName��� 5O      $��
Đơn Vị��6)   $	
 150��69    6E   �� $ Company��� 5P      $
��Giá��6)   $	
 150��66    6B   �� $ Description�5Q      5S      5T      5U      5V      