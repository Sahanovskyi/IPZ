   M S B A M L   `   `   `  ���� K  GGoods Accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ipz_labar1.Helperipz_labar1.Helper  'clr-namespace:ipz_labar1
ipz_labar1      ipz_labar1.MainView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2helperclr-namespace:ipz_labar1.Helper     *localclr-namespace:ipz_labar1     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  $	��701��$	��401��$	��715��$	��320��   
background#���     � Icon$  Images/icon.ico�� � WindowStartupLocation$ CenterScreen=� � Title �� *Title+{��� *IsEnabledWindow+ � WindowState ��   ipz_labar1.Settings1   Default �� Source# Z  �� Path$ MainWindowState� �� Mode$ TwoWay=� � DataContext    ipz_labar1.MainViewModel  .��� .+��� -   $��listView��$��5,79,5,5q�$	 �� IsSynchronizedWithCurrentItem$
	 TrueY����� $ GetItems�
 �� SelectedIndex
 �� *
selected+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseDoubleClick��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *Edit+ �� View �� .P���  �� Width$ 50�� �� DisplayMemberBinding �� *number+.���� $��#������ *
SortNumber+�� $	 220�� �� *name+.����   	edit_name#���  ���� *
SortName+�� $	 100�� �� *price+ �� StringFormat$ {0:C}��.����   
edit_price#���  ���� *	SortPrice+�� $	 100�� �� *type+.����   	edit_type#���  ���� *
SortType+�� $	 100�� �� *count+.����   
edit_count#���  ���� *	SortCount+�� $ 80�� �� *id+$ 
{0:000000}��.����   edit_ID#���  ���� *SortID+�� -   $��	btnLogOut��$��80��$��30��$��	0,15,10,0q�$��Right=�$	��Top=�
������� 
 logOut#���  $��Segoe WP Semibold)�$��14(�$��Normal$����	#FF2DA4D1 J� Opacity$ 0.925Q�  btnLogIn#���  ��Z� ���� *LogOut+ J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Opacity$	 0.9Q�   Color$ 	#FFCFDAFF��� $
��Auto��$��50��$��5,15,0,0q�$
��Left=�$	��Top=� � ColumnDefinitions �� $��55 ��� $��55 ��� $��55 ��� $��55 �.+��� $
��Auto��$
��Auto��$	��5,0q�$��Stretch=�  Effect1# �  $��Segoe WP Semibold)�$��16(�$��Normal$� �� IsCancel .  	 controlMainButtonStyle#��� 	  
 main_toolTip_add � ToolTip# � 
 ��Z� ���� *Add+��Z� ����  �� ImageSource$ Images/add-notes.png�� j� Stretch$ Uniform=��� $��1��$
��Auto��$
��Auto��$	��5,0q�$��Stretch=�# �  $��Segoe WP Semibold)�$��16(�$��Normal$�#��� 	   main_toolTip_edit# �  ��Z� ���� *Edit+��Z� ���� $ Images/edit-notes.png��$ Uniform=��� $��2��$
��Auto��$
��Auto��$	��5,0q�$��Stretch=�# �  $��Segoe WP Semibold)�$��16(�$��Normal$�#��� 	   main_toolTip_delete# �  ��Z� ���� *Delete+��Z� ���� $ Images/delete-notes.png��$ Uniform=��� $��3��$
��Auto��$
��Auto��$	��5,0q�$��Stretch=�# �  $��Segoe WP Semibold)�$��16(�$��Normal$� J� RenderTransformOrigin$ 0.5,1&�#��� 	   main_toolTip_refresh# �  ��Z� ���� *
Referesh+��Z� ���� $ Images/reload.png��$ Uniform=� �� 	Transform V� .~��� �� �� T�  T� Y$	 1.5Q� �� RelativeTransform V� .~���   �� CenterX$	  0.5Q�! �� CenterY$	! 0.5Q�" �� ScaleX$	" 0.9Q�# �� ScaleY$
# 0.95Q��� $ �� CenterX$	$ 0.5Q�% �� CenterY$	% 0.5Q��� & �� CenterX$	& 0.5Q�' �� CenterY$	' 0.5Q�T� 