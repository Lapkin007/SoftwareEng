   M S B A M L   `   `   `  ����a  ]Group7_Hotel_Service_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Group7_Hotel_Service_Management_System&Group7_Hotel_Service_Management_System  5   	   <    6Group7_Hotel_Service_Management_System.Reserve_confirm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:Group7_Hotel_Service_Management_System     5   	     � Title$  HSMS-Reserve_confirm��5   	   $	��400��6&   $
��1000��63   .��5	      � .+�5
   
   (�  (� Stretch$  fill=�6   .��5      �� $
�� 795��6   $
�� 350��6"   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DG_reserve_confirm��5      $	��199��67   $	��386��6D   
 �� Top$ 53��6{    �� Left$ 10��6�   �� 5      $M��G已预约信息：                                   已入住信息：��6   $ 10��6R   $ 9��6c   $��39��6r   $	��775��6~   $��24(�6�   ���	#FFEFD4D4���	#FF732A2A6�   �� 5      -   5         ��Name$ GB_Reserve_confirm��5      $	��102��67   $��预约确认区域��6D   $ 8��6T   $	 238��6d   $	��777��6u   $��18(�6�   $��SimHei)�6�   ���	#FF96DCC3��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5      �  � Color$ Black��6+   � 5      $ 	#FF003EFF��6+   	 � Offset$	 1Q�6=   5      .��5      � $
��Left=�6   $��82��66   $	��Top=�6B   $	��767��6Z   
 � ColumnDefinitions
 5      �� 5      $	��61* �6/   �� 5      $
��706* �6/   .+�5      �� -   5         ��Name$ B_reserve_confirm��5   !   $��预约确认��6<   $��20(�6K   $��Sitka Small)�6Y   $��581,13,10,23q�6r   $��1��6�   ��5      �� 5   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5   &   � $ Black��63   � 5   &   $ 	#FF6BED85��63   $	 1Q�6E   � 5   &   $ 	#FF78BB60��63   $	 0.277Q�6E   � 5    &   $ 	#FF5CF96D��63   $	 0.003Q�6E   5!   #   5#      �� 5$      -   5         ��Name$ CB_name��5$   #   $
��Left=�64   $��33��6O   $��6,19,0,0q�6[   $	��Top=�6m   $��89��6�   $��1��6�   �� 5%      -   5        $ CB_id��5%   #   $
��Left=�62   $��33��6M   $��
168,19,0,0q�6Y   $	��Top=�6m   $	��115��6�   $��1��6�   �� 5&      -   5         ��Name$ 
persion_id��5&   "   $
��Left=�66   $��24��6Q   $��
386,24,0,0q�6]    �� TextWrapping$
 Wrap=�6q   $	��Top=�6�   $	��190��6�   $��1��6�   �� 5'      $��1��6    $��身份证号码��60   $
��Left=�6@   $��34��6[   $��
283,19,0,0q�6g   $	��Top=�6{   $��98��6�   �� 5(      $��1��6    $��	房间号��60   $
��Left=�6>   $��34��6Y   $��
100,19,0,0q�6e   $	��Top=�6y   $��63��6�   �� 5)      $��姓名��6    $
��Left=�6-   $��34��6H   $��	15,19,0,0q�6T   $	��Top=�6g   $��51��6   $��2��6�   5*      5+        5,      -   5        $ DG_live��5,      $	��199��6,   $	 403��69   $ 53��6K   $	��382��6[   5.      5/      50      51      