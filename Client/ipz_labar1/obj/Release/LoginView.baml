   M S B A M L   `   `   `  ���� K  GGoods Accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ipz_labar1.Propertiesipz_labar1.Properties  5clr-namespace:ipz_labar1.Helperipz_labar1.Helper  'clr-namespace:ipz_labar1
ipz_labar1  'clr-namespace:ipz_labar1
ipz_labar1      ipz_labar1.LoginView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :
Properties#clr-namespace:ipz_labar1.Properties     -hclr-namespace:ipz_labar1.Helper     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  )
ipz_labar1clr-namespace:ipz_labar1  $localclr-namespace:ipz_labar1  -     �Name$  Log_In��   
LoginTitle � Title# �   $	��375��$	��370��  
background#���   � Icon$ Images/icon.ico�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � DataContext    ipz_labar1.LoginViewModel  .��� $��0q� J� RenderTransformOrigin$	 0,0&�.+�� $	��130��$��0q�$	��Top=�.+��� $��
126,0,50,0q�$��Center=�$��Goods 
Accounting��$��Pristina)�$��42(�$��	ExtraBold"�$��5,10,5,5q�$ 0.5,0.5&�&   System.Windows.Media.TextOptions   TextHintingMode$ Animated=��� $	��111��$	��110��$��	10,10,0,0q�$
��Left=�$	��Top=�$ 0.5,0.5&�$"��Images/industry-forklift.png��z�V� .~���  �� ScaleX$ 1Q�	 �� ScaleY$	 1Q��� 
 �� AngleX$
 0Q� �� AngleY$ 0Q���  �� Angle$ 0Q�T� �� $��35��$��35��$��	0,10,10,0q�$��Right=�$	��Top=�$��Button��$ -0.314,4.229&�  controlMainButtonStyle#���  ��Z� ���� *	Setting+��Z� ����  �� ImageSource$ Images/setting.png�� j� Stretch$ Uniform=�� $	��211��$��0q�$��Bottom=�.+��� $��	84,96,0,0q�$
��Left=�$	��Top=�$��Center=����	#FF6B94FF  RememberTitle#���  $��0q�$��3�� d� 	IsChecked ��   ipz_labar1.Settings1   Default �� Source# Z  �� Path$ Remember� �� Mode$ TwoWay=�G� -    G�Name$ loginPassword��$	��200��$��30��$��0,56,0,0q�$��Center=�$	��Top=�$��Center=�$��2��,   &ipz_labar1.Helper.PasswordBoxAssistant   BindPassword .    BoundPassword �� $ password�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $	��200��$��30��$��
0,21,0,160q�$��Center=�$	��Top=�  WaterMarkTextBox#��[ $   ipz_labar1.WaterMarkTextHelper   WatermarkText$ Username������ *
username+� $	��140��$��35��$��0,0,0,47q�$��Center=�$��Bottom=�.+��� -    ��Name$ btnLogin��$��0��$
��Auto��$
��Auto��$��Stretch=�  LoginButton#���    btnLogIn#��[ $��4������ *Login+�� $��0��$	��140��$��	0,170,0,0q�$��Center=�$	��Top=�  CreateNewAcText#���   � Cursor$
 Hand��$��Cambria)�$��Italic$�$��5����Z� ��Z� ���� *Create+