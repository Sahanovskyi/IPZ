   M S B A M L   `   `   `  ����K  GGoods Accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ipz_labar1.Helperipz_labar1.Helper  5   	   'clr-namespace:ipz_labar1
ipz_labar1  5   	   'clr-namespace:ipz_labar1
ipz_labar1  5   	       ipz_labar1.RegisterView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2helperclr-namespace:ipz_labar1.Helper     5   	   /
ipz_labar1clr-namespace:ipz_labar1     5   	   *localclr-namespace:ipz_labar1     5   	      RegisterTitle  � Title#  �   5   	   $	��460��5   	   $	��345��5	   	   $	��420��5
   	   $	��320��5   	     
background#���  5   	    � Icon$ Images/icon.ico��5   	    � 
ResizeMode$ NoResize=�5   	    � DataContext 5      "  ipz_labar1.RegisterViewModel  5   
   .��5      � .+�5   
   �� $��0,0,0,20q�6   $��Center=�5      $��Bottom=�5        RegisterBtnTitle#���  5        btnLogIn#���  5      $��8��5      ��5      �� *
Register+5      �� 5   
   $��
21,156,0,0q�6   $
��Left=�5      $	��Top=�5        borderBrush#���  5        RegisterCheckTitle#���  5      $��5��5        d� 	IsChecked 5      ��  �� Path$ exist� �� Mode$ TwoWay=�5       �� 5!   
   $��	10,10,0,0q�6   $
��Left=�5"      $	��Top=�5#        RegisterFirstInfo#���  5$      �� 5%   
   $��
10,125,0,0q�6   $
��Left=�5&      $	��Top=�5'      $:��4Create a new warehouse or connect to exist warehouse��5(      � 5)   
   $��0��6   $��1��5*      $��30��5+      $��
10,84,10,0q�5,      $	��Top=�5-       � ColumnDefinitions 5.      �� 5/      $
��203* �6#   �� 50      $
��191* �6#   .+�52      �� -   5         ��Name$ RegUsername��52      $��1��53      $
��Auto��54      $
��Auto��55      $��0,0,5,0q�56      $��Stretch=�57      $��Stretch=�58      	 �� 	MaxLength$	 50��59      
 �� MaxLines$
 1��5:        WaterMarkTextBox#���  5;      $��3��5<       �� TextWrapping$
 Wrap=�5>      $   ipz_labar1.WaterMarkTextHelper   WatermarkText$ Username��5?      ��5=      �� *
username+5?      G� 5@      -   5         G�Name$ RegUserPass��5@      $��1��5A      $��5,0,0,0q�5B       G� 	MaxLength$ 30��5C      $��4��5D      ,   &ipz_labar1.Helper.PasswordBoxAssistant   BindPassword .    BoundPassword 5F      �� $ PassUser�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5J      5K      � 5L   
   $��0��6   $��1��5M      $��30��5N      $��10,185,10,0q�5O      $	��Top=�5P       5Q      �� 5R      $
��102* �6#   �� 5S      $	��95* �6#   .+�5U      �� -   5        $ RegUsername1��5U      $��1��5V      $
��Auto��5W      $
��Auto��5X      $��0,0,5,0q�5Y      $��Stretch=�5Z      $��Stretch=�5[      $		 100��5\      $
 1��5]      #���  5^      $��6��5_      $
 Wrap=�5a      $ Warehouse name��5b      ��5`      �� *warehousename+5b      G� 5c      -   5        $ RegWarePass��5c      $��1��5d      $��5,0,0,0q�5e      $ 30��5f      $��7��5g       .  5i      �� $ PassWare�$ TwoWay=�$ PropertyChanged=�5l      � 5m   
   $��2��6   $��2��5n      $��30��5o      $��
10,41,10,0q�5p      $	��Top=�5q       5r      �� 5s      $
��169* �6#   �� 5t      $
��225* �6#   .+�5v      �� -   5        $ RegFirstName��5v      $
��Auto��5w      $
��Auto��5x      $��0,0,5,0q�5y      $��Stretch=�5z      $��Stretch=�5{      $	 30��5|      $
 1��5}      #��[ 5~      $��1��5      $
 Wrap=�5�      $ 
First name��5�      ��5�      �� *	firstName+5�      �� 5�      -   5        $ RegLastName��5�      $��1��5�      $
��Auto��5�      $
��Auto��5�      $��5,0,0,0q�5�      $��Stretch=�5�      $��Stretch=�5�      $	 50��5�      $
 1��5�       J� RenderTransformOrigin$ 0.399,-0.033&�5�      #���  5�      $��2��5�      $
 Wrap=�5�      $ 	Last name��5�      ��5�      �� *
lastName+5�      5�      5�      5�      