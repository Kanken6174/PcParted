   M S B A M L   `   `   `  ����@  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted  5          PcParted.Graph   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:PcParted     5      -   5        $	��536��5      $	��792��5	      .��5      � 
�������.+�5   
   �� 
���   �$��3q�5      $
}�True��5      $��10,10,294,86q�5      ._�5      �� -   5          ��Name$  graphScreen��5      
�������5      5      �� 5   
   $
��Left=�6   $	��385��5      $��
511,10,0,0q�5      
���   �$��2��5      $	��Top=�5      $	��271��5      �� 5   
   -   5         ��Name$ SelectionBox��5      $
��Left=�5      $��
585,23,0,0q�5      $	��Top=�5      $	��120��5        �� SelectedValuePath$	 Key��5!       �� DisplayMemberPath$	 Key��5"      ��5#      �� *UserListsStorage+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedIndex 5%      �� *
ActiveList+$ PropertyChanged=� �� BindsDirectlyToSource$
 True���� 5&   
   -   5         ��Name$ incrementBox��5&      $
��Left=�5'      $��527,350,0,0q�5(      $��1��5)       �� TextWrapping$
 Wrap=�5*      $	��Top=�5+      $��65��5,      �� 5-   
   -   5        $ EndBox��5-      $
��Left=�5.      $��699,350,0,0q�5/      $��50��50      $
 Wrap=�51      $	��Top=�52      $��65��53      �� 54   
   -   5        $
��Plot��54      $
��Left=�55      $��615,350,0,0q�56      $	��Top=�57      $��55��59      &   System.Windows.Controls.DataGrid  5:   
   -   5        	  Name$	 DGrid��5:      $
��Left=�5;      $	��280��5<      $��
527,55,0,0q�5=      $	��Top=�5>      $	��237��5?      
   AutoGenerateColumns$
 False��5@         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Quantité��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5C   %   �� *Value+  5D      $ Modèle��6%    5E   %   �� *Key+5G      �� 5H   
   -   5        $��
Export PNG��5H      $
��Left=�5I      $��25��5J      $��511,425,0,0q�5K      $	��Top=�5L      $��99��5M      5N      �� 5O   
   $
��Left=�6   $	��100��5P      $��1085,365,0,0q�5Q      $	��Top=�5R      $��5��5S      �� 5T   
   $
��Left=�6   $��527,375,0,0q�5U      $
��Wrap=�5V      $	��Top=�5W      �� 6-    � Language$ fr-fr�61   $�Zoom(avancé)��5X   1   6I   �� 5Y   
   $
��Left=�6   $��738,375,0,0q�5Z      $
��Wrap=�5[      $	��Top=�5\       J� RenderTransformOrigin$ 1.395,0.627&�5]      �� 69   $ fr-fr�6=   $
�Mois��5^   =   6M   5`      5a      