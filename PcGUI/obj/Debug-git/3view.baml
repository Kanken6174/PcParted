   M S B A M L   `   `   `  ���� C  ?PcParted, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted      PcParted.MainApp   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:PcParted     
������   � 	Resources     VSC_bar  Template_SCV1 �� 
TargetType �Name � ColumnDefinitions � RowDefinitions ��Name ��Name �� CanContentScroll �� CanHorizontallyScroll	 �� CanVerticallyScroll
 ��Name4  .System.Windows.Automation.AutomationProperties   AutomationId � Cursor �� ScrollableHeight � Maximum � Minimum* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ViewportSize � Value �� Mode �� RelativeSource �� ScrollableWidth �� Orientation, �� %ComputedHorizontalScrollBarVisibility �� ViewportWidth��%�  &	        &	      7   7   �� �� " ��.R�� $
 Grid��#��z�� �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $ Corner��$��1��#��� ��$��1���� $! PART_ScrollContentPresenter��# z�� .  	 .  #��z��#��z��$��0��#��z��$��0���� $
 PART_VerticalScrollBar��8��  $ VerticalScrollBar��$ Arrow��$��1��# z $ 0Q�$��0��#y�z # z  �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+�� $
 PART_HorizontalScrollBar��8�� $ HorizontalScrollBar��$ Arrow��$��0��# z $ 0Q�$ 
Horizontal=�$��1��#y�z # z  �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+.��� -   $ MainGrid�� �� $	��200 ��� $	��350 ��� $	��200 �.+��� -    ��Name$ Scroller��$��1��$
��Auto=�#���  $��0,40,0,0q�.��� -    �Name$ wrappy��$��1��$	��351������  �� ElementName$ MyScrollViewer�� �� Path$ ViewportHeight�9�  J� RenderTransformOrigin$ 0.5,0.5&� 9� 
IsExpanded .  ���� 
�������$��Filtres��$��Stretch=����� $ 	expOneDay��$ ActualWidth�.��   PcParted.UserControl4  $ 0.5,0.5&�$	��520��$��0,0,-2,0q�$
��Auto��9� $ 0.5,0.5&�$��	5,0,-47,0q�$��2�� .  ���� 
�������$��	Bookmarks��$��Stretch=����� $ 	expOneDay��$ ActualWidth�.��� $	��483��.+�   PcParted.UserControl2  $��
20,1,21,-1q��� -   $��	card test��$��36��$��108,0,137,23q�$��Bottom=�$��1���� -   $��1��$
��Left=�$��23��$��	10,10,0,0q�  �� TextWrapping$
  Wrap=�$��Votre recherche ici��$	��Top=�$	��309���� $	��Q
��$��1��$
��Left=�$��
319,10,0,0q�$	��Top=�$��25��$��23��