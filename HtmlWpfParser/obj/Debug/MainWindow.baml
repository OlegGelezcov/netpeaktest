   M S B A M L   `   `   `  ����H  DHtmlWpfParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HtmlWpfParserHtmlWpfParser  5   	       HtmlWpfParser.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HtmlWpfParser     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	       �� Source�� 5
   
   $ 	dict.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��6* �6    � ColumnDefinitions 5   
   �� 5      $��6* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��
textBoxUrl��5      $"��https://netpeaksoftware.com/��6$   $��0��5      $��0��6   $��Consolas)�5      $��20(�6(   $
��Bold"�66   $
��Left=�5      $��Center=�64   $��5,5,5,5q�6V   $	��100��5      $��Center=�6"   $��50��6=   �� 5   
   -   5        $��btnParseUrl��5      $��Parse!��6$   $��0��66   $��1��6C   $��Consolas)�5      $��20(�6'   $
��Bold"�65   $��5,5,5,5q�6G   $	��100��5   +   $��50��6;   $��Center=�6J   �� 5   
   -   5        $��lstViewResults��5      $��1��6)   $��0��66   $��2��6F   $��5,5,5,5q�5      $��Hidden=�6(   
���������5       �� 5!      .R�5"      ��  �� Orientation$ 
Horizontal=�6"   $��Stretch=�6;   .+�5#      �� -   5        $��Details��5#   !   $��5,5,5,5q�64   $	��100��6E   $��50��5$   !   $��Right=�60      ButtonStyle#��[  5%   !   
 � Tag 5#   T   �� 5%   !   �� 5&      $��5,5,5,5q�6%   $ Vertical=�66   .+�5'      ��   ListViewItemText#��[ 6>   ��6(   �� *Url+6>   �� 5(      #��[ 6@   ��6(   �� *Title+6@   �� 5)      #��[ 6T   ��6(   �� *ResponseData.ResponseCode+6T   5*      5,      5-      5/      50      51      