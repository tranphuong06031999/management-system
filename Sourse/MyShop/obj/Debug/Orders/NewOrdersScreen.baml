   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyShopMyShop  5      -clr-namespace:MyShop.OrdersMyShop.Orders  5      #    MyShop.Orders.NewOrdersScreen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	converterclr-namespace:MyShop  5      'localclr-namespace:MyShop.Orders  5        � 	Resources  5         MyShop.PriceConverter   PriceConverter��%   &	          5   
   6#   5      .��5      � -   5         �Name$ createOrdersScreen��5      .+�5   
   � ���	#FFFAFAFA � RowDefinitions 5      �� 5      $
��0.5* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6     � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��2* �6#   .+�5!      �� -   5        $
��Left=�5!      
������ ���#303030$	��Top=�5$      $��30��5%      $��30��6!    & "MaterialDesignIconForegroundButton#��[ 5'      $��10 5 0 0q�5(      .��5)      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardArrowLeft=�6*   $��30��5*   .   $��30��5+   .   5,      �� 5.      $��	Dashboard��6   $��13(�5/      $��20��50      $
��Left=�51      $	��Top=�52      $��	37 10 0 0q�53      $��Sitka Subheading)�54      $��Italic$�55      ���	#FF84858556      �� 59      -   5        $��Title��5@      $��CREATING NEW ORDERS��59      $��Sitka Subheading)�5:      $��25��5;      $��22(�5<      $��0q�5=      $
��Bold"�5>      $	��Top=�5?      $��Center=�5A      $��3��5B      �� 5E      -   5        $��CustomerNameTextBox��5M      $��2��5E      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Customer name��5F      $	��220��5G      $��15(�5H      
������ $��Sitka Subheading)�5J      $
��Bold"�5K       % !MaterialDesignFloatingHintTextBox#��[ 5L      $��Center=�5N      �� 5Q      -   5        $��customerPhoneTextBox��5Z      $��1��5Q      $ Phone��5R      $	��220��5S      $��15(�5T      
������ $��Sitka Subheading)�5V      $
��Bold"�5W      #��[ 5Y      $��Center=�5[      5\      �� 5_      -   5        $��editProductId��5j      $��3��5_      $ Select the product��5`      $	��210��5a      
���  ��$��15(�5c       �� 
IsReadOnly . 
������ $��Sitka Subheading)�5f      $
��Bold"�5g      #��[ 5i      $��Center=�5k      $��10 0 0 0q�5l      �� 5o      -   5        $��numberBuyTextBox��5{      $��1��5o      $��1��6#   $ Amount��5p      $	��110��5q      $��	0,0,120,0q�5r      $��15(�5s      
������ $��Sitka Subheading)�5w      $
��Bold"�5x      #��[ 5z      $��Center=�5|      {�5y      ��  �� ElementName$ editProductId�� �� Path$ Text.Length�5|      �� 5      -   5        $��totalTextBox��5�      $��2��5      $��1��6#   $ 
Total (đ)��5�      $	��110��5�      $��	120,0,0,0q�5�      $��15(�5�      
������ $��Sitka Subheading)�5�      $
��Bold"�5�       . #��[ 5�      $��Center=�5�      {�5�      �� $ editProductId��$ Text.Length�5�      �� 5�      -	   5        $��originalPriceTextbox��5�      $��1��5�      $��1��6#   $	��110��5�      $��	120,0,0,0q�5�      $��15(�5�      
������ $��Sitka Subheading)�5�      $
��Bold"�5�       . #��[ 5�      $��Center=�5�      {�5�      �� $ editProductId��$ Text.Length�.��5�   1    5�      �� 5�      �� 5�      .�6   Cost6"    (₫)5�      .��5�   2   5�      �� 5�      -
   5        $��sellPriceTextBox��5�      $��2��5�      $��1��6#   $	��110��5�      $��	0,0,120,0q�5�      $��15(�5�      
������ $��Sitka Subheading)�5�      $
��Bold"�5�       . #��[ 5�      $��Center=�5�      {�5�      �� $ editProductId��$ Text.Length�.��5�   1    5�      �� 5�      �� 5�      .�6   Price6"    (₫)5�      .��5�   2   5�        5�      $ CartAdd=�6&   $��3��65   $��30��5�   &   $��30��61   ���#21bf73$��3,40,0,0q�5�   ;   �� 5�      -   5        	 ��Name$	 btnAddToListProduct��5�      $	��210��5�      $��1��5�      $��3��5�      $��30��5�      
 J� Opacity$
 1Q�5�      
