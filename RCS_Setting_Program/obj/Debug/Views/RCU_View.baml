   M S B A M L   `   `   `  ����N  JRCS_Setting_Program, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RCS_Setting_Program.ViewsRCS_Setting_Program.Views  5      O,clr-namespace:RCS_Setting_Program.ViewModelsRCS_Setting_Program.ViewModels  6=   (    "RCS_Setting_Program.Views.RCU_View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:RCS_Setting_Program.Views     5      C
viewmodels,clr-namespace:RCS_Setting_Program.ViewModels     6=     N� Title$  RCU_View��5	      .��5      �  � RowDefinitions 5   
   �� 5      .+�5   
   �� $	��Top=�6   $
��Left=�6(   $��0,10,0,0q�6C   $��90��6U   $��35��6`   $��객실타입 :��6l   $
��Bold"�6}   $��15(�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 �����63    �� Triggers 5      �� 5       �� Binding 6&   �� *selectCbMode+ �� Value 06G   .a�5      ��  � ��
 �  ��6;   5      5      5      �� 5   
   $	��Top=�6   $
��Left=�6+   $��	85,12,0,0q�6F   $	��120��6Y   $��25��6e   $
��Bold"�6q    �� SelectedIndex$ 0��6�   
���������6�   �� *cbMode+	 �� SelectedItem	 6�   �� *selectCbMode+6�   �� 5   
   $	��Top=�6   $
��Left=�6(   $��
270,10,0,0q�6C   $��90��6W   $��35��6b   $��	A접점 :��6n   $
��Bold"�6~   $��15(�6�   
�������6�   �� 5   
   $	��Top=�6   $
��Left=�6+   $��
340,12,0,0q�6F   $	��120��6Z   $��25��6f   $
��Bold"�6r   
���������6�   �� *
relayAList+	 6�   �� *relayASelect+6�   �� 5!   
   $	��Top=�6   $
��Left=�6(   $��
510,10,0,0q�6C   $��90��6W   $��35��6b   $��	B접점 :��6n   $
��Bold"�6~   $��15(�6�   
�������6�   �� 5"   
   $	��Top=�6   $
��Left=�6+   $��
580,12,0,0q�6F   $	��120��6Z   $��25��6f   $
��Bold"�6r   
���������6�   �� *
relayBList+	 6�   �� *relayBSelect+6�   �� 5%   
   $��0��6   $��0��6   $��0,50,0,0q�6/   
���   ���6A   �� *
rcuLists+��5&      �� 5'      .R�5(      �� 
 �� Orientation$
 
Horizontal=�6!   5)      ��5,      �� 5-      .R�5.      �� $
 Vertical=�6!   $	��185��68   .+�50      �� $��Center=�6[   $
��Bold"�6v   
��� �����6$   �� *
lightIndex+ �� StringFormat$ {0}번 전등스위치��6�   �� 51      $��5,8,0,0q�6#   ��64   �� *
lightNum+	 6U   �� *	selectNum+�� 52      $��5,8,0,0q�6#   $��마스터 유무��64   
������� d� 	IsChecked 6E   �� *	masterUse+6e   �� 53      $��5,8,0,0q�6#   $��화장실 전용��64   
������� 6E   �� *	bathUse+6c   �� 55      $��0,10,0,0q�6E   ��6"   �� *
relayLists+��56      �� 57   "   .R�58   &   �� $
 
Horizontal=�61   .+�59   *   �� $	��100��63    �� ContentStringFormat$ {0}번 릴레이��6[   ��6?   �� *	relayNo+ 6|   �� *	IsChecked+�� 5:   *   $��80��63    �� DisplayMemberPath$ Display��6�    �� SelectedValuePath$ Value��6�   ��6>   �� *	circuitNo+	 6`   �� *selectCircuitNo+��5;   .   �� 5<   2   " ��68    5=   6   �� 5>   :    6F   �� *	IsChecked+	 False6d   .a�5?   >   ��  � {� .  6Z   5@   ;   5B   3   5D   +   5E   '   5F   #   5H      5I      5J      5L      5N      5P      