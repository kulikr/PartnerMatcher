   M S B A M L   `   `   `  ����I  EPartnerMatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PartnerMatcherPartnerMatcher  5   	   &     PartnerMatcher.PartnershipWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PartnerMatcher     5   	     � Title$  PartnershipWindow��5   	   $	��600��6#   $	��700��60    � WindowStartupLocation$ CenterScreen=�6<   ��5	      �� 5
   
    �� ImageSource$ photo/background.jpg��6    j� Stretch$ UniformToFill=�68   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��625* �6   �� 5      $	��91* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��6* �6   .+�5   
   �� $*��$רשימת השותפויות שלי��6   $��Guttman Aharoni)�60   $��20(�6M   $
��Bold"�6[   $��Center=�6m   $��Center=�6�   $��26��6�   $��	64,6,27,1q�6�   �� 5   
   $"��בחר תחום שותפות��6   $��Guttman Aharoni)�6+   $��16(�6H   $
��Bold"�6V   $��Right=�6h   $��2��6�   $��
0,10,63,39q�6�   $��1��6�   �� 5   
   -   5        $��box_interest��5      $��1��6'   $��40��64   $��Right=�6p   $	��234��6�   $��
0,4,132,27q�6�   �� 5   
   -   5        $��display��5      $��הצג שותפויות��66   $��15(�6M   $��Guttman Aharoni)�6[   $��40��6x   $��1��6�   $	��106��6�   $
��Left=�6�   $��	74,4,0,27q�6�   �� 5   
   -   5        $��listView��5      $��Right=�6%   $y�Hidden=�6B   $��2��6V   $��0,41.333,0.333,52q�6c    �� View 5      �� 5      .P�5      �� $��קישור לשותפות��6%    �� CellTemplate 5      �� 5      .R�5    "   �� -   5        $@��:לחץ על מנת לראות את פרטי השותפות��5!      $��0q�5"      $��Center=�5#      5$      5%      5'      �� 5(      $$��מייל מנהל שותפות��6%    �� DisplayMemberBinding 6?   �� *ManagerMail+�� 5)      $��עיר��6%    62   �� *City+�� 5*      $��מס'ד��6%    63   �� *Id+5+      5-      5.      5/      