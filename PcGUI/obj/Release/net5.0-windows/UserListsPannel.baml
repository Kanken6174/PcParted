   M S B A M L   `   `   `  ���� @  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted  B >logicPC, Version=0.8.0.0, Culture=neutral, PublicKeyToken=nullN4clr-namespace:logicPC.Gestionnaires;assembly=logicPClogicPC.Gestionnaires R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics     PcParted.UserListsPannel   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:PcParted     Ngestionnaires4clr-namespace:logicPC.Gestionnaires;assembly=logicPC     Fdiag5clr-namespace:System.Diagnostics;assembly=WindowsBase     -   
�������.��� .+�&   System.Windows.Controls.DataGrid  -      Name$  DGrid��$
��Left=�$	��350��$��	60,80,0,0q�$	��Top=�$	��495��   AutoGenerateColumns$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Quantité��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Value+  $ Modèle�� �� *Key+�� -    ��Name$ ListesComboBox��$
��Left=�$��
625,80,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$	 Key�� �� DisplayMemberPath$	 Key��$��33�� �� SelectedIndex$ 0������ *UserListsStorage+	 �� UpdateSourceTrigger$	 PropertyChanged=��� -   $��	Supprimer��$
��Left=�$��625,140,0,0q�$	��Top=��� -   $��	Dupliquer��$
��Left=�$��706,140,0,0q�$	��Top=��� -   $��+��$
��Left=�$��
745,80,0,0q�$	��Top=�$��25(�$��consolas)��� -   
 ��Name$
 NameBox��$
��Left=�$��625,205,0,0q�$	��Nom�� �� TextWrapping$
 Wrap=�$	��Top=�$��80���� -   $��Renommer��$
��Left=�$��705,203,0,0q�$	��Top=�$��70�� �� 	IsDefault$
 True��