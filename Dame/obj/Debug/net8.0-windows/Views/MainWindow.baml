   M S B A M L   `   `   `  ����?  ;Dame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DameDame  5   	       Dame.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Dame     5   	     � Title$
  Dame��5   	   $	��760��6   $	��800��6#   
�������.��5	      �� $��Center=�6   .+�5   
   o� $��22��6   $	��Top=�6   $��Stretch=�61   $	��Top=�6O   $
��2000��6g   .@�5      m� $
��File��6    m� IsCheckable$ False��6%   .@�5      m� $��New Game��6   $ False��6-    m� Command 6A   �� *	NewGame+m� 5      $��	Save Game��6   $ False��6.    6B   �� *
SaveGame+m� 5      $��	Load Game��6   $ False��6.    6B   �� *
LoadGame+m� 5      $��
Statistics��6   $ False��6/    6C   �� *
Statistics+5      m� 5      $��Options��6   .@�5      m� $��Multiple Jump��6   $ False��62   .@�5      m� $��On��6B    6   �� *MultipleJumpOn+ m� 	IsChecked 6N   �� *MultipleJump.OnState+m� 5      $	��Off��6C    6   �� *MultipleJumpOff+ 6P   �� *MultipleJump.OffState+5      5      m� 5      $
��Help��6   $ False��6%   .@�5      m� $��About��6   $ False��6*    6>   �� *About+5      5      �� 5   
   $��Center=�6   $��Center=�62   .+�5      � 
������� � ColumnDefinitions 5       �� 5!      $
��auto �6'   �� 5"      $��* �6'   .+�5&      � $��0��6    � RowDefinitions 5'      �� 5(      $
��auto �6(   �� 5)      $
��auto �6(   .+�5+      �� $��0��6A   $��	30,30,0,0q�6N   ��6#   �� *Board+��5,      �� 5-      .R�5.   "   �� ��6/   �� ��5/   &   �� 50   *   .R�51   .   ��  �� Orientation$ 
Horizontal=�69   52   +   ��54   &   �� 55   *   .R�56   .   � .+�57   2   �� $��75��69   $��75��6D   $��1q�6P   ���#000f00._�58   6   �� $��UniformToFill=�6[   ��6<   �� *CellTexture+6[   59   3   �� 5:   2   ��69   �� *ClickPieceCommand+��6_   �� *Coord+��5;   6   �� 5<   :   .R�5=   >   �� $��70��6   $��70��6�   ��6D   �� *Piece.Texture+ �� TargetNullValue Z� 6�   5>   ;   5@   3   �� 5A   2   ��69   �� *MovePieceCommand+��6^   �� *Coord+��5B   6   �� 5C   :   .R�5D   >   �� $��UniformToFill=�6}   $��74��6�   $��74��6�   ��6D   �� *HintTexture+ Z� 6�   5E   ;   5G   3   5H   /   5I   +   5K   #   5L      5N      �� 5Q      $��1��6!   $ 
Horizontal=�6.   $
��Left=�6G   $��	30,15,0,0q�6b   .+�5R      �� $��45��6!   $��45��6,   $��0q�68   ���#000f00$
��Left=�6b   ._�5S      �� $��UniformToFill=�6S   ��6$   �� *PlayerCount.RedPieceTexture+6S   5T      �� 5U      $��:��6$   $��20(�6-   $
��Bold"�6;   $��4,7,0,0q�6M   �� 5V      $��20(�6J   $
��Bold"�6X   $��4,7,0,0q�6j   ��6$   �� *PlayerCount.RedCount+6j   �� 5X      $��45��6!   $��45��6,   $��0q�68   ���#000f00$
��Left=�6b   $��	440,0,0,0q�6}   ._�5Y      �� $��UniformToFill=�6U   ��6$   �� *PlayerCount.WhitePieceTexture+6U   5Z      �� 5[      $��:��6$   $��20(�6-   $
��Bold"�6;   $��4,7,0,0q�6M   �� 5\      $��20(�6L   $
��Bold"�6Z   $��4,7,0,0q�6l   ��6$   �� *PlayerCount.WhiteCount+6l   5]      5^      �� 5a      $��1��6   $��Center=�6-   $	��100��6H   $��0,0,0,40q�6U   .+�5b      �� $��75��6   $��75��6(   $��0q�64   ���#000f00$��Center=�6^   $
��Left=�6y   $��20,0,0,0q�6�   ._�5c      �� $��UniformToFill=�6F   ��6    �� *PlayerTurn.Texture+6F   5d      �� 5e      $��Player Turn��6    $��18(�63   $
��Bold"�6A   $
��Left=�6S   $��10,0,0,0q�6n   5f      5i      5j      5m      5o      