   M S B A M L   `   `   `  ����J  FProjectInstaArt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ProjectInstaArt.UI.ManagerUI.ProductUI&ProjectInstaArt.UI.ManagerUI.ProductUI  5   	   ?    9ProjectInstaArt.UI.ManagerUI.ProductUI.CategoryManagement   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:ProjectInstaArt.UI.ManagerUI.ProductUI     5   	     � Title$  CategoryManagement��5   	   $	��450��6$   $	��800��61   .��5      �� $
��Auto=�6   $
��Auto=�66   .��5   
   � .+�5      �� $��15q�6   .+�5      �� $$��Quản Lý Loại Sản Phẩm��6   $��30(�69   
����  �$��Center=�6Y   �� 5      -   5         ��Name$ stForm��5      $��0,30,0,0q�6-   .+�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��Mã Loại Hàng:��6    $	��100��68   �� 5      -   5         ��Name$ txtCategoryId��5   "   $��10,0,0,0q�69   $	��300��6K   ${�False��5      ��5      ��  �� Path$ 
CategoryId� �� Mode$ OneWay=� � DataContext 5      ��  �� ElementName$ 
lvCategory��$ SelectedItem�5      5      �� 5      $ 
Horizontal=�6!   $��0,20,0,0q�6:   .+�5      �� $��Tên Loại Hàng:��6    $	��100��69   �� 5      -   5        $ txtCategory��5   "   $��10,0,0,0q�67   $	��300��6I   ��5      �� $ CategoryName�$ OneWay=� 5      �� $ 
lvCategory��$ SelectedItem�6]   5      5      �� 5       $ 
Horizontal=�6   $��0,30,0,0q�66   .+�5!      �� -   5        $��btnAdd��5!   ?   $��Thêm Đơn Vị��6   $	��150��63   6M   �� 5"      -   5        $��	btnUpdate��5"   J   $��Sửa��6   $	��150��6+   $��	30,0,30,0q�67   6[   �� 5#      -   5        $��	btnDelete��5#   7   $
��Xóa��6   $	��150��6+   6H   5%      �� 5&      -   5         ��Name$ 
lvCategory��5&      $��0,30,0,0q�6/   $	��500��6A   $
��Left=�6M   	 �� View	 5'      �� 5(      .P�5)      �� $��Mã Loại Hàng��6-   
 �� Width$	
 200��6C    �� DisplayMemberBinding 6O   �� $ 
CategoryId��� 5*      $��Tên Loại Hàng��6-   $	
 300��6D    6P   �� $ CategoryName�5,      5.      51      53      54      56      