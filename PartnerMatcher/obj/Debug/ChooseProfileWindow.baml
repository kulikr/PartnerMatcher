   M S B A M L   `   `   `  ����I  EPartnerMatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PartnerMatcherPartnerMatcher  5   	   (    "PartnerMatcher.ChooseProfileWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PartnerMatcher     5   	     � Title$  ChooseProfileWindow��5   	   $	��300��6%   $	��410��62    � WindowStartupLocation$ CenterScreen=�6>    � 
ResizeMode$ NoResize=�6c   ��5	      �� 5
   
    �� ImageSource$ photo/background.jpg��6    j� Stretch$ UniformToFill=�68   .��5      �  � ColumnDefinitions 5   
   �� 5      $��169.5* �6   �� 5      $��169.5* �6    � RowDefinitions 5   
   �� 5      $	��58* �6   �� 5      $	��42* �6   �� 5      $	��63* �6   �� 5      $	��46* �6   �� 5      $	��95* �6   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $��26��6:   $	��Top=�6F   $��93��6^   $��photo/Logomakr_9P10tS.png��6i   $��10,60.667,0,0q�6�   $��4��6�   �� 5   
   $
��Bold"�6   $��28(�6&   $��Algerian)�64   $��197,24,29.667,27.333q�6K   $��2��6i   $��0��6}   $��בחר פרופיל��6�   $��2��6�   �� 5   
   -   5         ��Name$ listBox_profiles��5      $��2��6,   $
��Left=�6@   $	��101��6[   $��	39,24,0,0q�6h   $��1��6{   $��3��6�   $	��Top=�6�   $	��336��6�   �� 5   
   -   5        	 ��Name$	 	b_confirm��5      $��
אישור��6$   $
��Left=�64   $��28��6O   $��152,10.333,0,0q�6[   $	��Top=�6s   $��88��6�   ���	#FFFA9034$
��Bold"�6�   $��4��6�   $��2��6�   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 3Q�6#      Opacity$	 0.6Q�62   5      5       5!      