   M S B A M L   `   `   `  ����Z  VExtremely Casual Game Organizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Extremely_Casual_Game_OrganizerExtremely_Casual_Game_Organizer  5      -    'Extremely_Casual_Game_Organizer.pgLogIn   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Extremely_Casual_Game_Organizer     5      -   5          N�Name$  pgMemberLogin��5       N� Title$ pgLogIn��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��250 �6   �� 5      .+�5   
   �� -   5         ��Name$ txtEmail��5      $��1��6$   $
��Left=�64   $��20��6O   $��300,148.4,0,0q�6[   $��2��6r    �� TextWrapping$
 Wrap=�6   $	��Top=�6�   $	��200��6�   G� 5   
   -   5         G�Name$ txtPassword��5      $��1��6+   $
��Left=�6;   $��20��6V   $��300,182.4,0,48q�6b   $��2��6z   $	��200��6�   �� 5   
   -   5         ��Name$ 	btnSignIn��5      $��Sign In��6$   $��1��66   $
��Left=�6F   $��20��6a   $��
325,10,0,0q�6m   $��3��6�   $	��Top=�6�   $	��150��6�   6�   �� 5   
   -   5        $ 	btnSignUp��5      $��Sign Up��6$   $
��Left=�66   $��20��6Q   $��
325,40,0,0q�6]   $��3��6q   $	��Top=�6~   $	��150��6�   $��1��6�   �� 5   
   -   5         ��Name$ lblEmail��5      $��Email��6"   $��1��62   $
��Left=�6B   $��200,148.4,0,0q�6]   $��2��6t   $	��Top=�6�    J� RenderTransformOrigin$ -0.766,0.57&�6�   �� 5   
   -   5        $ lblPassword��5      $��Password��6%   $��1��68   $
��Left=�6H   $��200,182.4,0,0q�6c   $��2��6z   $	��Top=�6�   $ -0.781,-0.109&�6�   	 J� IsHitTestVisible	 .  6�   � 5   
   $��2��6   $��2��6   
 � ColumnDefinitions
 5      �� 5      $	��150 �6#   �� 5      .+�5      �� -   5        $ LblLogin��5      $��Login��6&   $��1��66   $
��Left=�6F   $��
220,27,0,0q�6a   $	��Top=�6u   $��50��6�   $��75��6�   $��25(�6�   5      5!      5"      