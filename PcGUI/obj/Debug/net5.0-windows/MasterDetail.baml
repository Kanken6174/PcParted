   M S B A M L   `   `   `  ����@  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted  5          PcParted.UserControl5   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:PcParted     5      $	��Top=�5
        � DataContext  5      ��  �� RelativeSource �� *Self+.��5      � .+�5   
   �� 
�������$
��Left=�5      $	��450��5       �� RadiusY$ 10��5       �� RadiusX$ 10��5      
���   �$	��Top=�5      $	��350��5      �� 5   
   ���#99aab5$
��Left=�5      $	��290��5      $��	0,160,0,0q�5      $ 10��5      $ 10��5      
���   �$	��Top=�5      $	��350��5       J� RenderTransformOrigin$ 0.5,0.5&�5      z�5      V� 5       .~�5!      �� �� 5"      �� 5#       �� Angle$	 180Q�6&   T� 5$      5%       J� Clip 5'      �� 5(       �� Rect$ 0,-5,350,190�6$   5*      �� 5+   
   
���iii�$
��Left=�5,      $��44��5-      $	��Top=�5.      $	��348��5/      $��	1,221,0,0q�50      �� 51   
   -   5         ��Name$ masterDetailPic��51      $
��Left=�52      $	��204��53      $��	45,10,0,0q�54      $	��Top=�55      $	��266��56      $��gpu1.png��57      	 �� BitmapScalingMode$	 HighQuality=�58      
 J� Opacity$
 1Q�59       K� ZIndex$ 4��5:      �� 5;   
   -   5         ��Name$ 	nom_carte��5;      $��Center=�5<      $��0,227,0,187q�5=      $��Galax 1050 TI��5>       �� TextAlignment$ Center=�5?      $	��349��5@      
���   �$ 0.5,0.5&�5B      $��Unispace)�5C      $��25(�5D      $
��Wrap=�5E      z�5F      V� 5G      .~�5H      �� �� 5I       �� AngleX$ -0.104Q�6$   �� 5J      T� 5K       T� X$ -0.332Q�6)   5L      5N      �� 5O   
   -   5        $��Ajouter à la liste��5O      $
��Left=�5P      $��
48,417,0,0q�5Q      $	��Top=�5R      $	��128��5S      5T      �� 5U   
   -   5         ��Name$ closeDetailButton��5U      $��X��5V      $
��Left=�5W      $��
315,10,0,0q�5X      $	��Top=�5Y      $��25��5Z      $��25��5[      $y�Visible=�5]         PcParted.spinner  5^   
   -   5          Name$ spinny��5^      $��Center=�5_      $��0,33,0,0q�5`      $	��Top=�5a      $	��150��5b      $	��150��5c      $y�Hidden=�5d      �� 5e   
   $��
1,265,0,50q�6   .��5f      � -   5         �Name$ 
DetailWrap��5f      .+�5g      �� $��NoWrap=�6   $��Unispace)�5h      �� 5i   *   �� 5j      $�Informations��6   $��15(�5k      $��Italic$�5l      6/    4  .System.Windows.Controls.Ribbon.RibbonSeparator  5m      �� 5n      �� 5o      $�Constructeur: ��6    �� 5p      �6   �� *!carte.Informations.Manufacturer+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWay=��� 5q      �� 5r      $�Architecture: ��6    �� 5s      �6   �� *!carte.Informations.Architecture+$ PropertyChanged=�$ OneWay=��� 5t      �� 5u      $�Date de sortie: ��6    �� 5v      �6   �� * carte.Informations.ReleaseDate+$ PropertyChanged=�$ OneWay=��� 5w      �� 5x      $�Spécifications��6   $��15(�5y      $��Italic$�5z      6/      5{      �� 5|      �� 5}      $�	Bitrate: ��6    �� 5~      �6   �� *carte.Specifications.BitRate+$ PropertyChanged=�$ OneWay=��� 5   *   �� 5�      $�Fréquence GPU: ��6    �� 5�      �6   �� *#!carte.Specifications.GpuFrequency+$ PropertyChanged=�$ OneWay=��� 5�   *   �� 5�      $�
Mémoire: ��6    �� 5�      �6   �� *!carte.Specifications.MemorySize+$ PropertyChanged=�$ OneWay=� �� 5�      $
� MB ��6    �� 5�      �6   �� *&$carte.Specifications.MemoryFrequency+$ PropertyChanged=�$ OneWay=� �� 5�      $
� MHZ��6   �� 5�   *   �� 5�      $�RoPs/shaders/Tmus: ��6    �� 5�      �6   �� *carte.Specifications.RopUnits+$ PropertyChanged=�$ OneWay=� �� 5�      $�/��6    �� 5�      �6   �� *" carte.Specifications.ShaderUnits+$ PropertyChanged=�$ OneWay=� �� 5�      $�/��6    �� 5�      �6   �� *carte.Specifications.TmuUnits+$ PropertyChanged=�$ OneWay=��� 5�      �� 5�      $�Théoriques��6   $��15(�5�      $��Italic$�5�      6/      5�      �� 5�      �� 5�      $�FP32GFLOPS: ��6    �� 5�      �6   �� *carte.Theorics.FP32GFLOPS+$ PropertyChanged=�$ OneWay=��� 5�   *   �� 5�      $�Consommation: ��6    �� 5�      �6   �� *" carte.Theorics.EnergyConsumption+$ PropertyChanged=�$ OneWay=��� 5�   *   �� 5�      $�Prix: ��6    �� 5�      �6   �� *carte.Theorics.Price+$ PropertyChanged=�$ OneWay=��� 5�   *   �� 5�      $�Charge thermique: ��6    �� 5�      �6   �� *carte.Theorics.TempLoad+$ PropertyChanged=�$ OneWay=� �� 5�      $	�°C��6   5�      5�      5�      �� 5�   
   -   5        $ 	RemButton��5�      $��Retirer de la liste��5�      $
��Left=�5�      $��186,417,0,0q�5�      $	��Top=�5�      ${�False��5�      5�      5�      5�      