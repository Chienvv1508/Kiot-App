   M S B A M L   `   `   `  ����J  FProjectInstaArt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:ProjectInstaArt.UI.ManagerUI.SaleUI#ProjectInstaArt.UI.ManagerUI.SaleUI  5   	   6    0ProjectInstaArt.UI.ManagerUI.SaleUI.SaleHomePage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:ProjectInstaArt.UI.ManagerUI.SaleUI     5   	     � Title$  SaleHomePage��5   	   $	��650��6   $
��1100��6+   .��5	      �� $
��Auto=�6   $
��Auto=�68   .��5
   
   � .+�5      �� $��20q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Trang Bán Hàng��6    
����  �$��30(�6H   $��Center=�6V   $��	400,0,0,0q�6s   �� 5      -   5        $��btnViewOrder��5   S   $��Xem Đơn Hàng��6   $��	250,0,0,0q�64   $	��200��6G   6g   5      �� 5      $ 
Horizontal=�6   $��0,40,0,0q�66   .+�5      � $	��350��6    � RowDefinitions 5      �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,   �� 5      $
��auto �6,    � ColumnDefinitions 5!      �� 5"      $	��100 �6/   �� 5#      $	��200 �6/   .+�5%      �� $��Măt Hàng: ��6    �� 5&      -   5         ��Name$ txtProductCode��5&   "   $��1��6:   $	��200��6J   $
��Left=�6V   ��5'   "   ��  �� Path$ ProductCode� �� Mode$ OneWay=� � DataContext 5(   "   ��  �� ElementName$ lvOrderDetail��.��6T   5+      �� 5,      $��Mã Nhập Hàng:  ��6    $��1��6:   $��0��6G   �� 5-      -   5        $ txtImportDetailId��5-   "   $	��200��6>   $
��Left=�6J   $��1��6f   $��1��6s   ��5.   #   �� $ ImportDetailId�$ OneWay=� 5/   %   �� $ lvOrderDetail���� 51      $��Số Lượng: ��6    $��2��65   $��0,5,0,5q�6B   �� 52      -   5        $��txtQuantity��52   K   $��2��6"   $��1��6/   $	��200��6?   $��0,5,0,5q�6^   ��53   "   �� $ Quantity�$ OneWay=� 54      �� $ lvOrderDetail���� 57      $��3��6$   $��
Đơn vị��61   �� 58      -   5        $��cbUnit��5:   #   $��3��58   #   $��1��60   	 �� DisplayMemberPath$	 UnitName��6@   
 �� SelectedValuePath$
 UnitId��59   #   5:   #   �� 5@      $��5��6%   $��2��62   $ 
Horizontal=�6F   $��0,5,0,0q�6_   $	��330��6p   .+�5A      �� -   5        $��	btnUpdate��5A   Q   $��Sửa��6%   $��	45,5,20,0q�63   $��70��6F   6Q   �� 5B      -   5        $��	btnDelete��5B   P   $
��Xóa��6%   $��70��63   $��0,5,20,0q�6>   6a   �� 5C      -   5        $��btnAdd��5C   P   $��Thêm��6%   $��70��64   $��0,5,0,0q�6?   6^   5E      �� 5F      $��6��6    $��2��6-   $$��Nhập thông tin khách hàng��6A   
����  �$��Center=�5G      $��0,10,0,0q�6$   $
��Bold"�5H      $��15(�6   �� 5I      $��Phone: ��6    $��7��62   $��0,5,0,0q�6?   �� 5J      -	   5        $��txtPhone��5J   K   $��7��6"   $��1��6/   $	��200��6?   $��0,5,0,0q�6[   6l   �� 5L      -
   5         ��Name$ txtCheck��5L   $   $��8��66   $��1��6C   $��0,5,0,0q�6S   
����  �6d   �� 5M      $��Họ: ��6    $��9��6/   $��0,5,0,0q�6<   �� 5N      -   5        $��txtLastName��5N   K   $��9��6"   $��1��6/   $	��200��6?   $��0,5,0,0q�6^   �� 5O      $��Tên: ��6    $��10��60   $��0,5,0,0q�6>   �� 5P      -   5        $��txtFirstName��5P   L   $��10��6"   $��1��60   $	��200��6@   $��0,5,0,0q�6`   �� 5Q      $��Địa Chỉ: ��6    $��11��64   $��0,5,0,0q�6B   �� 5R      -   5        $��
txtAddress��5R   L   $��11��6"   $��1��60   $	��200��6@   $��0,5,0,0q�6^   �� 5S      $��12��6%   $��2��63   $ 
Horizontal=�6G   .+�5T      �� $��Làm mới ��6%   $��	70,5,50,0q�68   $��70��6K   �� 5U      $��Thêm��6%   $��70��64   $��0,5,0,0q�6?   5W      5X      �� 5Y      $ Vertical=�6!   $	��567��68   $��10,0,0,0q�6D   .+�5Z      �� $��Hóa Đơn Mua Hàng��6    $��Center=�6;   $
��Bold"�6X   $��15(�5[      �� 5\      $ 
Horizontal=�6%   .+�5]      �� .+�5^   "   �� $ 
Horizontal=�6-   .+�5_   &   �� $��Khách hàng: ��6,   �� 5`   &   -   5        $ txtcustomerName��5`   0   $	��120��6I   5b   #   �� 5c   "   $ 
Horizontal=�6-   .+�5d   &   �� $��Số điện thoại: ��6,   �� 5e   &   -   5        $ txtCustomerPhone��5e   0   $	��120��6J   5g   #   �� 5h   "   $ 
Horizontal=�6-   .+�5i   &   �� $��Địa chỉ: ��6,   �� 5j   &   -   5        $ txtCustomerArrdess��5j   0   $	��120��6L   5l   #   5n      �� 5o      $ 
Horizontal=�6)   $	��203��6B   $��60,0,0,0q�6N   .+�5p   "   �� $��Ngày: ��6(   $��30��69   $	��Top=�6E   �� 5q   "   -   5        $ txtorderDate��5q   ,   $	��120��6B   $��30��6N   $	��Top=�6Z   5s      5u      �� 5v      -   5         ��Name$ lvOrderDetail��5v   $    �� View 5w      �� 5x   "   .P�5y   &   �� $	��STT��65    �� Width$ 50��6C   �� 5z   &   $��Tên Sản Phẩm��65   $	 200��6L    �� DisplayMemberBinding 6X   �� $' !ProductCodeNavigation.ProductName��� 5{   &   $��Số Lượng��65   $ 90��6H    6S   �� $ Quantity��� 5|   &   $
��Giá��65   $	 200��6C    6O   �� $ Price�5   #   5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Số tiền cần trả: ��6$   �� 5�      -   5        $ txtTotalPirce��5�   (   $��20,0,0,0q�6?   $	��150��6Q   5�      �� 5�      -   5         ��Name$ btnSave��5�   !   $
��Lưu��62   $��Right=�6@   $	��100��6\   $��0,20,0,0q�6h   6z   5�      5�      5�      5�      5�      5�      