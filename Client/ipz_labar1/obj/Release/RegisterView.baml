   M S B A M L   `   `   `  ���� K  GGoods Accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ipz_labar1.Helperipz_labar1.Helper  'clr-namespace:ipz_labar1
ipz_labar1  'clr-namespace:ipz_labar1
ipz_labar1      ipz_labar1.RegisterView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2helperclr-namespace:ipz_labar1.Helper     /
ipz_labar1clr-namespace:ipz_labar1     *localclr-namespace:ipz_labar1        RegisterTitle  � Title#  �   $	��460��$	��345��$	��420��$	��320��  
background#���   � Icon$ Images/icon.ico�� � 
ResizeMode$ NoResize=� � DataContext "  ipz_labar1.RegisterViewModel  .��� .+��� $��0,0,0,20q�$��Center=�$��Bottom=�  RegisterBtnTitle#���    btnLogIn#���  $��8������ *
Register+�� $��
21,156,0,0q�$
��Left=�$	��Top=�  borderBrush#���    RegisterCheckTitle#���  $��5�� d� 	IsChecked ��  �� Path$ exist� �� Mode$ TwoWay=��� $��	10,10,0,0q�$
��Left=�$	��Top=�  RegisterFirstInfo#���  �� $��
10,125,0,0q�$
��Left=�$	��Top=�  RegisterLastInfo#���  � $��0��$��1��$��30��$��
10,84,10,0q�$	��Top=� � ColumnDefinitions �� $
��203* ��� $
��191* �.+��� -    ��Name$ RegUsername��$��1��$
��Auto��$
��Auto��$��0,0,5,0q�$��Stretch=�$��Stretch=�	 �� 	MaxLength$	 50��
 �� MaxLines$
 1��  WaterMarkTextBox#���  $��3�� �� TextWrapping$
 Wrap=�$   ipz_labar1.WaterMarkTextHelper   WatermarkText$ Username������ *
username+G� -    G�Name$ RegUserPass��$��1��$��5,0,0,0q� G� 	MaxLength$ 30��$��4��,   &ipz_labar1.Helper.PasswordBoxAssistant   BindPassword .    BoundPassword �� $ PassUser�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�� $��0��$��1��$��30��$��10,185,10,0q�$	��Top=� �� $
��102* ��� $	��95* �.+��� -   $ RegUsername1��$��1��$
��Auto��$
��Auto��$��0,0,5,0q�$��Stretch=�$��Stretch=�$		 100��$
 1��#���  $��6��$
 Wrap=�$ Warehouse name������ *warehousename+G� -   $ RegWarePass��$��1��$��5,0,0,0q�$ 30��$��7�� .  �� $ PassWare�$ TwoWay=�$ PropertyChanged=�� $��2��$��2��$��30��$��
10,41,10,0q�$	��Top=� �� $
��169* ��� $
��225* �.+��� -   $ RegFirstName��$
��Auto��$
��Auto��$��0,0,5,0q�$��Stretch=�$��Stretch=�$	 30��$
 1��#��[ $��1��$
 Wrap=�$ 
First name������ *	firstName+�� -   $ RegLastName��$��1��$
��Auto��$
��Auto��$��5,0,0,0q�$��Stretch=�$��Stretch=�$	 50��$
 1�� J� RenderTransformOrigin$ 0.399,-0.033&�#���  $��2��$
 Wrap=�$ 	Last name������ *
lastName+