   M S B A M L   `   `   `  ����K  GGoods Accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ipz_labar1
ipz_labar1  5   	   =#clr-namespace:ipz_labar1.Propertiesipz_labar1.Properties  5   	       ipz_labar1.SettingView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .	ipzLabar1clr-namespace:ipz_labar1     5   	   :
properties#clr-namespace:ipz_labar1.Properties     5   	     � Title$  Goods Accounting: Setting��5   	   $	��330��5   	   $	��188��5   	      
background#���   5	   	    � Icon$ Images/icon.ico��5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5         ipz_labar1.LoginViewModel  5   
   .��5      � .+�5   
   � $
��Auto��6   $
��auto��5      $��
10,10,10,0q�5      $��Stretch=�5      $	��Top=�5       � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��50 �6     � ColumnDefinitions 5      �� 5      $	��45* �6#   �� 5      $
��106* �6#   .+�5       �� $��5q�6   $��
IP Address��5!      $��RightToLeft=�5"      $��14(�5#      �� 5$      $��1��6   $��5q�5%       �� MaxLines$ 1��5&        WaterMarkTextBox#���  5'      $��1��5(       �� TextWrapping$
 Wrap=�5*      $   ipz_labar1.WaterMarkTextHelper	   WatermarkText$	  ��5+      ��5)      �� *ip+5+      �� 5,      $��1��6   $��5q�5-      $
��Port��5.      $��RightToLeft=�5/      $��14(�50      �� 51      $��1��6   $��1��52      $��5q�53      
 �� 	MaxLength$
 5��54      $ 1��55      #���  56      $��2��57      $
 Wrap=�59      $	  ��5:      ��58      �� *port+5:      � 5;      $��2��6   $��1��5<      $��0,10,0,0q�5=       5>      �� 5?      �� 5@      .+�5B      �� $
��Auto��6   $
��Auto��5C      $��5q�5D      $��Stretch=�5E      $��Cancel��5G      $��Cambria)�5H      $��16(�5I      $��Normal$�5J        btnLogIn#���  5K      $��4��5L      ��5F      �� *Cancel+5L      �� 5M      $��1��6   $
��Auto��5N      $
��Auto��5O      $��5q�5P      $��Stretch=�5Q      $��OK��5S      $��Cambria)�5T      $��16(�5U      $��Normal$�5V      #���  5W      $��3��5X      ��5R      �� *Ok+5X      5Y      5Z      5\      5]      