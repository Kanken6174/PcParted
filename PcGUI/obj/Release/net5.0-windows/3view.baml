   M S B A M L   `   `   `  ���� @  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted      PcParted.MainApp   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:PcParted     -   
������   � 	Resources     VSC_bar  Template_SCV1 �� 
TargetType �Name � ColumnDefinitions � RowDefinitions ��Name ��Name �� CanContentScroll �� CanHorizontallyScroll	 �� CanVerticallyScroll
 ��Name4  .System.Windows.Automation.AutomationProperties   AutomationId � Cursor �� ScrollableHeight � Maximum � Minimum* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ViewportSize � Value �� Mode �� RelativeSource �� ScrollableWidth �� Orientation, �� %ComputedHorizontalScrollBarVisibility �� ViewportWidth��%�  &	        &	      7   7   �� �� " ��.R�� $
 Grid��#��z�� �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $ Corner��$��1��#��� ��$��1���� $! PART_ScrollContentPresenter��# z��$ False��$	 False��#��z��#��z��$��0��#��z��$��0���� $
 PART_VerticalScrollBar��8��  $ VerticalScrollBar��$ Arrow��$��1��# z $ 0Q�$��0��#y�z # z  �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+�� $
 PART_HorizontalScrollBar��8�� $ HorizontalScrollBar��$ Arrow��$��0��# z $ 0Q�$ 
Horizontal=�$��1��#y�z # z  �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+.��� -   $ MainGrid�� �� $	��200 ��� $	��350 ��� $	��260 �.+��� -    ��Name$ Scroller��$��1��$��0,40,0,0q�$��Stretch=�$��false��.��� -    �Name$ wrappy��9�  J� RenderTransformOrigin$ 0.5,0.5&� 9� 
IsExpanded$
 True��$��0������ 
�������$��Filtres��$��Stretch=�.��   PcParted.UserControl4  -     Name$ Filters��$ 0.5,0.5&�$��0,0,0,2q�$
��Auto��$
��True��9� $ 0.5,0.5&�$��5,0,0,0q�$��2��$
 true������ 
�������$��	Bookmarks��$	��100��$��Stretch=�.��� $	��483��.+�   PcParted.UserControl2  $��
20,1,21,-1q��� -   $��1��$
��Left=�$��23��$��	10,10,0,0q� �� TextWrapping$
 Wrap=�$��Votre recherche ici��$	��Top=�$	��309���� -   $��Q
��$��1��$
��Left=�$��
320,10,0,0q�$	��Top=�$��25��$��23��  �� 	IsDefault$
  True��   PcParted.UserControl5  -   !  Name$! DetailedCard��   PcParted.UserControl5"   Loaded$" DetailedCard_Loaded��$��1��$��Center=�$��0,40,0,0q�$	��Top=�$y�Hidden=