����������#21bf73$y�Hidden=�5�        MaterialDesignRaisedButton#��[ 5�      .��5�      ��  �� Orientation$ 
Horizontal=�6   .+�5�        $	 Add=�6.   �� 5�      $��ADD TO PRODUCT LIST��6    $��14(�5�       $��Sitka Subheading)�5�       $��Italic$�5�       $��10 0 0 0q�5�       5�      5�      �� 5�      -   5        $��listProducts��5�      $��1��6+   $��2��68   $��3��6H   $��Sitka Subheading)�5�      $��13(�5�      $��6 8 6 0q�5�      
���   �$
��Left=�5�        5�       �� 
TargetType �� Property �� Value �� RelativeSource �� 
TargetType ]� Thumb ]� IncreaseRepeatButton ]� DecreaseRepeatButton��%�  '��       '�� �     �� 5�      " ��6   .�5�      ��  � ��$ CharacterEllipsis=�69   �� 5�       �@�ToolTip 64   ��  �� *Self+$
 Text�5�      �� 5�      " ��6   .�5�      ��  � ��$ 2,50,0,8q�63   �� 5�       �@��IsFlicksEnabled .  6C   �� 5�       � ��
 ���� 67   �� 5�       � �� 5�      �� 5�   "   " ��62   .R�5�   &   ]� ��. |�.   5�   *   n� 5�   .   $��8��64   ���#21bf736>    5�   *   �� 5�   .   $��ScrollBar.PageDownCommand��6;   $
 0Q�6_   |�.  6k    5�   *   �� 5�   .   $��ScrollBar.PageUpCommand��6;   $
 0Q�6]   |�.  6i   5�   '   5�   #   5�      5�      5�       �� View 5�      �� 5�      .P�5�      ��  �� Width$	 230��5�       �� DisplayMemberBinding 5�      �� *ProductName+ �� HeaderTemplate 5�      �� 5�   "   .R�5   &   ��  J� Effect 5  *   3  -System.Windows.Media.Effects.DropShadowEffect  5  .      Color$ White��5  -      	Direction$	 270Q�5  -      ShadowDepth$ 1Q�5  -      
