   M S B A M L   `   `   `  ����Z  VExtremely Casual Game Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Extremely_Casual_Game_OrganizerExtremely_Casual_Game_Organizer  5      5    /Extremely_Casual_Game_Organizer.EditUserProfile   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Extremely_Casual_Game_Organizer     5        N� Title$  EditUserProfile��5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��500 �6   �� 5      .+�5!   
   �� $��0��6   $��Center=�6   $��Center=�6A    � IsSharedSizeScope . $��2��6�   $��20(�6�   $��1q�6�   
���   �$	��250��6�   $��65��6�   .��6�   Edit Profile6�   �� 5"   
   -   5         ��Name$ 	imgMember��5"      $��0��6#   $��1��63   $	��Top=�6@   $
��Left=�6X   $	��150��6s   $	��150��6   $��	10,10,0,0q�6�   6�   �� 5#   
   -   5         ��Name$ lblFirstName��5#      $��1��6&   $��0��63   $��25��6C   $	��100��6O   $	��Top=�6[   $
��Left=�6s   $��
170,10,0,0q�6�   6�   �� 5$   
   -   5        $ lblFamilyName��5$      $��1��6'   $��0��64   $��25��6D   $	��100��6P   $	��Top=�6\   $
��Left=�6t   $��
270,10,0,0q�6�   6�   �� 5%   
   -   5        $ lblLocation��5%      $��1��6%   $��0��62   $��25��6B   $	��200��6N   $	��Top=�6Z   $
��Left=�6r   $��
170,40,0,0q�6�   6�   �� 5&   
   -   5         ��Name$ 	btnUpload��5&      $��1��6$   $��0��61   $	��100��6A   $��25��6M   $	��Top=�6Y   $
��Left=�6q   $��35 170q�6�   .��6�   Upload6�   �� 5'   
   -   5        $ lblMemberBio��5'      $��1��6&   $��0��63   $	��175��6C   $	��400��6P   $��Bottom=�6\   $
��Left=�6w   $��	10,0,0,20q�6�   6�   �� 5)   
   -   5        $ btnDeactivate��5)      $��1��6(   $��1��68   $��30��6E   $	��150��6Q   $��Bottom=�6]   $��0,0,0,75q�6x   .��6�   Deactivate Account6�   �� 5*   
   -   5        $ 	btnCancel��5*      $��1��6$   $��1��64   $��30��6A   $	��100��6M   $��0,300,125,0q�6Y   .��6n   Cancel6v   �� 5+   
   -	   5        $ btnSave��5+      $��1��6"   $��1��62   $��30��6?   $	��100��6K   $��125,300,0,0q�6W   .��6l   Save6s   5,      5-      