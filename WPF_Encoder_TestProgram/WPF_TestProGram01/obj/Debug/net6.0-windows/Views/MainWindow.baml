   M S B A M L   `   `   `  ����L  HWPF_TestProgram01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPF_TestProgram01WPF_TestProgram01  5   	   K*clr-namespace:WPF_TestProgram01.ViewModelsWPF_TestProgram01.ViewModels  5   	   "    WPF_TestProgram01.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPF_TestProgram01     5   	   9vm*clr-namespace:WPF_TestProgram01.ViewModels     5   	     � Title$  
MainWindow��5	   	   $	��700��5
   	   $
��1200��6    � DataContext 5      0   *WPF_TestProgram01.ViewModels.MainViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5       � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      .+�5   
   �� 
��� � �$��1��6$   $��0��61   �� 5   
   
��� ���$��0��6%   $��0��62   $��2��6B   �� 5   
   -   5         ��Name$ comPort��5      $	��120��6�   $��30��6�   $	��Top=�6�   $
��Left=�6�   $��1��6�   $��	30,50,0,0q�6�   ��6%   �� *mainModel._comPort+ �� SelectedValue 6P   �� *mainModel.Pick_comPort+6�   �� 5   
   -   5        $ baudRate��5       �� SelectedIndex$ 3��6�   $	��120��6�   $��30��6�   $	��Top=�6�   $
��Left=�6�   $��1��6�   $��
210,50,0,0q�6�   ��6%   �� *mainModel._baudRate+ 6Q   �� *mainModel.Pick_baudRate+6�   �� 5    
   -   5        $ dataBit��5       $ 1��6�   $	��120��6�   $��30��6�   $	��Top=�6�   $
��Left=�6�   $��1��6�   $��
390,50,0,0q�6�   ��6%   �� *mainModel._dataBits+ 6Q   �� *mainModel.Pick_dataBit+6�   �� 5!   
   -   5        $ stopBit��5!      $ 0��6�   $	��120��6�   $��30��6�   $	��Top=�6�   $
��Left=�6�   $��1��6�   $��
570,50,0,0q�6�   ��6%   �� *mainModel._stopBits+ 6Q   �� *mainModel.Pick_stopBit+6�   �� 5"   
   -   5        $ 	parityBit��5"      $ 1��6�   $	��120��6�   $��30��6�   $	��Top=�6�   $
��Left=�6�   $��1��6�   $��
750,50,0,0q�6�   ��6&   �� *mainModel._parityBits+ 6T   �� *mainModel.Pick_parityBit+6�   �� 5%   
   -   5         ��Name$ btn_Connect��5%      $	��150��6&   $��50��62   $��20(�6�   $
��Bold"�6�   
���  ����6>   �� *mainModel.btn_start_name+ �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *mainModel.btn_start_color+	 �� Click	 6�   .   (WPF_TestProgram01.MethodBindingExtension  *btn_Connect_Click+�� 5&   
   -   5        $ btn_OnLineCheck��5&      $	��150��6*   $��40��66   $��ON-Line Check��6B   $	��Top=�6Z   $��Center=�6r   $��1��6�   $��0,20,0,0q�6�   ��6�   �� *btn_OnlineCheck+�� 5'   
   -   5        $ btn_WriteCard��5'      $	��150��6(   $��40��64   $��Write CardKey��6@   $	��Top=�6X   $��Center=�6p   $��1��6�   $��0,90,0,0q�6�   ��6�   �� *btn_WriteCard+�� 5(   
   -	   5        $ btn_ReadCard��5(      $	��150��6'   $��40��63   $��Read CardKey��6?   $	��Top=�6V   $��Center=�6n   $��1��6�   $��	0,160,0,0q�6�   ��6�   �� *btn_ReadCard+�� 5)   
   -
   5        $ btn_RequestCard��5)      $	��150��6*   $��40��66   $��Request CardKey Data��6B   $	��Top=�6a   $��Center=�6y   $��1��6�   $��	0,230,0,0q�6�   �� 5*   
   -   5        $ btn_SetCard��5*      $	��150��6&   $��40��62   $��Set Card Sector��6>   $	��Top=�6X   $��Center=�6p   $��1��6�   $��	0,300,0,0q�6�   �� 5+   
   -   5        $ btn_SetSector��5+      $	��150��6(   $��40��64   $��Set Card Sector Key��6@   $	��Top=�6^   $��Center=�6v   $��1��6�   $��	0,370,0,0q�6�   �� 5,   
   -   5        $ btn_SetEncoder��5,      $	��150��6)   $��40��65   $��Set Encoder Write Data��6A   $	��Top=�6b   $��Center=�6z   $��1��6�   $��	0,440,0,0q�6�   ��6�   �� *
btn_DBconn+�� 5/   
   $��1. COM Port��6   $	��Top=�6&   $
��Left=�6>   $��1��6Y   $��	30,20,0,0q�6i   $
��Bold"�6|   $��14(�6�   �� 50   
   $��2. Baud Rate��6   $	��Top=�6'   $
��Left=�6?   $��1��6Z   $��
210,20,0,0q�6j   $
��Bold"�6~   $��14(�6�   �� 51   
   $��3. Data Bit��6   $	��Top=�6&   $
��Left=�6>   $��1��6Y   $��
390,20,0,0q�6i   $
��Bold"�6}   $��14(�6�   �� 52   
   $��4. Stop Bit��6   $	��Top=�6&   $
��Left=�6>   $��1��6Y   $��
570,20,0,0q�6i   $
��Bold"�6}   $��14(�6�   �� 53   
   $��5. Parity Bit��6   $	��Top=�6(   $
��Left=�6@   $��1��6[   $��
750,20,0,0q�6k   $
��Bold"�6   $��14(�6�    � 55   
   -   5        
  �Name$
 frame��55   9   $��1��6H   $��1��6X     � NavigationUIVisibility$ Hidden=�6e     � Source 6   �� *mainModel.frameSource+��56      �� 57       �� 
TargetType"  �6"   .R�58      �� # z 6'   59      5;      5<      5=      