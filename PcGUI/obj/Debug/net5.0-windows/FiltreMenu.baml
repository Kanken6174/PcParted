   M S B A M L   `   `   `  ����@  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted  5          PcParted.UserControl4   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:PcParted     5      $	��188��5	        � 	Resources  5
       �� 
TargetType �� Property �� Value��%  '��       �� 5   
   " ��6   .�5      ��  � ��
 �   �5      �� 5       � ��$ 10(�5      �� 5       � ��$ Unispace)�5      �� 5       � ��$
 Wrap=�5      �� 5       � ��$	 Top=�5      5      5      .��5      � .+�5   
   �� 
�������$
��Left=�5      $	��450��5      
���   �$	��Top=�5      $	��188��5       �� RadiusY$ 10��5        �� RadiusX$ 10��5!      �� 5#   
   -   5         ��Name$ Constructeur��5#      $
��Left=�5$      $��
10,207,0,0q�5%      $	��Top=�5&      $	��120��5'       � ToolTip$ Constructeur��5(      ��5)      �� *ManufacturersList+ �� UpdateSourceTrigger$ Default=�	 �� Mode$	 OneWay=�5*      �� 5+   
   -   5        $ Architectures��5+      $
��Left=�5,      $��
10,234,0,0q�5-      $	��Top=�5.      $	��120��5/      $ Série��50      ��51      �� *ArchitecturedList+$ Default=�$	 OneWay=�52      �� 53   
   -   5        
 ��Name$

 prix��53      $
��Left=�54      $��	19,70,0,0q�55      $	��Top=�56      $	��130��57       � Maximum 59      �� *
MaxPrice+$ PropertyChanged=�$	 OneWay=� �� StringFormat$ #0.00���� 5:   
   -   5        $
 Consommation��5:      $
��Left=�5;      $��
19,109,0,0q�5<      $	��Top=�5=      $	��130��5>       J� RenderTransformOrigin$ 0.408,4.278&�5?       5@      �� *MaxPowerDraw+$ PropertyChanged=�$	 OneWay=�$ #0��5A      �� 5B   
   -   5        $
 Hashrate��5B      $
��Left=�5C      $��
19,157,0,0q�5D      $	��Top=�5E      $	��130��5F      $ 0.408,4.278&�5G       5H      �� *MaxHashrate+$ PropertyChanged=�$	 OneWay=�$ #0��5I      �� 5J   
   $��Center=�6   $��0,90,0,0q�5K      $
��Wrap=�5L      $	��Top=�5M      $	��188��5N       �� TextAlignment$ Center=�5O      �� 5P      -   5         ��Name$ PriceMaxBox��5Q      $�0.00€��5P      5Q       �� 5R      $�Prix max��6    �� 5S      �6   �� *
MaxPrice+$ PropertyChanged=�$	 OneWay=�$ #0.00€��5T      �� 5U   
   $��Center=�6   $��	0,132,0,0q�5V      $
��Wrap=�5W      $	��Top=�5X      $	��188��5Y      $ Center=�5Z      �� 5[      -   5        $ ConsoBox��5\      $�0W��5[      5\       �� 5]      $�Consom. max��6    �� 5^      �6   �� *MaxPowerDraw+$ PropertyChanged=�$	 OneWay=�$	 #0W��5_      �� 5`   
   $��Center=�6   $��	0,180,0,0q�5a      $
��Wrap=�5b      $	��Top=�5c      $	��188��5d      $ Center=�5e      �� 5f      -   5        $ hashMin��5g      $�0MH/S��5f      5g       �� 5h      $�Hashrate min.��6    �� 5i      �6   �� *MaxHashrate+$ PropertyChanged=�$	 OneWay=�$ #0MH/S��5j      �� 5k   
   -	   5        $��	Appliquer��5k      $
��Left=�5l      $��
44,384,0,0q�5m      $	��Top=�5n      $��75��5o      5p      �� 5q   
   -
   5        $
 	prix_Copy��5q      $
��Left=�5r      $��	19,34,0,0q�5s      $	��Top=�5t      $	��130��5u       5v      �� *
MaxPrice+$ PropertyChanged=�$	 OneWay=�$ #0.00��5w      �� 5x   
   $��Center=�6   $��0,53,0,0q�5y      $
��Wrap=�5z      $	��Top=�5{      $ Center=�5|      $	��188��5}      �� 5~      -   5        $ PriceMinBox��5      $�0.00€��5~      5       �� 5�      $�Prix min��6    �� 5�      �6   �� *
MaxPrice+$ PropertyChanged=�$	 OneWay=�$ #0.00��5�      �� 5�   
   -   5         ��Name$ showCorrupted��5�      $"��Montrer entrées non-fiables��5�      $
��Left=�5�      $��	7,288,0,0q�5�      $	��Top=�5�      $��19��5�      5�      �� 5�   
   $��Center=�6   $��26��5�      $��	0,307,0,0q�5�      $
��Wrap=�5�      $	��148��5�      �� 6!    � Language$ fr-fr�6%   $&� ! Désactive aussi les sliders !��5�   %   6P   �� 5�   
   $��1q�6   
���   �$
��Left=�5�      $��48��5�      $��-10,285,0,0q�5�      $	��Top=�5�      $	��198��5�      5�      5�      