   M S B A M L   `   `   `  ����@  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted  5      B >logicPC, Version=0.8.0.0, Culture=neutral, PublicKeyToken=nullN4clr-namespace:logicPC.Gestionnaires;assembly=logicPClogicPC.Gestionnaires 5      R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics 5          PcParted.UserListsPannel   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:PcParted     5      Ngestionnaires4clr-namespace:logicPC.Gestionnaires;assembly=logicPC     5      Fdiag5clr-namespace:System.Diagnostics;assembly=WindowsBase     5      -   5        
�������.��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  DGrid��5      $
��Left=�5      $	��350��5      $��	60,80,0,0q�5      $	��Top=�5      $	��495��5         AutoGenerateColumns$ False��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Quantité��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   �� *Value+  5      $ Modèle��6%    5   %   �� *Key+5      �� 5   
   -   5         ��Name$ ListesComboBox��5      $
��Left=�5      $��
625,80,0,0q�5       $	��Top=�5!      $	��120��5"       �� SelectedValuePath$	 Key��5#       �� DisplayMemberPath$	 Key��5$      $��33��5%       �� SelectedIndex$ 0��5'      ��5&      �� *UserListsStorage+	 �� UpdateSourceTrigger$	 PropertyChanged=�5)      �� 5*   
   -   5        $��	Supprimer��5*      $
��Left=�5+      $��625,140,0,0q�5,      $	��Top=�5-      5.      �� 5/   
   -   5        $��	Dupliquer��5/      $
��Left=�50      $��706,140,0,0q�51      $	��Top=�52      53      �� 54   
   -   5        $��+��54      $
��Left=�55      $��
745,80,0,0q�56      $	��Top=�57      $��25(�58      $��consolas)�59      5:      �� 5;   
   -   5        
 ��Name$
 NameBox��5;      $
��Left=�5<      $��625,205,0,0q�5=      $	��Nom��5>       �� TextWrapping$
 Wrap=�5?      $	��Top=�5@      $��80��5A      �� 5B   
   -   5        $��Renommer��5B      $
��Left=�5C      $��705,203,0,0q�5D      $	��Top=�5E      $��70��5F       �� 	IsDefault$
 True��5G      5I      5L      5M      