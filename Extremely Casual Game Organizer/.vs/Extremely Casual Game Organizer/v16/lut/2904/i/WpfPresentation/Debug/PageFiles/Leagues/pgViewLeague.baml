   M S B A M L   `   `   `  ����Z  VExtremely Casual Game Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:Extremely_Casual_Game_Organizer.PageFiles.Leagues1Extremely_Casual_Game_Organizer.PageFiles.Leagues  5      D    >Extremely_Casual_Game_Organizer.PageFiles.Leagues.pgViewLeague   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Qlocal?clr-namespace:Extremely_Casual_Game_Organizer.PageFiles.Leagues     5        N� Title$  League Details��5	      .��5      �  J� RenderTransformOrigin$ 
0.028,0.67&�6   ���#eeee � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��45 �6   �� 5      $��5 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $
��12.2 �6   �� 5      $
��18.2 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $��134.4 �6   �� 5      .+�5   
   �� -   5         ��Name$ lblName��5      $��2��6!   $��Center=�5       $
��Bold"�64   $��22(�5!      $��45��6   $��Bottom=�6*   $��	0,0,0,0.4q�6E   $��2��6X   .��6i   League Details6y   �� 5"   
   $��0��6   $��2��6    $��Right=�5#      $��15(�5$      $��0 5 10 0q�6   $��0,4.6,5.4,30q�61   $��3��6G   .��6X   League Name:6f   �� 5%   
   -   5         ��Name$ txtName��5%      $��1��6#   $��3��63   $
��Left=�5&      $��15(�5'      $��7.6,1.8,100,1.6q�6   $��0,0,0,0q�67    �� 
IsReadOnly . 6Q   �� 5(   
   $��0��6   $��4��6    $��Right=�5)      $��15(�5*      $��0 5 10 0q�6   $��0,0.4,5.4,0q�61   .��6F   Sport:6N   �� 5+   
   -   5        $ txtGame��5+      $��1��6#   $��4��63   $
��Left=�5,       . $��15(�5-      $��7.6,2.4,100,2q�6   $��0,0,0,0q�65   �� 5.   
   $��0��6   $��5��6    $��Right=�5/      $��15(�50      $��0 5 10 0q�6   $��0,6,5.4,24.4q�61   $��2��6G   .��6X   Dues6^   �� 51   	   -   5        $ txtDues��51      $��1��6"   $��5��62   $
��Left=�52      $��15(�53      $��	6.6,2,0,2q�6   $
��Left=�61   $��78��6L    . 6W   �� 54   
   $��6��6   $��Right=�55      $��15(�56      $��0 5 10 0q�6   $��56,1.6,0,10.4q�61   $
��Left=�6H   $��76��6c   $��2��6n   .��6   	Gender:6�   �� 57   
   -   5        $ 	txtGender��57      $��6��6%   $
��Left=�58      $��15(�59      $��7.6,2.6,0,0.4q�6   $��0,0,0,0q�65   $
��Left=�6O   $	��121��6j    . $��1��6�   �� 5;   
   $��0��6   $��7��6    $��Right=�5<      $��15(�5=      $��0 5 10 0q�6   $��2,4.6,5.4,48.4q�61   $��3��6I   .��6Z   
Details:6d   �� 5>   
   -   5        $ 
txtDetails��5>      $��1��6&   $��7��66   $
��Left=�5?      $��15(�5@      $��7.6,11.6,100,0q�6   $��0,0,0,0q�66   $��4��6P   $	��223��6a   $	��Top=�6n    . 6�   �� 5A   
   $��1��6   $��6��6    $��Right=�5B      $��15(�5C      $��0 5 10 0q�6   $��309.6,0,0,0q�6.   $��2��6C   $
��Max:��6T   $
��Left=�6c   $	��165��6~   $��31��6�   $	��Top=�6�   �� 5D   
   -   5        $ txtMax��5D      $��1��6"   $��6��62   $
��Left=�5E      $��15(�5F      $��479.6,0,0,2.4q�6   $
��Left=�62   $��86��6M    . 6X   �� 5G   
   -   5         ��Name$ btnExit��5G      $
��Exit��6"   $��1��61   $��10��6A   $��	20 0 20 0q�6O   $��Center=�6c   $��Center=�6~   $��40��6�   ���	#FF419CC3$��3��6�   $ 0.485,-0.691&�6�   $��488.6,179.6,96,21.2q�6�   $��81��6  5J      �� 5K   
   -	   5        $ 
btnRequest��5K      $��1��6%   $��Request to Join��65   $��10��6O   $��	20 0 20 0q�6]   $��Center=�6q   $��Center=�6�   $��40��6�   ���	#FF419CC3$��3��6�   $ 0.485,-0.691&�6�   $��7,179,502,21q�6  $	��157��6  5M      5N      5O      