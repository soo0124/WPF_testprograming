   M S B A M L   `   `   `  ����L  HWPF_TestProgram01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPF_TestProgram01.ViewsWPF_TestProgram01.Views  5      K*clr-namespace:WPF_TestProgram01.ViewModelsWPF_TestProgram01.ViewModels  5      (    "WPF_TestProgram01.Views.SetEncoder   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:WPF_TestProgram01.Views     5      9vm*clr-namespace:WPF_TestProgram01.ViewModels     5        N� Title$  
SetEncoder��5
      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��6* �6   �� 5      $��2* �6   .+�5   
   �� 
����·�$��0��6&   $��1��63   $��5��6C   �� 5   
   $��DB IP��6   $��0��6    $��0��6-   $	��Top=�6=   $
��Left=�6U   $	��100��6q   $��25��6}   $��
110,30,0,0q�6�   $��13(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ txb_IP��5      $��0��6"   $��0��6/   $��Center=�6?   $��Center=�6Z   $	��250��6w   $��25��6�   ��6�   �� *dbModel.tbx_DB_IP+ �� UpdateSourceTrigger$ PropertyChanged=��� 5    
   $��DB PORT��6   $��1��6"   $��0��6/   $	��Top=�6?   $
��Left=�6W   $	��100��6s   $��25��6   $��
100,30,0,0q�6�   $��13(�6�   $
��Bold"�6�   �� 5!   
   -   5        $ txb_Port��5!      $��1��6$   $��0��61   $��Center=�6A   $��Center=�6\   $	��250��6y   $��25��6�   ��6�   �� *dbModel.tbx_DB_PORT+$ PropertyChanged=��� 5#   
   $��DB NAME��6   $��2��6"   $��0��6/   $	��Top=�6?   $
��Left=�6W   $	��100��6s   $��25��6   $��
100,30,0,0q�6�   $��13(�6�   $
��Bold"�6�   �� 5$   
   -   5        $ txb_Name��5$      $��2��6$   $��0��61   $��Center=�6A   $��Center=�6\   $	��250��6y   $��25��6�   ��6�   �� *dbModel.tbx_DB_NAME+$ PropertyChanged=��� 5&   
   $��DB USER��6   $��3��6"   $��0��6/   $	��Top=�6?   $
��Left=�6W   $	��100��6s   $��25��6   $��
100,30,0,0q�6�   $��13(�6�   $
��Bold"�6�   �� 5'   
   -   5        $ txb_User��5'      $��3��6$   $��0��61   $��Center=�6A   $��Center=�6\   $	��250��6y   $��25��6�   ��6�   �� *dbModel.tbx_DB_USER+$ PropertyChanged=��� 5)   
   $��DB PW��6   $��4��6    $��0��6-   $	��Top=�6=   $
��Left=�6U   $	��100��6q   $��25��6}   $��
110,30,0,0q�6�   $��13(�6�   $
��Bold"�6�   �� 5*   
   -   5        $ txb_Pw��5*      $��4��6"   $��0��6/   $��Center=�6?   $��Center=�6Z   $	��250��6w   $��25��6�   ��6�   �� *dbModel.tbx_DB_PW+$ PropertyChanged=��� 5,   
   -   5         ��Name$ btn_DbConnect��5,      $��0��6(   $��1��65   $��Center=�6E   $��Center=�6`   $	��100��6�   $��50��6�   $��DB접속��6�   $��20(�6�   $
��Bold"�6�   ��6�   �� *dbModel.btn_dbstart_color+��6�   �� *btn_DB_start+�� 5-   
   -   5        $ btn_DbInsert��5-      $��1��6'   $��1��64   $��Center=�6D   $��Center=�6_   $	��120��6�   $��35��6�   $��INSERT��6�   $��15(�6�   $
��Bold"�6�   ��6�   �� *btn_DB_insert+5/      50      