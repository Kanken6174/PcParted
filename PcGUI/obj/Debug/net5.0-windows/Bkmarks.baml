   M S B A M L   `   `   `  ����@  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted  5      B >logicPC, Version=0.8.0.0, Culture=neutral, PublicKeyToken=nullN4clr-namespace:logicPC.Gestionnaires;assembly=logicPClogicPC.Gestionnaires 5          PcParted.UserControl2   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:PcParted     5      Ngestionnaires4clr-namespace:logicPC.Gestionnaires;assembly=logicPC     5      -   5        $	��200��5        � 	Resources  5       �� 
TargetType �� Property �� Value��%  '��       �� 5   
   " ��6   .�5      ��  � ��
 �����5      �� 5       � ��$ 14(�5      �� 5       � ��$ Unispace)�5      �� 5       � ��$
 Wrap=�5      �� 5       � ��$	 Top=�5      5      5      .��5      � .+�5   
   �� 
�������$
��Left=�5      $	��450��5      
���   �$	��Top=�5       $	��200��5!       �� RadiusY$ 10��5"       �� RadiusX$ 10��5#      5$      �� 5%   
   $
��Left=�6   $��	16,10,0,0q�5&      $
��Wrap=�5'      $	��Top=�5(       J� RenderTransformOrigin$ 1.185,6.167&�5)      
��������� 5*   ,   $�Liste��60   �� 6@   6H   �� 5,   
   ���#4AB8FF$
��Left=�5-      $	��100��5.      $��
16,325,0,0q�5/      
���   �$	��Top=�51      $	��165��52      $ 10��53      $ 10��54      �� 55   
   ���#159FF8$
��Left=�56      $��44��57      $��
16,381,0,0q�58      
���   �$	��Top=�5:      $	��165��5;      $ 10��5<      $ 10��5=      �� 5>   
   $
��Left=�6   $��
21,359,0,0q�5?      $	��Top=�5@      ���#DBDE86$��13(�5B      �� 5C      $�Conso: ��6    �� 5D      -   5         ��Name$
 watt��5D   !   $� ��6   6!    �� 5E      $�W��6   5F      �� 5G   
   $
��Left=�6   $��
21,336,0,0q�5H      $	��Top=�5I      ���#F6C78E$��13(�5K      �� 5L      $�HahsR:��6    �� 5M      -   5        $
 hash��5M      $�0��6   6    �� 5N      $
�MH/S��6   5O      �� 5P   
   $
��Left=�6   $��
21,395,0,0q�5Q      $	��Top=�5R      ���#8CFFCA$��13(�5T      �� 5U      $�Coût:��6    �� 5V      -   5        $
 euro��5V      $� ��6   6    �� 5W      $	�€��6   5X      &   System.Windows.Controls.DataGrid  5Z   
   -   5          Name$ 
GrdBkmarks��5[      $��Stretch=�5\      $��Stretch=�5]      $	��600��5^      $��
1,40,1,160q�5_      	   AutoGenerateColumns$	 False��5`      
   Columns
 5a      0  *System.Windows.Controls.DataGridTextColumn  5b      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Quantité��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5c   %   �� *Value+  5d      $ Modèle��6%    5e   %   �� *Key+��5h      �� 5i       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�5j   &   .��5k      �  � Color$ Black��6#    � Offset$ 0Q�5l   #   5m      5p      �� 5q   
   -   5         ��Name$ ListBox��5q      $
��Left=�5r      $��	64,10,0,0q�5s      $	��Top=�5t      $	��120��5u       �� SelectedValuePath$	 Key��5w       �� DisplayMemberPath$	 Key��6+   $ �� IsSynchronizedWithCurrentItem$ FalseY�5x       �� SelectedIndex$ 0��5z      ��5y      �� *UserListsStorage+ �� UpdateSourceTrigger$ PropertyChanged=�5z      5{      5|      