   M S B A M L   `   `   `  ����J  FProjectInstaArt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ProjectInstaArt.UI.CommonUIProjectInstaArt.UI.CommonUI  5   	   '    !ProjectInstaArt.UI.CommonUI.Login   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ProjectInstaArt.UI.CommonUI     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Login��5	      $	��300��6   $	��500��6   .��5
      � $��0,50,0,0q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��ĐĂNG NHẬP��6   $
��Bold"�6$   
����  �$��2��6H   $��Center=�6\   �� 5   
   $��Tài Khoản: ��6   $��0��6&   $��1��66   $��Center=�6C   $��5q�6`   �� 5   
   $��Mật Khẩu: ��6   $��0��6%   $��2��65   $��Center=�6B   $��5q�6_   �� 5   
   -   5        $��txtUserName��5      $��1��6%   $��1��65   $	��300��6B   $
��Left=�6N   $��5q�6i   G� 5   
   -   5        $��txtPassWord��5      $��1��6)   $��2��69   $	��300��6F   $
��Left=�6R   $��5q�6m   �� 5   
   $��3��6   $��2��6"    �� Orientation$ 
Horizontal=�66   .+�5      �� -   5        $��btnLogin��5   m   $��Đăng Nhập��6   $��30��6)   $	��100��65   $	��Top=�6A   $��
80,15,10,0q�6Y   6}   �� 5      $��
Đăng Ký��6   $��30��6'   $	��100��63   $	��Top=�6?   $��
5,15,15,15q�6W   �� 5      $��Quên Mật Khẩu��6   $��30��6-   $	��100��69   $	��Top=�6E   $��
5,15,15,15q�6]   5!      5%      5&      