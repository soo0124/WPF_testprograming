   M S B A M L   `   `   `  ����T  PSoftwareFusionProject_JSH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SoftwareFusionProject_JSH.ViewsSoftwareFusionProject_JSH.Views  5      /    )SoftwareFusionProject_JSH.Views.SetupView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:SoftwareFusionProject_JSH.Views     5        N� Title$  	SetupView��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� �� 5   
   $��0��6   $��0��6    $��Center=�6-   $��Right=�6H   $��0,0,0,0q�6d   $��Human Detection��6u   $
��Bold"�6�   $��20(�6�   �� 5   
   $��1��6Z   $��0��6j   $��Center=�6w   $��Center=�6�   $	��150��6�   ��6   �� *	portLists+ �� SelectedItem 65   �� *selectPortD+6�   A� 5   
   $��0��6   $��2��6   $��30��6/   $��30��6:   $��0,0,0,0q�6F   $��Center=�6W   $��Center=�6t   ��5      �� 5       �� 
TargetType" A�6   .�5       ��  �� Property � �� �� Value
 �  ��6-    �� Triggers 5!      �� 5"       �� Binding 6&   �� *detectConnect+	 �� Value	 True6H   .a�5#      ��  � ��
 �/���65   5$      5&      5(      �� 5*   
   $��0��6   $��1��6    $��Center=�6-   $��Right=�6H   $��0,0,0,0q�6d   $��RF, QR Reader��6u   $
��Bold"�6�   $��20(�6�   �� 5+   
   $��1��6Z   $��1��6j   $��Center=�6w   $��Center=�6�   $	��150��6�   ��6   �� *	portLists+ 65   �� *selectPortR+6�   A� 5,   
   $��30��6   $��30��6   $��0,0,0,0q�6)   $��Center=�6:   $��Center=�6W   $��1��6r   $��2��6   ��5-      �� 5.      " A�6   .�5/      ��  � ��
 �  ��6-    50      �� 51       6&   �� *readerConnect+	 True6H   .a�52      ��  � ��
 �/���65   53      55      57      �� 59   
   $��3��69   $��0��6I   $��Center=�6V   $
��Left=�6q   $	��130��6�   $��25��6�   $��Black"�6�   
�������
 �� Click
 6   <   6SoftwareFusionProject_JSH.Views.MethodBindingExtension  *	D_Connect+��5:      �� 5;      " ��6   .�5<      ��  � ��$ CONNECT��60   �� 5=       � ��
 �   �63    5>      �� 5?       6&   �� *detectConnect+	 True6H   .a�5@      ��  � ��$ 
DISCONNECT��68   �� 5A       � ��
 �  ��6;   5B      5D      5F      �� 5H   
   $��3��69   $��1��6I   $��Center=�6V   $
��Left=�6q   $	��130��6�   $��25��6�   $��CONNECT��6�   $��Black"�6�   
�������
 6     *	R_Connect+��5I      �� 5J      " ��6   .�5K      ��  � ��$ CONNECT��60   �� 5L       � ��
 �   �63    5M      �� 5N       6&   �� *readerConnect+	 True6H   .a�5O      ��  � ��$ 
DISCONNECT��68   �� 5P       � ��
 �  ��6;   5Q      5S      5U      5V      5W      