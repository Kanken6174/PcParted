   M S B A M L   `   `   `  ����@  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted  5          PcParted.MainApp   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:PcParted     5      -   5        
������   � 	Resources  5         VSC_bar  Template_SCV1 �� 
TargetType �Name � ColumnDefinitions � RowDefinitions ��Name ��Name �� CanContentScroll �� CanHorizontallyScroll	 �� CanVerticallyScroll
 ��Name4  .System.Windows.Automation.AutomationProperties   AutomationId � Cursor �� ScrollableHeight � Maximum � Minimum* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ViewportSize � Value �� Mode �� RelativeSource �� ScrollableWidth �� Orientation, �� %ComputedHorizontalScrollBarVisibility �� ViewportWidth��%�  &	        &	      7   7   �� 5   
   6   �� 5   
   " ��5      .R�5      � $
 Grid��6   #��z��5       5      �� 5      $��* �6'   �� 5      $
��Auto �6'    5      �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� $ Corner��6   $��1��5      #��� ��5      $��1��5      �� 5       $! PART_ScrollContentPresenter��6)   # z��5!   )   $ False��5"   )   $	 False��5#   )   #��z��5$   )   #��z��5%   )   $��0��5&   )   #��z��5'   )   $��0��5(   )   �� 5*      $
 PART_VerticalScrollBar��5+      8��  $ VerticalScrollBar��5,      $ Arrow��5-      $��1��5.      # z 5/      $ 0Q�50      $��0��51      #y�z 52      # z 54       53      �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+54      �� 56      $
 PART_HorizontalScrollBar��57      8�� $ HorizontalScrollBar��58      $ Arrow��59      $��0��5:      # z 5;      $ 0Q�5<      $ 
Horizontal=�5=      $��1��5>      #y�z 5?      # z 5A       5@      �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+5A      5B      5C      5D      .��5F      � -   5        $ MainGrid��5F       5G   
   �� 5H      $	��200 �6   �� 5J      $	��350 �6   �� 5L      $	��260 �6   .+�5R   
   �� -   5         ��Name$ Scroller��5R      $��1��5S      $��0,40,0,0q�5T      $��Stretch=�5U      $��false��5V      .��5W      � -   5         �Name$ wrappy��5W      5X      5Y      9� 5\   
    J� RenderTransformOrigin$ 0.5,0.5&�6    9� 
IsExpanded$
 True��5]      $��0��5^      ��5_      �� 5`      
�������$��Filtres��5a      $��Stretch=�5b      .��5e         PcParted.UserControl4  -   5          Name$ Filters��5e   !   $ 0.5,0.5&�5f   !   $��0,0,0,2q�5g   !   $
��Auto��5h   !   $
��True��5i   !   5j      9� 5m   
   $ 0.5,0.5&�6   $��5,0,0,0q�5n      $��2��5o      $
 true��5p      ��5q      �� 5r      
�������$��	Bookmarks��5s      $	��100��5t      $��Stretch=�5u      .��5w      � $	��483��6   .+�5x         PcParted.UserControl2  $��
20,1,21,-1q�6%   5y      5z      �� 5{   
   -   5        $��1��5{      $
��Left=�5|      $��23��5}      $��	10,10,0,0q�5~       �� TextWrapping$
 Wrap=�5      $��Votre recherche ici��5�      $	��Top=�5�      $	��309��5�      5�      �� 5�   
   -   5        $��Q
��5�      $��1��5�      $
��Left=�5�      $��
320,10,0,0q�5�      $	��Top=�5�      $��25��5�      $��23��5�        �� 	IsDefault$
  True��5�         PcParted.UserControl5  5�   
   -   5        !  Name$! DetailedCard��5�         PcParted.UserControl5"   Loaded$" DetailedCard_Loaded��5�      $��1��5�      $��Center=�5�      $��0,40,0,0q�5�      $	��Top=�5�      $y�Hidden=�5�      5�      5�      5�      