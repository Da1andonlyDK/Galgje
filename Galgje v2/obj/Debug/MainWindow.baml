   M S B A M L   `   `   `  ����D  @Galgje v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Galgje_v2	Galgje_v2  5          Galgje_v2.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Galgje_v2     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $
��1280��5	      $	��720��5
      ��5      �� 5   
    �� ImageSource$ /Resources/galgjebg.jpg��6   .��5      ]� -   5        $��VolledigScherm��5      
������ .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5       $��* �6    �� 5!      $��* �6    �� 5"      $��* �6    �� 5#      $��* �6    �� 5$      $��* �6    �� 5%      $��* �6    .+�5(      �� -   5        $��IMG_Galg��5(      $��0��5)      $��3��5*      $��1��5+      $��4��5,      $	��Top=�5-      $
��None=�5.      �� 50      -   5        $��	MSG_Label��51      $��2��52      $��0��53      $��6��54      $��10q�55      $��Bottom=�56      $��Center=�57      $�� ��58      $9��3/Galgje v2;component/Resources/#GRAPHIC PSYCHOPATHY)�59      $��24(�5:      $
��Bold"�5;      
������� J� Effect 5=      3  -System.Windows.Media.Effects.DropShadowEffect  5>      5@      �� 5B      -   5        $��BTN_NieuwSpel��5C      $��3��5D      $��2��5E      $��2��5F      $	��300��5G      $��50��5H      $��10q�5I      $��Center=�5J      $	��Top=�5K      $��Center=�5L      $��Center=�5M      
������ 
���   �$	��2pxq�5P      $��
Nieuw spel��5Q       � Cursor$
 Hand��5R      $9��3/Galgje v2;component/Resources/#GRAPHIC PSYCHOPATHY)�5S      $��32(�5T      ���#B51424 5Y        5Z      5\      �� 5^      -   5        $��BTN_Verberg��5_      $��3��5`      $��2��5a      $��2��5b      $	��300��5c      $��50��5d      $��10q�5e      $��Center=�5f      $	��Top=�5g      $��Center=�5h      $��Center=�5i      
������ 
���   �$	��2pxq�5l      $��Verberg woord��5m      $
 Hand��5n      $9��3/Galgje v2;component/Resources/#GRAPHIC PSYCHOPATHY)�5o      $��32(�5p      ���#B51424$y�Hidden=�5u       5v        5w      5y      �� 5{      -   5        $��BTN_StartOpnieuw��5|      $��3��5}      $��2��5~      $��2��5      $	��300��5�      $��50��5�      $��Center=�5�      $	��Top=�5�      $��Center=�5�      $��Center=�5�      
������ 
���   �$	��2pxq�5�      $��Start opnieuw��5�      $
 Hand��5�      $9��3/Galgje v2;component/Resources/#GRAPHIC PSYCHOPATHY)�5�      $��32(�5�      ���#B51424$y�Hidden=�5�       5�        5�      5�      �� 5�      -   5         ��Name$ BTN_Raad��5�      $��3��5�      $��2��5�      $��2��5�      $��2��5�      $	��300��5�      $��50��5�      $��Center=�5�      $��Center=�5�      $��Center=�5�      $��Center=�5�      
������ 
���   �$	��2pxq�5�      $
��Raad��5�      $
 Hand��5�      $9��3/Galgje v2;component/Resources/#GRAPHIC PSYCHOPATHY)�5�      $��32(�5�      ���#B51424$y�Hidden=�5�       5�        5�      5�      �� 5�      -   5        $��Input��5�      $��4��5�      $��2��5�      $��2��5�      $	��300��5�      $��10q�5�      $��Bottom=�5�      $��0q�5�      $9��3/Galgje v2;component/Resources/#GRAPHIC PSYCHOPATHY)�5�      $��32(�5�      {�.  $�� ��5�       �� TextAlignment$ Center=�5�      $y�Hidden=�5�      �� 5�      -	   5        $��Output��5�      $��5��5�      $��2��5�      $��2��5�      $��2��5�      $��Center=�5�      $��Center=�5�      $9��3/Galgje v2;component/Resources/#GRAPHIC PSYCHOPATHY)�5�      $��24(�5�      $
��Bold"�5�      
�������$�� ��5�       5�        5�      5�      �� 5�      $��0��5�      $��2��5�      $��2��5�      $��4��5�      $��Center=�5�      $��Center=�5�      $
��None=�5�      5�      �� 5�      -
   5        $��TB_Timer��5�      $��0��5�      $��6��5�      $��Center=�5�      $��Center=�5�      
������ $��0q�5�      $9��3/Galgje v2;component/Resources/#GRAPHIC PSYCHOPATHY)�5�      $��72(�5�      
�������5�      � 5�      $��6��6   $��5��6     5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'    5�      �� 5�      $��* �6$   �� 5�      $��* �6$   �� 5�      $��* �6$   �� 5�      $��* �6$   �� 5�      $��* �6$   .+�5�      �� $��1��5�      $��2��5�      $��1��5�      $��2��5�      $��25��5      $��25��5     $	��Top=�5     $��/Resources/musicicon.png��5     �� 5     -   5        $��BTN_Play��5     $��2��5     $��2��5	     $��1��5
     $��25��5     $��25��5     $��5q�5     $��Right=�5     $��0q�5     $
 Hand��5     ��5     �� 5     $ /Resources/playicon.png��6%    j� Stretch$
 Fill=�6K   5     �� 5     -   5        $��BTN_Stop��5     $��2��5     $��2��5     $��2��5     $��25��5     $��25��5     $��5q�5     $
��Left=�5     $��0q�5      $
 Hand��5!     ��5#     �� 5$     $ /Resources/stopicon.png��6%   $
 Fill=�6K   5&     5(     5*     5,     5.     