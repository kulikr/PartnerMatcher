   M S B A M L   `   `   `  ����I  EPartnerMatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PartnerMatcherPartnerMatcher  5   	        PartnerMatcher.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PartnerMatcher     5   	     � Title$  LoginWindow��5   	   $	��200��6   $	��300��6*    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�5	   	   ��5
      �� 5   
    �� ImageSource$ photo/background.jpg��6    j� Stretch$ UniformToFill=�68   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��49* �6   �� 5      $
��157* �6   �� 5      $	��56* �6   �� 5      $	��33* �6    � RowDefinitions 5   
   �� 5      $	��50* �6   �� 5      $	��37* �6   �� 5      $	��37* �6   �� 5      $	��37* �6   .+�5   
   �� -   5         ��Name$ txt_headLine��5      $��1��6*   $��2��6:   $��Center=�6N   $��32��6k   $
��Wrap=�6w   $"�� התחברות למערכת��6�   $	��Top=�6�   $	��164��6�   $��Guttman Aharoni)�6�   $
��Bold"�6�   $��18(�6�   $��15.667,15,33,2q�6  ��6  Z� 6  �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $��23��6:   $	��Top=�6F   $��84��6^   $��photo/Logomakr_9P10tS.png��6i   $��2��6�   $��5,10.333,0,0q�6�   	 J� RenderTransformOrigin$	 
0.456,6.13&�6�   $��3��6�   �� 5   
   -   5        $ txt_mail��5      $��2��6&   $
��Left=�66   $��22��6Q   $��10,9.667,0,0q�6]   $��1��6s   $
��Wrap=�6�   $��אי-מייל��6�   $	��Top=�6�   $��78��6�   $��Guttman-Aharoni)�6�   $
��Bold"�6�   $��2��6  ��6�   Z� 6  �� 5   
   -   5        
 ��Name$
 tb_mail��5      $
��Left=�6#   $��27��6>   $��41,4.667,0,0q�6J   $��1��6`    �� TextWrapping$
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��155��6�   $��2��6�   �� 5    
   -   5        $ txt_password��5       $��2��6*   $
��Left=�6:   $��22��6U   $��9.667,10.333,0,0q�6a   $��2��6{   $
��Wrap=�6�   $��
סיסמה��6�   $	��Top=�6�   $��78��6�   $��Guttman-Aharoni)�6�   $
��Bold"�6�   ��6�   Z� �� 5!   
   -   5        $
 tb_password��5!      $
��Left=�6'   $��27��6B   $��41,5.333,0,0q�6N   $��2��6d   $
 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��155��6�   $��2��6�   �� 5#   
   -   5         ��Name$ 	b_connect��5#      $��1��6$   $��התחברות��64   $
��Left=�6F   $��59.667,0,0,10q�6a   $��3��6x   $��62��6�   $��Guttman-Aharoni)�6�   $
��Bold"�6�   $��21��6�   $��Bottom=�6�   6�   5%      5&      