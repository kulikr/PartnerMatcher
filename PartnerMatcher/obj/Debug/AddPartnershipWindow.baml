   M S B A M L   `   `   `  ����I  EPartnerMatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PartnerMatcherPartnerMatcher  5   	   )    #PartnerMatcher.AddPartnershipWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PartnerMatcher     5   	     � Title$  AddPartnershipWindow��5   	   $	��410��6&   $	��400��63    � WindowStartupLocation$ CenterScreen=�6?    � 
ResizeMode$ NoResize=�6d   ��5	      �� 5
   
    �� ImageSource$ photo/background.jpg��6    j� Stretch$ UniformToFill=�68   .��5      � $��0,0,-0.333,-1.667q�6    � ColumnDefinitions 5   
   �� 5      $��169.5* �6   �� 5      $��169.5* �6    � RowDefinitions 5   
   �� 5      $	��62* �6   �� 5      $	��39* �6   �� 5      $	��63* �6   �� 5      $	��47* �6   �� 5      $	��95* �6   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $��26��6:   $	��Top=�6F   $��93��6^   $��photo/Logomakr_9P10tS.png��6i   $��10,83.333,0,0q�6�   $��4��6�   �� 5   
   -   5         ��Name$ headline��5      $
��Bold"�6&   	 �� TextAlignment$	 Right=�68   $��28(�6N   $��Algerian)�6\   $��11,15,10.667,10q�6s   $��2��6�   $��0��6�   $��הוספת שותפות��6�   �� 5   
   -   5        
 ��Name$
 sp_text��5      $��1��6&   $
��Left=�66   $	��215��6Q   $��10.667,9.667,0,0q�6^   $��1��6x   $��4��6�   $	��Top=�6�   $	��176��6�   �� 5   
   -   5        $
 sp_data��5      $
��Left=�6&   $	��215��6A   $��11,9.667,0,0q�6N   $��1��6d   $��4��6q   $	��Top=�6�   $	��176��6�   5      �� 5   
   -   5         ��Name$ b_finish��5      $��
אישור��6#   $
��Left=�63   $��28��6N   $��10.667,58.667,0,0q�6Z   $	��Top=�6u   $��88��6�   ���	#FFFA9034$
��Bold"�6�   $��4��6�   $��1��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5          
BlurRadius$ 3Q�6#      Opacity$	 0.6Q�62   5"      5#      5$      