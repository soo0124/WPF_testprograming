   M S B A M L   `   `   `  ����F  BTestprogram, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestprogramTestprogram  5   	       Testprogram.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Testprogram     5   	     � Title$  
MainWindow��5   	   $��700.609��6   $��1100.739��6-    � 	Resources 5
      ��%    5      .��5      � .+�5   
   �� -   5         ��Name$ tabControl_Xaml��5      .@�5      �� $��환경설정��6   $��0��6$   .��5      � ���	#FFE5E5E5 � ColumnDefinitions 5      �� 5      $
��153* �6+   �� 5      $	��16* �6+   �� 5      $
��926* �6+   .+�5       �� $��통신 포트 설정��6   $
��Left=�6/   $��	97,64,0,0q�6J   $	��Top=�6]   $	��149��6u   $��3��6�   �� 5!      -   5        $��portNum��5!   q   $
��Left=�6   $��	37,67,0,0q�6:   $	��Top=�6M   $	��120��6e   $��2��6�   �� 5"      -   5        $��연결��5"      $
��Left=�6*   $��
177,67,0,0q�6E   $	��Top=�6Y   $��75��6q   
���2͚�$��2��6�   �� 5#      -   5        $��해제��5#      $
��Left=�6*   $��
268,67,0,0q�6E   $	��Top=�6Y   $��75��6q   
����p��$��2��6�   �� 5$      -   5         ��Name$ 
portStatus��5$      $��포트 닫힘��61   $
��Left=�6A   $��
682,53,0,0q�6\   $	��Top=�6p   $	��170��6�   $	��170��6�   
��� d �$��30(�6�   $��2��6�    5%       �� 
TargetType �� Property �� Value��%`   '��       �� 5&      " ��6$   .�5'   "   ��  �@��CornerRadius$	 100��6A   5(      5)      5*      �� 5+      $��폴링 속도 설정��6   $
��Left=�6/   $��
97,151,0,0q�6J   $	��Top=�6^   $	��149��6v   $��3��6�   �� 5,      -   5        $��falling_Speed��5,   �   $
��Left=�6   $��23��69   $��
37,154,0,0q�6E    �� TextWrapping$
 Wrap=�6Y   $��50��6m   $	��Top=�6x   $	��120��6�   $��2��6�   �� 5-      -   5        $��적용��5-      $
