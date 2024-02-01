namespace CryptoCurrencie
{
    public class PortfolioPosition
    {
		public bool IsRisky { get; set; }
		public string CoinName { get; set; }
		public double PurchasePrice { get; set; }
		public double CurrentPrice { get; set; }
		public double Quantity { get; set; }

		public double TotalCost => PurchasePrice * Quantity;

		public double ProfitLoss => (CurrentPrice - PurchasePrice) * Quantity;

		public PortfolioPosition(string coinName, double purchasePrice, double currentPrice, double quantity)
		{
			CoinName = coinName;
			PurchasePrice = purchasePrice;
			CurrentPrice = currentPrice;
			Quantity = quantity;
		}

		public PortfolioPosition() { }
	}
}
