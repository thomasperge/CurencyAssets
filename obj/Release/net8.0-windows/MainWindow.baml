   M S B A M L   `   `   `  ���� J  FCryptoCurrencie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CryptoCurrencieCryptoCurrencie  U QLiveCharts.Wpf, Version=0.9.8.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf      CryptoCurrencie.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:CryptoCurrencie     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf       � Title$  Portfolio Calculator��$	��670��$	��626��.���  � ColumnDefinitions �� $
��Auto ��� $��* �.+��� 
�������$��0��$��2��$��0,0,1,0q�._���  �� TabStripPlacement$
 Left=����#F0F0F0 � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� Padding
 �� Triggers P� Property P� Value �� 
TargetName��%  '��       �� " ��.���  � ��$
 17,6q���  � ��
 �������  � ��
 �   ���  � �� �� " ��.R��� $ Border��#��z��#	 z��._��� $��Header��$��Center=�$��Center=�
 P�  �@��
IsSelected$
 True��. ��� $ Border�� � �� �#EFEFEF.@��� $	��Top��.���  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��Top Cryptos��$
��Bold"�$��Center=�$��Center=�$	��100��$��0,6,0,6q��� $��1������ *CryptoCurrencies+���� .R�� $��80��$��5q� �� $
��Auto ��� $��* �.+��� $��50��$	��100��$��Center=�$��0,0,15,0q����� *ThumbImage.Url+� $��1�� �� $	��33* ��� $	��33* ��� $	��33* �.+��� $��0�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Name: ��$��5,0,5,0q��� $
��Bold"����� *name+�� $��1��$ 
Horizontal=�$��Center=�.+��� $��Last 24h : ��$��5,0,5,0q��� $
��Bold"����� *change_percent_last_day+�� $��%��$
��Bold"�$��0,0,5,0q��� $��(��$
��Bold"�$��0,0,0,0q��� $��$��$��0,0,1,0q��� ���� *change_price_last_day+�� $��)��$
��Bold"��� $��2��$ 
Horizontal=�$��Center=�.+��� $��Last 7days : ��$��5,0,5,0q��� $
��Bold"����� *change_percent_last_week+�� $��%��$
��Bold"�$��0,0,5,0q��� $��Portfeuille��.���  �� $	��80* ��� $	��20* �.+��  �� $
��Auto ��� $��* �.+��� $��All Positions et Assets��$	��145��$
��Bold"�$��0,5,0,5q�$��14(��� $��1��$	��Top=����� *UserPortfolio.Positions+���� .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��Name : ��$
��Bold"��� ���� *
CoinName+�� $ 
Horizontal=�.+��� $��Purchase Price : ��$
��Bold"��� ���� *PurchasePrice+�� $ 
Horizontal=�.+��� $��Actual Market Price : ��$
��Bold"��� ���� *CurrentPrice+�� $ 
Horizontal=�.+��� $��Quantity : ��$
��Bold"��� ���� *
Quantity+�� $ 
Horizontal=�.+��� $��Total Cost : ��$
��Bold"��� ���� *	TotalCost+�� $ 
Horizontal=�.+��� $��	Profit : ��$
��Bold"��� ���� *
ProfitLoss+�� $ 
Horizontal=�.+��� $��Is Risky Position : ��$
��Bold"��� ���� *	IsRisky+�� $��1��.+��� $ 
Horizontal=�.+��� $
��Bold"�$��Total investments : ���� $��$���� ���� *(&UserPortfolio.CalculateTotalInvestment+�� $ 
Horizontal=�.+��� $
��Bold"�$��Current Value : ���� $��$���� ���� *%#UserPortfolio.CalculateCurrentValue+�� $ 
Horizontal=�.+��� $
��Bold"�$��Total Assets : ���� ���� *$"UserPortfolio.CalculateTotalAssets+�� $ 
Horizontal=�.+��� $
��Bold"�$��Total Profits : ���� $��$���� ���� *%#UserPortfolio.CalculateTotalProfits+�� $ 
Horizontal=�.+��� $
��Bold"�$��Risky portfolio : ���� ���� * UserPortfolio.IsPortfolioRisky+�� $��Ajout positions��.���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $)��#Ajouter un Assets dans le portfolio��$	��230��$��0��$
��Bold"�$��0,5,0,5q�$��14(��� $��Nom de l'assets:��$��1��$��5,5,5,0q��� -    ��Name$ txtCoinName��$��2��$��5,5,5,0q��� $��Prix d'achat:��$��3��$��5,5,5,0q��� -   $ txtPurchasePrice��$��4��$��5,5,5,0q��� $��Prix actuel:��$��5��$��5,5,5,0q��� -   $ txtCurrentPrice��$��6��$��5,5,5,0q��� $��
Quantité:��$��7��$��5,5,5,0q��� -   $ txtQuantity��$��8��$��5,5,5,15q��� -   $��Ajouter Position��$	��150��$��10��$��5q��� $��
Graphiques��.��#  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   Series �� *SeriesCollection+   AxisY   LiveCharts.Wpf.Axis     Title$ Y Axis��   MinValue$ 0Q��� $��Projections Future��.��� $��6,0,6,0q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $*��$Sélectionner une période de temps:��$��0���� -    ��Name$ cmbTimePeriod��$��1�� �� SelectedIndex$ 0��$��0,0,0,8q�.@��� $��Months���� $��Years���� $+��%Nombres de (mois/années) prévision:��$��2���� -   $ txtNumberOfPeriods��$��3��$��0,0,0,8q��� $/��)Entrer un % de profit (par mois/années):��$��4���� $ 
Horizontal=�$��Center=�$��5��$��0,0,0,20q�.+��� -   $ txtProfitPercentage��$��50��$��0,0,5,0q��� $��%��$��Center=��� -	   $��Generate Projection Graph��$	��230��$��7��