��Left=�6*   $��177,153,0,0q�6E   $	��Top=�6Z   $��75��6r   
���2͚�$��2��6�   �� 5.      -   5        $��해제��5.      $
��Left=�6*   $��268,153,0,0q�6E   $	��Top=�6Z   $��75��6r   
����p��$��2��6�   5/      50      �� 52      $��중계기설정��6   $��22��6%   $��Bottom=�61   $��1��6L   .��53      � ���	#FFE5E5E5 54      �� 55      $	��52* �6+   �� 56      $��4* �6+   �� 57      $
��309* �6+   .+�5:      �� $��RCU 전체 개수 설정��6   $
��Left=�63   $	��Top=�6N   $��	25,70,0,0q�6f   $��15(�6y   $��3��6�   �� 5;      -	   5        $��rcuAllCount��5;   �   $
��Left=�6   $��23��69   $��
34,105,0,0q�6E   $
 Wrap=�6Y   $��0��6m   $	��Top=�6w   $	��120��6�   6�   �� 5<      -
   5        $��적용��5<      $
��Left=�6*   $��	2,105,0,0q�6E   $	��Top=�6X   $��75��6p   
��� ���$��2��6�   �� 5>      -   5        	 ��Name$	 dtcAllCount��5>   �   $
��Left=�6   $��23��69   $��
34,219,0,0q�6E   $
 Wrap=�6Y   $��1��6m   $	��Top=�6w   $	��120��6�   6�   �� 5?      $��DTC 전체 개수 설정��6   $
��Left=�63   $	��Top=�6N   $��
25,184,0,0q�6f   $��15(�6z   $��3��6�   �� 5@      -   5        $��적용��5@      $
��Left=�6*   $��	2,219,0,0q�6E   $	��Top=�6X   $��75��6p   
��� ���$��2��6�   �� 5B      $"��DTC 별 연동 개수 설정��6   $
��Left=�65   $	��Top=�6P   $��
196,88,0,0q�6h   $��15(�6|   $��2��6�   �� 5D      -   5        
 ��Name$
 ListDTC��5D      $��196,119,146,59q�6/   $��2��6G   ��5F      �� 5G      .R�5H   "   ��  �� Orientation$ Vertical=�6-   5I      ��5L      �� 5M      .R�5N   "   �� $ 
Horizontal=�6-   .+�5O   &   �� $��0,0,10,0q�6F   ��60   �� *Name+6F   �� 5P   &   $��0,0,10,0q�6H   $	��100��6Z   ��6.   �� *
RcuCount+6Z   5Q   #   5R      5U      �� 5V      -   5        $��전 송��5V      $
��Left=�6+   $��84��6F   $��778,119,0,0q�6R   $	��Top=�6g   $	��102��6   $��15(�6�   
��� ���$��2��6�   5W      5X      �� 5\      $��	RCU설정��6   $��2��6%   .��5]      � ���	#FFE5E5E5.+�5_      �� $��객실타입��6   $
��Left=�6+   $��	25,24,0,0q�6F   $	��Top=�6Y   $��15(�6q   �� 5`      -   5        $��CB_MODE��5`   ~   $
��Left=�6   $��21��6:   $��
106,29,0,0q�6F   $	��Top=�6Z   $	��130��6r   6~   �� 5b      $+��%라이트스위치 & 릴레이 설정��6   $
��Left=�6:   $��
382,67,0,0q�6U   $	��Top=�6i   $��20(�6�   �� 5e      -   5        $
 lsList��5e   ~   $
��Left=�6   $	��499��69   $��
25,109,0,0q�6F   $	��Top=�6Z   $	��957��6r   ��5f      �� 5h      .R�5i   "   �� $ 
Horizontal=�6-   5k   #   5l      ��5o      �� 5q      .R�5r   "   �� 
���   �$	��140��6<    �� CornerRadius$ 2��6H   $��1q�6Y   ._�5s   &   �� $ Vertical=�61   $��Stretch=�6H   
�������$��5q�6{   .+�5u   *   �� ��64   �� *	lightName+ �� StringFormat$ *{0}번 전등스위치���� 5w   *   ��63   �� *
lightNum+ �� SelectedItem 6T   �� *lightNum_Select+ �� Mode$ TwoWay=��� 5y   *   $��마스터 설정��63    d� 	IsChecked 6D   �� *
isMaster+�� 5{   *   $��화장실 설정��63    6D   �� *isBath+�� 5}   *   $��기가지니 설정��63    6E   �� *isGiga+�� 5   *   ��62   �� *
Relay_List+��5�   .   �� 5�   2   .R�5�   6   �� $ Vertical=�6A   5�   7   5�   3   ��5�   .   �� 5�   2   .R�5�   6   �� 
���  ��$	��115��6N   $ 10��6Z   ._�5�   :   �� $ Vertical=�6E   
�������.+�5�   >   ��  �� ContentStringFormat$ 	RELAY {0}��6�   ��6G   �� *
Relay_Num1+ 6f   �� *	Relay_CK1+6�   �� 5�   >   $ 	RELAY {0}��6�   ��6G   �� *
Relay_Num2+ 6f   �� *	Relay_CK2+6�   �� 5�   >   $ 	RELAY {0}��6�   ��6G   �� *
Relay_Num3+ 6f   �� *	Relay_CK3+6�   �� 5�   >   $ 	RELAY {0}��6�   ��6G   �� *
Relay_Num4+ 6f   �� *	Relay_CK4+6�   �� 5�   >   $ 	RELAY {0}��6�   ��6G   �� *
Relay_Num5+ 6f   �� *	Relay_CK5+6�   �� 5�   >   $ 	RELAY {0}��6�   ��6G   �� *
Relay_Num6+ 6f   �� *	Relay_CK6+6�   �� 5�   >   $ 	RELAY {0}��6�   ��6G   �� *
Relay_Num7+ 6f   �� *	Relay_CK7+6�   �� 5�   >   $ 	RELAY {0}��6�   ��6G   �� *
Relay_Num8+ 6f   �� *	Relay_CK8+6�   5�   ;   5�   7   5�   3   5�   +   5�   '   5�   #   5�      5�      �� 5�      -   5        $��추가��5�      
������$
��Left=�6B   $��50��6]   $��1001,110,0,0q�6i   $	��Top=�6   $��50��6�   6�   �� 5�      -   5        $��삭제��5�      
�������$
��Left=�6A   $��50��6\   $��1001,172,0,0q�6h   $	��Top=�6~   $��50��6�   6�   �� 5�      -   5        $��릴레이
 추가��5�      
������$
��Left=�6K   $��50��6f   $��1001,319,0,0q�6r   $	��Top=�6�   $��50��6�   6�   �� 5�      -   5        $��릴레이
 삭제��5�      
�������$
��Left=�6J   $��50��6e   $��1001,382,0,0q�6q   $	��Top=�6�   $��50��6�   6�   �� 5�      -   5        $��전송��5�      $
��Left=�6*   $��
958,24,0,0q�6E   $	��Top=�6Y   $��70��6q   $��70��6|   
��� ��� 5�      ��%_   '��       �� 5�      " ��6$   .�5�   "   ��  �@��CornerRadius$ 50��6A   5�      5�      5�      5�      5�      �� 5�      $��RELAY설정��6   $��3��6'   .��5�      � ���	#FFE5E5E5.+�5�      �� $��객실타입��6   $
��Left=�6+   $��	25,24,0,0q�6F   $	��Top=�6Y   $��15(�6q   �� 5�      -   5        $��CB_MODE_RELAY��5�   ~   $
��Left=�6   $��21��6:   $��
106,29,0,0q�6F   $	��Top=�6Z   $	��130��6r   6~   �� 5�      $��B접점��6   $
��Left=�6*   $��
325,24,0,0q�6E   $	��Top=�6Y   $��15(�6q   �� 5�      -   5        $��normal_relay��5�   ~   $
��Left=�6   $��21��6:   $��
376,29,0,0q�6F   $	��Top=�6Z   $	��130��6r    �� SelectedValue 6�   �� *Normal_Select+�� 5�      $��A접점��6   $
��Left=�6*   $��
595,24,0,0q�6E   $	��Top=�6Y   $��15(�6q   �� 5�      -   5        $��valve_relay��5�   ~   $
��Left=�6   $��21��6:   $��
646,29,0,0q�6F   $	��Top=�6Z   $	��130��6r    6�   �� *Valve_Select+�� 5�      -   5        $��전송��5�      $
��Left=�6*   $��70��6E   $��1007,14,0,0q�6Q   $	��Top=�6f   $��70��6~   
��� ��� 5�      ��%_   '��       �� 5�      " ��6$   .�5�   "   ��  �@��CornerRadius$ 50��6A   5�      5�      5�      &   System.Windows.Controls.DataGrid  5�      -   5          Name$ 	RelayList��5�      $��50,100,50,50q�6V      AutoGenerateColumns .  ��62   �� *RCU_LS_List+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Light Switch��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *	lightName+$ {0}번 전등스위치��   HeaderStyle 5�   "   �� 5�   &   =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6,   .�5�   *   ��  � ��$ 40��6C   �� 5�   *    � ��
 �2͚�6G   �� 5�   *    � ��$ 12(�6E   �� 5�   *    � ��$ Stretch=�6P   �� 5�   *    � ��$ Center=�6W   5�   '   5�      5�      5�      5�      5�      5�      5�      