   M S B A M L   `   `   `  ����T  PSoftwareFusionProject_JSH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SoftwareFusionProject_JSH.ViewsSoftwareFusionProject_JSH.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      -    'SoftwareFusionProject_JSH.Views.Lecture   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:SoftwareFusionProject_JSH.Views     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5        N� Title$  Lecture��5
      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��1.5* �6   �� 5      $��7* �6   �� 5      $��1* �6   .+�5   
   �� $��2��6   $��Center=�6$   $��Center=�6A   $��6호관 301호��6]   $��20(�6p   $
��Bold"�6~   �� 5   
   $��2��6   $��Right=�6%   $��Center=�6A   $��
0,10,10,10q�6\   $��Security Mode��6p   $	��120��6�   $��25��6�   
���   �
�������$
��Bold"�6�   �� 5   
   $��0��6   $��1��6    $��Center=�6-   $��Center=�6J   $��20(�6e   $
��Bold"�6s   $��Human Detection��6�   #  LiveCharts.Wpf.CartesianChart  5   
   $��2��6   &   LiveCharts.Wpf.Charts.Base.Chart   AxisY 5        LiveCharts.Wpf.Axis     
Foreground
 �   �   
FontWeight$
 Bold"�6.      MaxValue$
 3000Q�6@      MinValue$ 0Q�6P      Series 5"        LiveCharts.Wpf.LineSeries    LiveCharts.Wpf.Series	   
Foreground
	 ��  �
   Values
 6!   �� *detectValues+6A     5#      
	 �  ��
 6!   �� *detectValues_AVR+6E   5%      &   System.Windows.Controls.DataGrid  5'   
   $��1��6   $��2��6#      AutoGenerateColumns .  
�������$��10,10,10,20q�6_   ��6t   �� *	accessLog+   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ 순서��6%      Width5	  /System.Windows.Controls.DataGridLengthConverter$ 2*	 6H   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 61   �� *No+6H     5*      $ 학번��6%   $ 4*	 6J    61   �� *code+6J     5+      $ 출입��6%   $ 2*	 6N    61   �� *
division+6N     5,      $ 시간��6%   $ 6*	 6O    61   �� *	eventTime+6O   5.      �� 50   
   $��Center=�6   $��Center=�6/   $
��Bold"�6L   $��20(�6^   $��0��6l   $��3��6|   ��6�   �� *lectureStatus+�� 52   
   $��1��6   $��1��6    $��Center=�6-   $��Center=�6J   $��20(�6e   $
��Bold"�6s   $��Access Details��6�   �� 54   
   $��0��6   $��2��6'   $��3��6;   $��	10,0,0,10q�6H   .��55      ��  �� TextWrapping$
 Wrap=�6   
���   �
��� �����6Q   �� *accessStatus+56      58      5:      