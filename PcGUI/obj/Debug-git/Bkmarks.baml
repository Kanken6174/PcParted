   M S B A M L   `   `   `  ���� C  ?PcParted, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted      PcParted.UserControl2   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:PcParted     $	��200��  � 	Resources   �� 
TargetType �� Property �� Value��%�   '��       �� " ��.���  � ��
 �������  � ��$ 14(���  � ��$ Unispace)���  � ��$
 Wrap=���  � ��$	 Top=�.��� .+��� 
�������$
��Left=�$	��450��
���   �$	��Top=�$	��200�� �� RadiusY$ 10�� �� RadiusX$ 10���� $
��Left=�$��	16,10,0,0q�$
��Wrap=�$	��Top=� J� RenderTransformOrigin$ 1.185,6.167&�
��������� $�Liste���� �� �� ���#4AB8FF$
��Left=�$	��100��$��
16,325,0,0q�
���   �$	��Top=�$	��165��$ 10��$ 10���� ���#159FF8$
��Left=�$��44��$��
16,381,0,0q�
���   �$	��Top=�$	��165��$ 10��$ 10���� $
��Left=�$��
21,359,0,0q�$��Wattage : XXX W��$	��Top=����#DBDE86�� $
��Left=�$��
21,336,0,0q�$��Hashrate: XXX MH/S��$	��Top=����#F6C78E�� $
��Left=�$��
21,395,0,0q�$��Coût total: XXXX €��$	��Top=����#8CFFCA&   System.Windows.Controls.DataGrid  -     Name$ 
GrdBkmarks��   AutoGenerateColumns .  $��Stretch=�$��Stretch=�$	��600��$��
1,40,1,160q���Z� ���� 	 �� EndPoint$	 0.5,1&�
 �� 
StartPoint$
 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   	Clmod��,  &System.Windows.Controls.DataGridColumn   Header$ Modèle��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50    
Visibility$ Visible=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
modelCol+  -   
Clhash��$ hasrate��$ 50  �� *	hashCol+  -   
Clprix��$
 prix��$ 40  �� *	prixCol+  -   
Clwatt��$ Wattage��$ 60  �� *	SubStatus+�� -   $
��Left=�$��	64,10,0,0q�$	��Top=�$	��120��