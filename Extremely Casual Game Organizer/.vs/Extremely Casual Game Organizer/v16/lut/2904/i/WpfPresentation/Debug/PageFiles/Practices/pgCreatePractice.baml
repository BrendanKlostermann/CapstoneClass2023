   M S B A M L   `   `   `  ����Z  VExtremely Casual Game Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyAclr-namespace:Extremely_Casual_Game_Organizer.PageFiles.Practices3Extremely_Casual_Game_Organizer.PageFiles.Practices  5      J    DExtremely_Casual_Game_Organizer.PageFiles.Practices.pgCreatePractice   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      MlocalAclr-namespace:Extremely_Casual_Game_Organizer.PageFiles.Practices  5        N� Title$  pgCreatePractice��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��800 �6   .+�5   
   �� -   5         ��Name$ txtLocation��5      $
��Left=�6'   $��35��6B   $��151,176,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��223��6�   $��14(�6�   �� 5   
   -   5         ��Name$ lblLocation��5      $��	Location:��6%   $
��Left=�69   $��
18,176,0,0q�6T   $	��Top=�6h   $��35��6�   $��94��6�   $��18(�6�   �� 5   
   -   5        $ lblDescription��5      $��Description:��6(   $
��Left=�6?   $��415,257,0,0q�6Z   $	��Top=�6o   $��35��6�   $	��128��6�   $��18(�6�   �� 5   
   -   5         ��Name$ btnCreatePractice��5      $��Create��6,   $
��Left=�6=   $��345,332,0,0q�6X   $	��Top=�6m   $	��111��6�   $��47��6�   $��20(�6�   6�   �� 5   
   -   5        $ txtDescription��5      $
��Left=�6*   $	��107��6E   $��543,257,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��223��6�   $��14(�6�   � 5   
    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��40 �6    �� 5      $��40 �6    .+�5      �� -   5        $ lblCreatePractice��5      $��Create new Practice��6/   $
��Left=�6M   $��235,26.4,-241,-4.8q�6h   $��Center=�6�   $��60��6�   $	��330��6�   $��36(�6�   $��2��6�   $��2��6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5      -   5          Name$ 	DateTimer��5   "   $��40��65   $��550,133.6,32,-132.8q�6A   $��3��6^   �� 5       -   5        $ lblDateTime��5       $��Date and Time��6)   $
��Left=�6A   $��32��6\   $��412,133.6,0,-124.8q�6h   $��3��6�   $	��Top=�6�   $	��133��6�   $��18(�6�   5"      �� 5#   
   -	   5        $ lblZip��5#      $��	Zip Code:��6    $
��Left=�64   $��
18,257,0,0q�6O   $	��Top=�6c   $��35��6{   $��94��6�   $��18(�6�   �� 5$   
   -
   5        $ txtZip��5$      $
��Left=�6"   $��35��6=   $��151,257,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��223��6�   $��14(�6�   �� 5%   
   -   5        $ btnBackToTeam��5%      $��Back to Team��6(   $
��Left=�6?   $��690,407,0,0q�6Z   $	��Top=�6o   $	��100��6�   $��32��6�   6�   5&      5*      