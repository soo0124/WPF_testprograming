   M S B A M L   `   `   `  ����K  GWPF_Testprogram2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_Testprogram2.ViewsWPF_Testprogram2.Views  5      #    WPF_Testprogram2.Views.V_Bulk   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:WPF_Testprogram2.Views     5      .��5
      � $��20q�6     � 	Resources  5   
    �� 
TargetType �� Property �� Value��%G  '��       '�� o     '�� �     �� 5      " ��6   .�5      ��  � ��$	 Top=�66   �� 5       � ��$
 Left=�68   5      �� 5      " ��6   .�5      ��  � ��$ 24��6+   5      �� 5      " ��6   .�5      ��  � ��$
 Left=�6?   �� 5       � ��$ Center=�6=   5      5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $��46 �6   �� 5$      $
��Auto �6   �� 5%      $��* �6   .+�5)   
   �� $��0��6   $��0��6    $��테스트 명령어 : ��6-   �� 5*   
   $��1��6   $��0��6#   ��60   �� *ExcelCommandList+ �� SelectedItem 6Y   �� *SelectExcelCommand+�� 5-   
   $��1��6   $��1��6%    �� Orientation$ 
Horizontal=�62   $��0,8,0,20q�6K   .+�5.      �� $��수신대기시간(ms) : ��6   �� 5/      $	��120��6   ��6"   �� *ExcelTestTime+50      �� 53   
   $��0��6   $��2��6    $��테스트 파일 : ��6-   � 54   
   $��1��6   $��2��6   $��0,0,0,20q�6,    55      �� 56      �� 57      $��80 �6#   �� 58      $��80 �6#   .+�5;      �� $��0��6   ��6&   �� *TxtSourceExcelFile+�� 5<      $��1��6   $��기본파일��6&    �� Click 65   3   -WPF_Testprogram2.Views.MethodBindingExtension  *BtnClick_DefaultFile+�� 5=      $��2��6   $��파일찾기��6&    65     *BtnClick_LoadSourceFile+5>      �� 5A   
   $��0��6   $��3��6    $��저장 경로 : ��6-   � 5B   
   $��1��6   $��3��6    5C      �� 5D      �� 5E      $��80 �6#   .+�5H      �� $��0��6   ��6&   �� *TxtDestinationExcelFile+�� 5I      $��1��6   $��경로찾기��6%    64     *BtnClick_SaveFilePath+5J      5K      5L      