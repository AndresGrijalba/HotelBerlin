   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	       GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	     � Title$  Hotel Berlin��5   	   $	��720��6   $
��1080��6+    � Icon$ /Images/icon.ico��5	   	    � AllowsTransparency . 
������  � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .��5      ��  �� CornerRadius$ 0��6      PrimaryColor#���   6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5      $��* �6#   .+�5      �� $ 10��6   	 �� Padding$	 5q�5      $��10q�5        BlueTransparent#���  5      ._�5      � -   5        
 �Name$
 gridMenu��5       � RowDefinitions 5      �� 5      $��60 �6(   �� 5      $	��590 �6(   �� 5       $	��110 �6(   .+�5#      �� $��0��6!    �� Orientation$ 
Horizontal=�6.   .+�5$      �� $��/Images/logo.png��6    $
��Fill=�6:   $��36��6I   $��36��6U   $��Center=�6`   $��10 0 0 0q�6{   �� 5%      $��Hotel Berlin��6      PrimaryBlueText#���  67   $
��Bold"�6f   $��24(�6x   $��Center=�6�   $
��Left=�6�   $
��Left=�6�   $��	5 -10 0 0q�6�   5&      �� 5(      $��1��6!   $��Center=�6.   .+�5)      	� -   5         	�Name$ rdEstadisticas��5)   &   $��Estadisticas��6>    % !MenuRadioButtonStyleREstadisticas#���  6U    � Cursor$
 Hand��6�   $��0 30 0 1q�6�   6�   	� 5*      -   5        $ 
rdReservas��5*   &   $��Reservas��6:      MenuRadioButtonStyleReservas#���  6M   $
 Hand��6�   $��0 1 0 1q�6�   6�   	� 5+      -   5        $ rdHabitaciones��5+   &   $��Habitaciones��6>    $  MenuRadioButtonStyleHabitaciones#���  6U   $
 Hand��6�   $��0 1 0 1q�6�   6�   	� 5,      -   5        $ 
rdUsuarios��5,   &   $��Clientes��6:      MenuRadioButtonStyleUsuarios#���  6M   $
 Hand��6�   $��0 1 0 1q�6�   6�   	� 5-      -   5        $ 
rdFacturas��5-   &   $��Facturas��6:      MenuRadioButtonStyleFacturas#���  6M   $
 Hand��6�   6�   5.      �� 50      $��2��6!   $��Center=�6.   .+�51      �� $ 18��6!   $��35��63   
������ $��0,0,0,10q�6X   ._�52      �� $ 
Horizontal=�6)   .+�53   "   �� $��Modo Oscuro��6(   $
��Left=�6>   $��Center=�6Y   $
��Bold"�6t   #���  6�   $��18(�6�   d� 54   "   -   5         d�Name$ Themes��54   /    d� 	IsChecked$ FalseY�55   /   $
 Hand��56   /   $��30 0 0 0q�57   /     ToggleButtonStyle#���  59   /   5:      5;      �� 5<      $��Administrador��6    $��25(�68   $
��Bold"�6F   #���  6X   $��38��6�   �� 5=      $��hotelberlinva@gmail.com��6    #���  6B   $��37��6q   5>      5?      5@      � 5B      $��1��6    5C      �� 5D      $��60 �6$   �� 5E      .+�5H      �� $��0��6   $��4��6*   $��Right=�6:   $	��Top=�6V   $��0,5,10,0q�6n   $��30��6�   $ 
Horizontal=�6�   $��RightToLeft=�6�   .+�5J      �� -   5         ��Name$ btnClose��5J      $��X��6/   $
 Hand��6R   $��Center=�6`   $��Center=�6{   $��SemiBold"�6�   ��5K      �� 5L       �� 
TargetType" ��6$   .�5M   "   ��  �� Property � �� �� Value# �   6?   �� 5N   "    � ��# �  6?    �� Triggers 5O   "   P� 5P   &    P� Property �@J�IsMouseOver P� Value . . �5Q   *   ��  � �� 	 PrimaryRedColor# � 	 6G   �� 5R   *    � ��# �  6G   �� 5S   *    � ��$
 Bold"�6G   5T   '   5V      ��5Y      �� 5Z       �� 
TargetType" ��6.   .R�5[   "   �� $��20��6)   $��20��64   $ 5��5\   )   #��z��5]   )   ._�5^   &   �� $��Center=�67   $��Center=�5_   7   5`   #   5a      5c      �� 5e      -	   5        $ btnMinimize��5e      $��-��62   $
 Hand��6X   $��15(�6f   $��SemiBold"�6t   ��5f      �� 5g      " ��6$   .�5h   "   ��  � ��# �   6?   �� 5i   "    � ��# �  6?    5j   "   P� 5k   &    �@J�IsMouseOver . . �5l   *   ��  � �� 
 PrimaryBackgroundColor# � 
 6G   �� 5m   *    � ��# �   6G   �� 5n   *    � ��$
 Bold"�6G   5o   '   5q      ��5t      �� 5u      " ��6.   .R�5v   "   �� $��20��6)   $��20��64   $ 5��5w   )   #��z��5x   )   ._�5y   &   �� $��Center=�67   $��Center=�5z   7   5{   #   5|      5~      5      �� 5�      $��1��6   $ 0 0 5 0��6&   
������ ._�5�       � -
   5          �Name$ frameContent��5�        � NavigationUIVisibility$ Hidden=�62   $��
10,0,20,10q�6R   5�      � 5�      .+�5�       � -   5        $ 	MainFrame��5�      5�      5�      5�      5�      5�      