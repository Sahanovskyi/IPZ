   M S B A M L   `   `   `  ���� K  GGoods Accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ipz_labar1
ipz_labar1      ipz_labar1.EditItemView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     .	ipzLabar1clr-namespace:ipz_labar1     $��410.722��$��301.346��   
background#���     � Icon$  Images/icon.ico�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � Title �� *edit_add_title+.��� .+�� $
��Auto��$��
10,10,20,0q�$��Stretch=�$	��Top=� � ColumnDefinitions �� $��62 ���  � RowDefinitions �� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 �.+��� $��5q�  	edit_name#���  $��RightToLeft=�$��14(��� -    ��Name$
 Name��$��0��$��1��$��1��$
��Auto��$
��Auto��$��5q�$��Stretch=�$��Stretch=� �� MaxLines$ 1��  WaterMarkTextBox#���  $��1�� �� TextWrapping$
 Wrap=�$   ipz_labar1.WaterMarkTextHelper	   WatermarkText$	  ������ *EditStrings[0]+
 �� Mode$
 TwoWay=��� $��1��$��5q�  
edit_price#���  $��RightToLeft=�$��14(��� -   $ Price��$��1��$��1��$��1��$
��Auto��$
��Auto��$��5q�$��Stretch=�$��Stretch=�$ 1��#���  $��2��$
 Wrap=�$	  ������ *EditStrings[1]+$
 TwoWay=��� $��2��$��5q�  	edit_type#���  $��RightToLeft=�$��14(��� -   $
 Type��$��2��$��1��$
��Auto��$
��Auto��$��5q�$��Stretch=�$��Stretch=�$ 1��#���  $��3��$
 Wrap=�$	  ������ *EditStrings[2]+$
 TwoWay=��� $��3��$��5q�  
edit_count#���  $��RightToLeft=�$��14(��� -   $ Count��$��3��$��1��$
��Auto��$
��Auto��$��5q�$��Stretch=�$��Stretch=�$ 1��#���  $��4��$
 Wrap=�$	  ������ *EditStrings[3]+$
 TwoWay=��� $��4��$��5q�  edit_ID#���  $��RightToLeft=�$��14(��� -   $ ID��$��4��$��1��$
��Auto��$
��Auto��$��5q�$��Stretch=�$��Stretch=� �� 	MaxLength$ 6��$ 1��#���  $��5��$
 Wrap=�$	  ������ *EditStrings[4]+$
 TwoWay=�� $	��212��$��40��$��	0,0,20,10q�$��Right=�$��Bottom=� �� �� .+��� -    ��Name$ editBtnCancel��$
��Auto��$
��Auto��$��5q�$��Stretch=�  cancel_titel#���  $��Cambria)�$��16(�$��Normal$�  btnLogIn#���  $��7������ *Cancel+�� -   $ 	editBtnOk��$��1��$
��Auto��$
��Auto��$��5q�$��Stretch=� 	 OK_titel#��� 	 $��Cambria)�$��16(�$��Normal$�#���  $��6������ *AddEd+