   M S B A M L   `   `   `  ����N  JRCS_Setting_Program, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RCS_Setting_Program.ViewsRCS_Setting_Program.Views  5      )    #RCS_Setting_Program.Views.Main_View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:RCS_Setting_Program.Views     5        N� Title$  	Main_View��5      .��5
      �  � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      .+�5   
   �� $��0��6   $��0��6   $��2��6-   $��
55,100,0,0q�6>   $	��110��6R   $��30��6^   $	��Top=�6j   $
��Left=�6�   $��	DTC COUNT��6�   
�������$
��Bold"�6�   $��15(�6�   �� 5   
   $��0��6   $��0��6    $��2��60   $��180,103,0,0q�6�   $	��120��6�   $��25��6�   $	��Top=�6�   $
��Left=�6   �� SelectionChanged 6A   6   0RCS_Setting_Program.Views.MethodBindingExtension  *Changed_DTC+��6v   �� *
dtcCount+ �� SelectedItem 6�   �� *selectAllDTC+6  �� 5   
   $��0��6   $��0��6   $��2��6-   $��
55,210,0,0q�6>   $	��110��6R   $��30��6^   $	��Top=�6j   $
��Left=�6�   $��	RCU COUNT��6�   
�������$
��Bold"�6�   $��15(�6�   �� 5   
   $��0��6   $��0��6   $��2��6/   $��180,213,0,0q�6]   $	��120��6r   $��25��6~   $	��Top=�6�   $
��Left=�6�   ��6@   �� *rcuAllCount+6�   �� 5   
   $��0��6   $��0��6   $��2��6-   $��
55,320,0,0q�6>   $	��110��6R   $��30��6^   $	��Top=�6j   $
��Left=�6�   $��	COM SPEED��6�   
�������$
��Bold"�6�   $��15(�6�   �� 5   
   $��0��6   $��0��6   $��2��6/   $��180,323,0,0q�6[   $	��120��6p   $��25��6|   $	��Top=�6�   $
��Left=�6�   ��6@   �� *	commSpeed+6�   �� 5   
   $��1��6   $��0��6    $��	10,30,0,0q�6-   $	��Top=�6@   $
��Left=�6X   $��DTC SETTING��6s   
�������$
��Bold"�6�   $��15(�6�   �� 5   
   $��1��6   $��0��6"   $��	10,65,5,5q�6/   ��6B   �� *	dtcList+��5       �� 5!      .R�5"      ��  �� Orientation$ Vertical=�6!   5#      ��5&      �� 5'      .R�5(      �� $ 
Horizontal=�6!   .+�5)      �� $	��Top=�6:   $
��Left=�6R   $��60��6m   $
��Bold"�6x   $��15(�6�   ��6$   �� *name+6�   �� 5*      $	��Top=�6<   $
��Left=�6T   $	��100��6o   $��25��6{   $��20,0,0,0q�6�   ��6"   �� *
rcuCount+6�   5+      5,      5.      50      52      