   M S B A M L   `   `   `  ����Z  VExtremely Casual Game Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Extremely_Casual_Game_OrganizerExtremely_Casual_Game_Organizer  5   	   2    ,Extremely_Casual_Game_Organizer.pgCreateTeam   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Extremely_Casual_Game_Organizer     5   	     N� Title$  pgCreateTeam��5   	   $	��500��6   $	��800��6+    N� FontSize$ 15(�67   .��5	      � $��0,0,33,0q�6    � ColumnDefinitions 5
   
   �� 5      $
��115* �6   �� 5      $	��83* �6   .+�5   
   �� -   5         ��Name$	 lbl��5      $��Create a Team��6   $
��Left=�65   $��
425,10,0,0q�6P   $	��Top=�6d    J� RenderTransformOrigin$ 1.558,0.693&�6|   $��36(�6�   $
��Bold"�6�   $��Sorts Mill Goudy)�6�   $��2��6�   �� 5   
   -   5         ��Name$ txtTeamName��5      $
��Left=�6'   $��33��6B   $��425,121,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��281��6�   $��16(�6�   $��1��6�   $��2��6�   �� 5   
   $��
Team name:��6   $
��Left=�6%   $��
425,90,0,0q�6@   $	��Top=�6T   $ 1.558,0.693&�6l   $��16(�6�   $��2��6�   �� 5   
   $��Sport:��6   $
��Left=�6!   $��425,270,0,0q�6<   $	��Top=�6Q   $ 1.558,0.693&�6i   $��16(�6�   $��2��6�   �� 5   
   -   5         ��Name$ 	ddSportId��5      $
��Left=�6&   $��425,306,0,0q�6A   $	��Top=�6V   $	��281��6n   $��3��6z   $��16(�6�   $��2��6�   �� 5   
   $��Gender:��6   $
��Left=�6"   $��425,182,0,0q�6=   $	��Top=�6R   $ 1.558,0.693&�6j   $��16(�6�   $��2��6�   �� 5   
   -   5        $ ddGender��5      $
��Left=�6%   $��425,218,0,0q�6@   $	��Top=�6U   $	��281��6m   $��2��6y   $��16(�6�   $��2��6�   .@�5      �� $�� ��6    �� 
IsSelected . 6&   �� 5      $
��Male��6   �� 5      $��Female��6   �� 5      $��I prefer not to specify��6   5      �� 5   
   -   5        	 ��Name$	 	btnCreate��5      $��Create Team��6$   $
��Left=�6:   $��425,374,0,0q�6U   $	��Top=�6j   $	��169��6�   $��16(�6�   $��45��6�   
�������$��4��6�   $��2��6�   ��5      �� 5      
 �� Color$
 	#FF8C52FF��6"   5      �� 5   
   -   5        $	 btnReset��5      $
��Back��6#   $
��Left=�62   $��171,374,0,0q�6M   $	��Top=�6b   $��94��6z   $��1��6�   $��16(�6�   $��45��6�   $ 1.738,0.489&�6�   ���	#FF8C52FF$��5��6  ��5       �� 5!      #
 � ��6"   5#      �� 5$   
   -   5        $ 
lblSportId��5$      $��Create an account��6$   $
��Left=�6@   $��
82,259,0,0q�6[   $	��Top=�6o   $ 1.558,0.693&�6�   $��24(�6�   $
��Bold"�6�   �� 5%   
   -   5         ��Name$ img_logo��5%      $
��Left=�6"   $	��469��6=   $	��Top=�6J   $	��349��6b   $��sports1.png��6n   $
��Fill=�6�   5&      5'      