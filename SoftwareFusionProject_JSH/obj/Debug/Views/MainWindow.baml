   M S B A M L   `   `   `  ����T  PSoftwareFusionProject_JSH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SoftwareFusionProject_JSH.ViewsSoftwareFusionProject_JSH.Views  5   	   [2clr-namespace:SoftwareFusionProject_JSH.ViewModels$SoftwareFusionProject_JSH.ViewModels  5   	   0    *SoftwareFusionProject_JSH.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:SoftwareFusionProject_JSH.Views     5   	   Avm2clr-namespace:SoftwareFusionProject_JSH.ViewModels     5   	     � Title$  
MainWindow��5	   	   $	��700��6   $
��1400��6)   $	��600��66   $
��1200��6F    � DataContext 5      9   3SoftwareFusionProject_JSH.ViewModels.Main_ViewModel  5   
   .��5      � 
���   � � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��9* �6   .+�5   
   �� $��0��6   $��0��6   $��2��6-   $
��Left=�6A   $��	200,0,0,0q�6\   $��Center=�6o   $ ��Lecture Management Project��6�   $��45(�6�   $
��Bold"�6�   
�������6�   �� 5   
   $��0��6   $��0��6   $��2��6-   $��Right=�6A   $��0,0,20,0q�6]   $��Bottom=�6o   $��12194085 JangSooHyun��6�   $��20(�6�   
�������6�   A� 5   
   $��50��6   $��50��6   $��	0,0,50,30q�6)   $��Right=�6<   $��Center=�6X   $��0��6s   $��1��6�   ��5      �� 5       �� 
TargetType" A�6   .�5      ��  �� Property � �� �� Value
 �  ��6-    �� Triggers 5       �� 5!       �� Binding 6&   �� *
allConnect+	 �� Value	 True6E   .a�5"      ��  � ��
 �/���65   5#      5%      5'      �� 5*   
   -   5        
 ��Name$
 setting��5*      $��1��6O   $��0��6\   $��0,50,0,0q�6l   $��Center=�6~   $	��Top=�6�   $	��180��6�   $��50��6�   $��Setting��6�   $��20(�6�   
�������$
��Bold"�6�    �� Click 6"   <   6SoftwareFusionProject_JSH.Views.MethodBindingExtension  *Btn_ChangePage+6�   �� 5+   
   -   5        $
 lecture��5+      $��1��6O   $��0��6\   $��	0,200,0,0q�6l   $��Center=�6   $	��Top=�6�   $	��180��6�   $��50��6�   $��Lecture��6�   $��20(�6�   
�������$
��Bold"�6�    6"     *Btn_ChangePage+6�    � 5-   
   $��1��6/   $��1��6<     � NavigationUIVisibility$ Hidden=�6L     � Source 6   �� *frameSource+��5.      �� 5/       �� 
TargetType"  �6"   .R�50      �� # z 6'   51      53      59      5:      