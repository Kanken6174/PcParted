   M S B A M L   `   `   `  ���� @  <PcGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PcPartedPcParted      PcParted.UserControl4   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:PcParted     $	��188��  � 	Resources   �� 
TargetType �� Property �� Value��%�   '��       �� " ��.���  � ��
 �   ���  � ��$ 10(���  � ��$ Unispace)���  � ��$
 Wrap=���  � ��$	 Top=�.��� .+��� 
�������$
��Left=�$	��450��
���   �$	��Top=�$	��188�� �� RadiusY$ 10�� �� RadiusX$ 10���� -    ��Name$ Constructeur��$
��Left=�$��
10,207,0,0q�$	��Top=�$	��120�� � ToolTip$ Constructeur������ *ManufacturersList+ �� UpdateSourceTrigger$ Default=�	 �� Mode$	 OneWay=��� -   $ Architectures��$
��Left=�$��
10,234,0,0q�$	��Top=�$	��120��$ Série������ *ArchitecturedList+$ Default=�$	 OneWay=��� -   
 ��Name$

 prix��$
��Left=�$��	19,70,0,0q�$	��Top=�$	��130�� � Maximum �� *
MaxPrice+$ PropertyChanged=�$	 OneWay=� �� StringFormat$ #0.00���� -   $
 Consommation��$
��Left=�$��
19,109,0,0q�$	��Top=�$	��130�� J� RenderTransformOrigin$ 0.408,4.278&� �� *MaxPowerDraw+$ PropertyChanged=�$	 OneWay=�$ #0���� -   $
 Hashrate��$
��Left=�$��
19,157,0,0q�$	��Top=�$	��130��$ 0.408,4.278&� �� *MaxHashrate+$ PropertyChanged=�$	 OneWay=�$ #0���� $��Center=�$��0,90,0,0q�$
��Wrap=�$	��Top=�$	��188�� �� TextAlignment$ Center=��� -    ��Name$ PriceMaxBox��$�0.00€�� �� $�Prix max�� �� ��� *
MaxPrice+$ PropertyChanged=�$	 OneWay=�$ #0.00€���� $��Center=�$��	0,132,0,0q�$
��Wrap=�$	��Top=�$	��188��$ Center=��� -   $ ConsoBox��$�0W�� �� $�Consom. max�� �� ��� *MaxPowerDraw+$ PropertyChanged=�$	 OneWay=�$	 #0W���� $��Center=�$��	0,180,0,0q�$
��Wrap=�$	��Top=�$	��188��$ Center=��� -   $ hashMin��$�0MH/S�� �� $�Hashrate min.�� �� ��� *MaxHashrate+$ PropertyChanged=�$	 OneWay=�$ #0MH/S���� -	   $��	Appliquer��$
��Left=�$��
44,384,0,0q�$	��Top=�$��75���� -
   $
 	prix_Copy��$
��Left=�$��	19,34,0,0q�$	��Top=�$	��130�� �� *
MaxPrice+$ PropertyChanged=�$	 OneWay=�$ #0.00���� $��Center=�$��0,53,0,0q�$
��Wrap=�$	��Top=�$ Center=�$	��188���� -   $ PriceMinBox��$�0.00€�� �� $�Prix min�� �� ��� *
MaxPrice+$ PropertyChanged=�$	 OneWay=�$ #0.00���� -    ��Name$ showCorrupted��$"��Montrer entrées non-fiables��$
��Left=�$��	7,288,0,0q�$	��Top=�$��19���� $��Center=�$��26��$��	0,307,0,0q�$
��Wrap=�$	��148����  � Language$ fr-fr�$&� ! Désactive aussi les sliders !���� $��1q�
���   �$
��Left=�$��48��$��-10,285,0,0q�$	��Top=�$	��198��