BlurRadius$ 5Q�5  -   ._�5  *   �� $��Product name��60   $��1q�5	  (   $��15(�5
  (   
���   �$
��Bold"�5  (   5  '   5  #   5     �� 5     $	 130��6)    5  )   �� *
Quantity+ 5     �� 5  "   .R�5  &   ��  5  *     5  .   $ White��5  -   $	 270Q�5  -   $ 1Q�5  -   $ 5Q�5  -   ._�5  *   �� $��Quantity��60   $��1q�5   (   $��15(�5!  (   
���   �$
��Bold"�5#  (   5$  '   5%  #   5'     �� 5*     $	 150��5+      5,     �� *Total+ �� 	Converter# [   5-     �� 5.  "   .R�5/  &   ��  50  *     51  .   $ White��52  -   $	 270Q�53  -   $ 1Q�54  -   $ 5Q�55  -   ._�57  *   �� $��Money��60   $��1q�58  (   $��15(�59  (   
���   �$
��Bold"�5;  (   5<  '   5=  #   5?     5@     5C     �� 5F     $��Total money��6   $��4��6*   $��3��5G     $��Right=�5H     $	��Top=�5I     $��Sitka Subheading)�5J     $��15(�5K     $
��Bold"�5L     $��	0 5 160 0q�5M     �� 5N     -   5         ��Name$ sumTotalOfProduct��5P     $��4��5N     $��3��6%   $
��0 đ��5O     $��14(�5Q     $��Right=�5R     $	��Top=�5S     
���  ��$��Italic$�5U     $��0 8 50 0q�5V     �� 5X     -   5        $	 	btncancel��5X     $��Remove��5Y     $	��100��5Z     $��2��5[     $��4��5\     $��30��5]     $��Sitka Subheading)�5^     $
 1Q�5_     
����������#21bf73$
��Left=�5b     $	��Top=�5c     $��50 8 0 0q�5d     $y�Hidden=�5e     #��[ 5g     5h     � 5k     -   5         �Name$ ProgressBar��5n     $��1��5k     $��4��6'   $��4��68   $��2��6L   $��25��5l     $��25��6%    % !MaterialDesignCircularProgressBar#��[ 5m     5o     	� 5r     -   5        $��rdoGoToShop��5{     $��4��5r     $��Bottom=�6'   $��Center=�5s     $��DIRECT PAYMENT��67   $��Sitka Subheading)�5t     $��15(�5u     $��0,0,70,0q�5w     $
��Bold"�5x       	� 	GroupName$  Payment��5y     ! d� 	IsChecked$
! TrueY�5z     5{     	� 5|     -   5        $��rdoShip��5�     $��4��5|     $��1��6'   $��Bottom=�67   $��INDIRECT PAYMENT��5}     $��Center=�5~     $��Sitka Subheading)�5     $��15(�5�     $��0,0,60,0q�5�     $
��Bold"�5�     $  Payment��5�     5�     �� 5�     -   5        $��editMoneyTaken��5�     $��5��5�     $	��220��5�     $��15(�5�     
������ $��Sitka Subheading)�5�     $��Center=�5�     $
��Bold"�5�     #��[ 5�     {�5�     �� *	IsChecked+$ rdoGoToShop��.��5�  ,    5�     �� 5�     �� 5�     .�6   Money taken6(    (₫)5�     .��5�  2   5�     �� 5�     -   5        $��editMoneyExchange��5�     $��6��5�     $	��220��5�     $��15(�5�      . 
������ $��Sitka Subheading)�5�     $��Center=�5�     $
��Bold"�5�     #��[ 5�     {�5�     �� *	IsChecked+$ rdoGoToShop��.��5�  /    5�     �� 5�     �� 5�     .�6   Money exchange6+    (₫)5�     .��5�  2   5�     �� 5�     -   5        $��editAddress��5�     $��5��5�     $��1��6#   $��2��63   $��	25,0,60,0q�5�     $��15(�5�     
������ $��Sitka Subheading)�5�     $��Center=�5�     $
��Bold"�5�     $ Place of payment��5�     #��[ 5�     {�5�     �� *	IsChecked+$ rdoShip��5�     �� 5�     -   5        $��editDeposit��5�     $��6��5�     $��1��6#   $��2��63   $	��230��5�     $��15(�5�     
������ $��Sitka Subheading)�5�     $��Center=�5�     $
��Left=�5�     $��25,0,0,0q�5�     $
��Bold"�5�     #��[ 5�     {�5�     �� *	IsChecked+$ rdoShip��.��5�  )    5�     �� 5�     �� 5�     .�6   Advance payment6-    (₫)5�     .��5�  2   5�     �� 5�     -   5        $��editShipCost��5�     $��6��5�     $��1��6#   $��2��63   $	��220��5�     $��15(�5�     
������ $��Sitka Subheading)�5�     $��Center=�5�     $
��Left=�5�     $��	280,0,0,0q�5�     $
��Bold"�5�     #��[ 5�     {�5�     �� *	IsChecked+$ rdoShip��.��5�  *    5�     �� 5�     �� 5�     .�6   Shipping cost6*    (₫)5�     .��5�  2   5�     �� 5�     -   5        $��editMoneyWillGet��5�     $��6��5�     $��1��6#   $��2��63   $	��240��5�     $��15(�5�     
������ $��Sitka Subheading)�5�     $��Center=�5�     $
��Left=�5�     $��	525,0,0,0q�5�     $
��Bold"�5�      . #��[ 5�     {�5�     �� *	IsChecked+$ rdoShip��.��5�  .    5�     �� 5�     �� 5�     .�6    Payment after arrival of goods6;    (₫)5�     .��5�  2   5�     �� 5�     -   5        $��
btnConfirm��5     $��2��5�     $��7��5      $��0 0 20 0q�5     $��Right=�5     $	��150��5     $��CREATE ORDER��6!   $
��Bold"�5     
����������#21bf73$��15(�5     $��Sitka Subheading)�5     #��[ 5	     5     �� 5     -   5        $��btnScreenOrders��5     $��2��5     $��7��5     $	��200��5     $��33��5     $��LIST ORDERS��5     $
��Bold"�5     
����������#21bf73$��15(�5     $��Sitka Subheading)�5     #��[ 5     $��Italic$�5     $��Center=�5     $��0 4 0 0q�5     �� 5      -   5        $��7��5      $��3��5!     $��Right=�5"     $	��100��5#     $��CANCEL��6!   $
��Bold"�5$     
����������#21bf73$��15(�5'     $��	0 0 190 0q�5(     $��Sitka Subheading)�5)     #��[ 5*     5+     5-     5/     50     