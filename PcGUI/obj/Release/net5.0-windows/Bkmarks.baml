   M S B A M L   `   `   `  ���� @  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted  B >logicPC, Version=0.8.0.0, Culture=neutral, PublicKeyToken=nullN4clr-namespace:logicPC.Gestionnaires;assembly=logicPClogicPC.Gestionnaires     PcParted.UserControl2   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:PcParted     Ngestionnaires4clr-namespace:logicPC.Gestionnaires;assembly=logicPC     -   $	��200��  � 	Resources   �� 
TargetType �� Property �� Value��%�   '��       �� " ��.���  � ��
 �������  � ��$ 14(���  � ��$ Unispace)���  � ��$
 Wrap=���  � ��$	 Top=�.��� .+��� 
�������$
��Left=�$	��450��
���   �$	��Top=�$	��200�� �� RadiusY$ 10�� �� RadiusX$ 10���� $
��Left=�$��	16,10,0,0q�$
��Wrap=�$	��Top=� J� RenderTransformOrigin$ 1.185,6.167&�
��������� $�Liste���� �� ���#4AB8FF$
��Left=�$	��100��$��
16,325,0,0q�
���   �$	��Top=�$	��165��$ 10��$ 10���� ���#159FF8$
��Left=�$��44��$��
16,381,0,0q�
���   �$	��Top=�$	��165��$ 10��$ 10���� $
��Left=�$��
21,359,0,0q�$	��Top=����#DBDE86$��13(��� $�Conso: �� �� -    ��Name$
 watt��$� �� �� $�W���� $
��Left=�$��
21,336,0,0q�$	��Top=����#F6C78E$��13(��� $�HahsR:�� �� -   $
 hash��$�0�� �� $
�MH/S���� $
��Left=�$��
21,395,0,0q�$	��Top=����#8CFFCA$��13(��� $�Coût:�� �� -   $
 euro��$� �� �� $	�€��&   System.Windows.Controls.DataGrid  -     Name$ 
GrdBkmarks��$��Stretch=�$��Stretch=�$	��600��$��
1,40,1,160q�	   AutoGenerateColumns$	 False��
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Quantité��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Value+  $ Modèle�� �� *Key+����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q��� -    ��Name$ ListBox��$
��Left=�$��	64,10,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$	 Key�� �� DisplayMemberPath$	 Key��$ �� IsSynchronizedWithCurrentItem$ FalseY� �� SelectedIndex$ 0������ *UserListsStorage+ �� UpdateSourceTrigger$ PropertyChanged=