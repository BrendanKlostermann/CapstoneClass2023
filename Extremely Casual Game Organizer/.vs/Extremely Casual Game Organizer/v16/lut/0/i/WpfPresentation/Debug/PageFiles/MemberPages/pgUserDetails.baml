   M S B A M L   `   `   `  ����Z  VExtremely Casual Game Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Extremely_Casual_Game_OrganizerExtremely_Casual_Game_Organizer  5      3    -Extremely_Casual_Game_Organizer.pgUserDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Extremely_Casual_Game_Organizer     5        N� Title$  UserDetails��5      .��5      � 
������� � RowDefinitions 5   
   �� 5      �� 5      $	��250 �6   �� 5      $��50 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      �� 5       $��30 �6   �� 5!      $��30 �6   �� 5"       � ColumnDefinitions 5$   
   �� 5%      �� 5&      .+�5)   
   �� -   5         ��Name$ imgProfilePicture��5)      $��1��6+   $	��250��68   $��2��6D   6Z   �� 5*   
   -   5         ��Name$ lblUsername��5*      $��2��6%   $��2��62   $��Center=�6F   $��Center=�6j   $��24(�6�   .��6�   
Username6�   �� 5+   
   $��3��6   $��75��6   $
��Left=�6(   $��25 0 0 0q�6C   .��6U   First Name:6d   �� 5,   
   $��4��6   $��75��6   $
��Left=�6(   $��25 0 0 0q�6C   .��6U   
Last Name:6c   �� 5-   
   -   5         ��Name$ txtFirstName��5-      $��3��6(   $	��250��65   $��Center=�6A   $
��Left=�6c   $��
 110 0 0 0q�6~   .��6�   	Test text6�   �� 5.   
   -   5        $ txtFamilyName��5.      $��4��6)   $	��250��66   $��Center=�6B   $
��Left=�6d   $��
 110 0 0 0q�6   .��6�   	Test text6�   �� 5/   
   -   5         ��Name$ 
btnTimeout��5/      $��6��6%   $	��100��62   $��25��6>   $
��Left=�6J   $��25 0 0 0q�6e   .��6w   	Timeout6�   �� 50   
   -   5        $ btnBan��50      $��7��6!   $	��100��6.   $��25��6:   $
��Left=�6F   $��25 0 0 0q�6a   .��6s   Ban6x   �� 51   
   -   5        $ 	btnDelete��51      $��7��6$   $	��100��61   $��25��6=   $
��Left=�6I   $��	150 0 0 0q�6d   .��6�   Delete6�   �� 52   
   -   5        $ 
btnConfirm��52      $��7��6%   $��2��62   $	��100��6B   $��25��6N   $��right=�6Z   $��0 0 25 0q�6v   .��6�   	Confirm6�   �� 53   
   -	   5        $ 	btnCancel��53      $��7��6$   $��2��61   $	��100��6A   $��25��6M   $��right=�6Y   $��	0 0 150 0q�6u   .��6�   Cancel6�   56      57      