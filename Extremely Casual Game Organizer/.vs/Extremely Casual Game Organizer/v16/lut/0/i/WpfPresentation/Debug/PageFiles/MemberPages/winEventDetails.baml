   M S B A M L   `   `   `  ����Z  VExtremely Casual Game Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:Extremely_Casual_Game_Organizer.PageFiles.MemberPages5Extremely_Casual_Game_Organizer.PageFiles.MemberPages  5   	   K    EExtremely_Casual_Game_Organizer.PageFiles.MemberPages.winEventDetails   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   UlocalCclr-namespace:Extremely_Casual_Game_Organizer.PageFiles.MemberPages     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$ winEventDetails��5	   	   $	��450��6!   $	��800��6.    � WindowStartupLocation$ CenterOwner=�6Q   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 
lblDetails��5      $��2��6$   $��Event Details��68   $��Center=�6P   $��Center=�6r   $
��Bold"�6�   $��30(�6�   �� 5   
   -   5        $ lblEventType��5      $��1��6&   $��Right=�63   $��Center=�6V   $��Event Type:��6x   $��5q�6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5        $ lblEventStartDate��5      $��2��6+   $��Right=�68   $��Center=�6[   $��Start Date / Time: ��6}   $��5q�6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5        $ lblEventEndDate��5      $��3��6)   $��Right=�66   $��Center=�6Y   $��End Date / Time: ��6{   $��5q�6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5        $ lblLocation��5      $��4��6%   $��Right=�62   $��Center=�6U   $��
Location: ��6w   $��5q�6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5        $ lblDescription��5      $��5��6(   $��Right=�65   $��Center=�6X   $��	Details: ��6z   $��5q�6�   $
��Bold"�6�   $��18(�6�   �� 5!   
   -   5         ��Name$ txtType��5!      $��1��6#   $��2��60   $��5q�6@   $��18(�6K   $��Center=�6Y   $
��Left=�6{    �� 
IsReadOnly . |�.  
������ 6�   �� 5"   
   -	   5        $ txtStartDate��5"      $��2��6(   $��2��65   $��5q�6E   $��18(�6P   $��Center=�6^   $
��Left=�6�   
������ 6�   (  "System.Windows.Controls.DatePicker  5#   
   -
   5          Name$ dateStartDate��5#      $��2��6,   $��2��69   $��350 10 10 10q�6I   6_   �� 5$   
   -   5        $ 
txtEndDate��5$      $��3��6&   $��2��63   $��5q�6C   $��18(�6N   $��Center=�6\   $
��Left=�6~   
������ 6�     5%   
   -   5        $ dateEndDate��5%      $��3��6*   $��2��67   $��350 10 10 10q�6G   6]   �� 5&   
   -   5        $ txtLocation��5&      $��4��6'   $��2��64   $��5q�6D   $��18(�6O   $��Center=�6]   $
��Left=�6   
������ 6�   �� 5'   
   -   5        $ txtDescription��5'      $��5��6*   $��2��67   $��5q�6G   $��18(�6R   $��Center=�6`   $
��Left=�6�    . |�.  
������ 	 �� TextWrapping$
	 Wrap=�6�   �� 5)   
   -   5        
 ��Name$
 btnClose��5)      $��6��6#   $��2��60   $��Center=�6D   $��Center=�6f   $��Close��6�   $��350 10 350 10q�6�   6�   �� 5*   
   -   5        $
 btnSave��5*      $��6��6"   $
��Save��6/   $��300 10 10 10q�6>   6T   �� 5+   
   -   5        $
 	btnCancel��5+      $��6��6$   $��2��61   $��Cancel��6A   $��10 10 300 10q�6R   6h   �� 5,   
   -   5        $
 btnEdit��5,      $��1��6"   $��340 10 5 10q�62   .��6]   Edit6c   5-      5.      